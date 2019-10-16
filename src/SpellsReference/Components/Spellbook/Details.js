import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link,
    useParams
} from 'react-router-dom';
import SpellList from '../Spell/List';

function Spell(props) {
    return (
        <tr>
            <td>{props.spell.name}</td>
            <td>{props.spell.level}</td>
            <td>{props.spell.school}</td>
            <td>{props.spell.castingTime}</td>
            <td>{props.spell.range}</td>
            <td>{props.spell.verbal ? 'True' : 'False'}</td>
            <td>{props.spell.somatic ? 'True' : 'False'}</td>
            <td>{props.spell.materials}</td>
            <td>{props.spell.duration}</td>
            <td>{props.spell.ritual ? 'True' : 'False'}</td>
            <td>{props.spell.description}</td>
        </tr>
    );
}

class SpellbookDetails extends Component {
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
                if (response.ok) {  // response code 200 if fetch was successful
                    return response.json();
                }
                else {
                    this.setState({
                        success: false
                    });
                    throw response; // Why is this allowed
                }
            })
            .then(obj => this.setState({
                success: true,
                spellbook: obj
            }))
            .catch(() => { });   // Do nothing
    }

    render() {
        if (this.state.success === true) {
            return (
                <div>
                    <h1>Spellbook Details</h1>
                    <Link to={`/Spellbook/Details/${this.state.spellbookId}/AddSpell`}>Add Spell</Link>
                    <table>
                        <tbody>
                            <tr>
                                <td>Id</td>
                                <td>{this.state.spellbook.id}</td>
                            </tr>
                            <tr>
                                <td>Name</td>
                                <td>{this.state.spellbook.name}</td>
                            </tr>
                            <tr>
                                <td>Number of Spells</td>
                                <td>{this.state.spellbook.numberOfSpells}</td>
                            </tr>
                        </tbody>
                    </table>
                    <SpellList spells={this.state.spellbook.spells} />
                </div>
            );
        }
        else {
            return (
                <h1>Spellbook Details</h1>
            );
        }
    }
}

export default SpellbookDetails;