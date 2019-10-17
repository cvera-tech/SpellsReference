import React, { Component } from 'react';
import {
    Route,
    Link
} from "react-router-dom";
import SpellbookList from './List';
import SpellbookCreate from './Create';
import SpellbookDetails from './Details';
import AddSpell from './AddSpell';
import ErrorMessages from '../ErrorMessages';

class SpellbookIndex extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: [],
            spellbooks: [],
            selectedSpellbookName: ''
        };

        this.fetchSpellbooks = this.fetchSpellbooks.bind(this);
        this.setSelectedSpellbook = this.setSelectedSpellbook.bind(this);
    }

    fetchSpellbooks() {
        fetch('http://localhost:61211/api/spellbook')
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw "Unable to retrieve spellbooks";
                }
            })
            .then(obj => {
                this.setState(() => { return { spellbooks: obj, error: [] } })
            })
            .catch(message => this.setState(() => { return { error: [message] } }));
    }

    setSelectedSpellbook(spellbookName) {
        this.setState(() => {
            return { selectedSpellbookName: spellbookName };
        });
    };

    componentDidMount() {
        this.fetchSpellbooks();
    }

    render() {
        let output = (
            <div>
                <h1>Hello, this is the Spellbook Index.</h1>

                <ul>
                    <li><Link to="/Spellbook">Spellbook Index</Link></li>
                    <li><Link to="/Spellbook/Create">Create a Spellbook!</Link></li>
                </ul>
                <ErrorMessages messages={this.state.error} />
                <div>
                    <Route path="/Spellbook/Create">
                        <SpellbookCreate submitCallback={this.fetchSpellbooks} />
                    </Route>
                    <Route path="/Spellbook/Details/:spellbookId/AddSpell"
                        render={(props) =>
                            <AddSpell {...props}
                                submitCallback={this.fetchSpellbooks}
                                spellbookName={this.state.selectedSpellbookName} />
                        } />
                    <Route exact path="/Spellbook/Details/:spellbookId"
                        render={(props) =>
                            <SpellbookDetails {...props}
                                spellbookNameCallback={this.setSelectedSpellbook} />
                        } />
                    <Route exact path="/Spellbook">
                        <SpellbookList spellbooks={this.state.spellbooks} />
                    </Route>
                </div>
            </div>
        );
        return output;
    }
}

export default SpellbookIndex;