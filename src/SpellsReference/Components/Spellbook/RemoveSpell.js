import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { Spell, SpellList } from './Spell';
import ErrorMessages from '../ErrorMessages';

// This component is very similar to AddSpell.
// Perhaps they can be merged into one component.
export default class RemoveSpell extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbookName: '',
            spellbookId: props.match.params.spellbookId,
            spellRemoved: null,
            spells: []
        }

        this.handleSpellClick = this.handleSpellClick.bind(this);
    }

    componentDidMount() {
        // Fetch the spellbook.
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw 'Unable to retrieve spellbook.';
                }
            })
            .then(obj => {
                this.setState(() => { return { spellbookName: obj.name, spells: obj.spells } });
            })
            .catch((message) => { this.setState(() => { return { error: [message] }; }) });
    }

    handleSpellClick(options) {
        const confirm = window.confirm(`Remove ${options.spellName} from ${this.state.spellbookName}?`);
        if (confirm === true) {
            const requestBody = {
                spellId: parseInt(options.spellId)
            };
            fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}/remove`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(requestBody)
            })
                .then(response => {
                    if (response.ok) {
                        this.props.submitCallback(); // Update spellbook list
                        this.setState(() => { return { spellRemoved: true }; });
                    } else {
                        throw response;
                    }
                })
                .catch(() => { });
        }
    }

    render() {
        if (this.state.spellRemoved === true) {
            return (
                <Redirect to={`/Spellbook/Details/${this.state.spellbookId}`} />
            );
        } else {
            return (
                <div>
                    <h1>Remove Spell from {this.state.spellbookName}</h1>
                    <ErrorMessages messages={this.state.error} />
                    <p>Click on a spell to remove it from the spellbook.</p>
                    <SpellList spells={this.state.spells} clickCallback={this.handleSpellClick} />
                </div>
            )
        }
    }
}