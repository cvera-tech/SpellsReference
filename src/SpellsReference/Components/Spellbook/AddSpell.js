import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

class Spell extends Component {
    constructor(props) {
        super(props);
    }
    componentDidMount() {
        console.log('spell mounted');
    }
    render() {
        return (
            <tr data-name={this.props.spell.name} data-id={this.props.spell.id}>
                <td>{this.props.spell.name}</td>
                <td>{this.props.spell.level}</td>
                <td>{this.props.spell.school}</td>
                <td>{this.props.spell.castingTime}</td>
                <td>{this.props.spell.range}</td>
                <td>{this.props.spell.verbal ? 'True' : 'False'}</td>
                <td>{this.props.spell.somatic ? 'True' : 'False'}</td>
                <td>{this.props.spell.materials}</td>
                <td>{this.props.spell.duration}</td>
                <td>{this.props.spell.ritual ? 'True' : 'False'}</td>
                <td>{this.props.spell.description}</td>
            </tr>
        );
    }
}

class SpellList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            spellSelected: false
        }
    }

    componentDidMount() {
        document.getElementById('spellRows').addEventListener('click', (event) => {
            const tr = event.target.parentNode;
            const spellName = tr.getAttribute('data-name');
            const spellId = tr.getAttribute('data-id');
            this.props.clickCallback({ spellName: spellName, spellId: spellId });
        });
    }
    render() {
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
                    <tbody id="spellRows">
                        {
                            this.props.spells.map(spell => (
                                <Spell spell={spell} key={spell.id} />
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

class AddSpell extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbookName: null,
            spellbookId: props.match.params.spellbookId,
            spellAdded: false,
            spells: []
        }

        this.handleSpellClick = this.handleSpellClick.bind(this);
    }

    componentDidMount() {
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            })
            .then(obj => {
                this.setState((prevState) => { return { spellbookName: obj.name } });
            })
            .catch(() => { });

        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/nonmemberspells`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            })
            .then(obj => this.setState((prevState) => { return { spells: obj } }))
            .catch(() => { });
    }

    handleSpellClick(options) {
        const confirm = window.confirm(`Add ${options.spellName} to ${this.state.spellbookName}?`);
        if (confirm === true) {
            debugger;
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
                        this.setState((prevState) => {
                            return {
                                spellAdded: true
                            };
                        });
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
                    <p>Click on a spell to add it to the spellbook.</p>
                    <SpellList spells={this.state.spells} clickCallback={this.handleSpellClick} />
                </div>
            );
        }
    }
}

export default AddSpell;