import React, { Component } from 'react';
import {
    Link,
    Redirect
} from 'react-router-dom';
import { SpellList } from '../Spell/List';

export default class SpellbookDetails extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbookId: props.match.params.spellbookId,
            spellbook: null,
            success: null
        };
    }

    componentDidMount() {
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    this.setState({
                        success: false
                    });
                    throw response;
                }
            })
            .then(obj => {
                this.props.spellbookNameCallback(obj.name);  // Pass spellbook name to Index component
                this.setState({
                    success: true,
                    spellbook: obj
                })
            })
            .catch(() => { });
    }

    render() {
        if (this.state.success === true) {
            return (
                <div>
                    <h1>{this.state.spellbook.name}</h1>
                    <div>
                        <Link to={`/Spellbook/Details/${this.state.spellbookId}/AddSpell`} className="btn btn-outline-success">Add Spell</Link>
                        <Link to={`/Spellbook/Details/${this.state.spellbookId}/RemoveSpell`} className="btn btn-outline-danger ml-2">Remove Spell</Link>
                    </div>
                    <SpellList spells={this.state.spellbook.spells} />
                </div>
            );
        } else if (this.state.success === false) {
            alert("Invalid spellbook ID.");
            return (
                <Redirect to="/Spellbook" />
            )
        }
        else {
            return (
                <h1>Spellbook Details</h1>
            );
        }
    }
}