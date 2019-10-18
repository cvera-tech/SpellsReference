import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import ErrorMessages from '../ErrorMessages';
import { Spell, SpellList } from './Spell';
import config from '../config';

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
        //     fetch(`${config.apiBaseUrl}/api/spellbook/${this.state.spellbookId}/name`),
        //     fetch(`${config.apiBaseUrl}/api/spellbook/${this.state.spellbookId}/nonmemberspells`)])
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
        fetch(`${config.apiBaseUrl}/api/spellbook/${this.state.spellbookId}/name`)
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
        fetch(`${config.apiBaseUrl}/api/spellbook/${this.state.spellbookId}/nonmemberspells`)
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
            fetch(`${config.apiBaseUrl}/api/spellbook/${this.state.spellbookId}/add`, {
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