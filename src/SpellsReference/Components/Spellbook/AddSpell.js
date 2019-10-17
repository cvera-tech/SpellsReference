import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import ErrorMessages from '../ErrorMessages';

function Spell({ spell }) {
    return (
        <tr data-name={spell.name} data-id={spell.id}>
            <td>{spell.name}</td>
            <td>{spell.level}</td>
            <td>{spell.school}</td>
            <td>{spell.castingTime}</td>
            <td>{spell.range}</td>
            <td>{spell.verbal ? 'True' : 'False'}</td>
            <td>{spell.somatic ? 'True' : 'False'}</td>
            <td>{spell.materials}</td>
            <td>{spell.duration}</td>
            <td>{spell.ritual ? 'True' : 'False'}</td>
            <td>{spell.description}</td>
        </tr>
    );
}

function SpellList(props) {
    function handleSpellClick(event) {
        // Grab the data from the table rows
        const tr = event.target.parentNode;
        const spellName = tr.getAttribute('data-name');
        const spellId = tr.getAttribute('data-id');

        // Invoke the callback function to confirm adding the spell
        props.clickCallback({ spellName: spellName, spellId: spellId });
    }

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Level</th>
                        <th>School</th>
                        <th>Cast Time</th>
                        <th>Range</th>
                        <th>Verbal</th>
                        <th>Somatic</th>
                        <th>Materials</th>
                        <th>Duration</th>
                        <th>Ritual</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody onClick={handleSpellClick}>
                    {
                        props.spells.map(spell => (
                            <Spell spell={spell} key={spell.id} />
                        ))
                    }
                </tbody>
            </table>
        </div>
    );
}

class AddSpell extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbookName: '',
            spellbookId: props.match.params.spellbookId,
            spellAdded: false,
            spells: []
        }

        this.handleSpellClick = this.handleSpellClick.bind(this);
    }

    componentDidMount() {
        // Promise.all([
        //     fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/name`),
        //     fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/nonmemberspells`)])
        //     .then(responses => {
        //         let data = [];
        //         let errors = [];
        //         if (responses[0].ok) {
        //             data.push(responses[0].json());
        //         } else {
        //             errors.push()
        //         }
        //     });
        
        // Fetch the spellbook's name.
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/name`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw 'Unable to retrieve spellbook name.';
                }
            })
            .then(obj => {
                this.setState(() => { return { spellbookName: obj.name } });
            })
            .catch((message) => { this.setState(() => { return { error: [message] }; }) });

        // Fetch the list of spells that are not part of the spellbook.
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/nonmemberspells`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw 'Unable to retrieve nonmember spells.';
                }
            })
            .then(obj => this.setState(() => { return { spells: obj }; }))
            .catch((message) => { this.setState(() => { return { error: [message] }; }) });
    }

    handleSpellClick(options) {
        const confirm = window.confirm(`Add ${options.spellName} to ${this.state.spellbookName}?`);
        if (confirm === true) {
            const requestBody = {
                spellId: parseInt(options.spellId)
            };
            fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/add`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(requestBody)
            })
                .then(response => {
                    if (response.ok) {
                        this.props.submitCallback();  // Update spellbook list
                        this.setState(() => { return { spellAdded: true }; });
                    } else {
                        throw response;
                    }
                })
                .catch(() => { });
        }
    }

    render() {
        if (this.state.spellAdded === true) {
            return (
                <Redirect to={`/Spellbook/Details/${this.state.spellbookId}`} />
            );
        }
        else {
            return (
                <div>
                    <h1>Add Spell to {this.state.spellbookName}</h1>
                    <ErrorMessages messages={this.state.error} />
                    <p>Click on a spell to add it to the spellbook.</p>
                    <SpellList spells={this.state.spells} clickCallback={this.handleSpellClick} />
                </div>
            );
        }
    }
}

export default AddSpell;