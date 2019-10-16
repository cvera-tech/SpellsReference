import React, { Component } from 'react';
import {
    Route,
    Link
} from "react-router-dom";
import SpellbookList from './List';
import SpellbookCreate from './Create';
import SpellbookDetails from './Details';
import AddSpell from './AddSpell';

class SpellbookIndex extends Component {
    constructor(props) {
        super(props);
        this.state = {
            spellbooks: []
        };
    }

    fetchData = () => {
        fetch('http://localhost:61211/api/spellbook')
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    throw response;
                }
            })
            .then(obj => {
                this.setState({
                    spellbooks: obj
                })
            })
            .catch(() => { });   // Do nothing
    };

    componentDidMount() {
        this.fetchData();
    }

    render() {
        return (
            <div>
                <h1>Hello, this is the Spellbook Index.</h1>
                <ul>
                    <li><Link to="/Spellbook">Spellbook Index</Link></li>
                    <li><Link to="/Spellbook/Create">Create a Spellbook!</Link></li>
                </ul>
                <Route path="/Spellbook/Create">
                    <SpellbookCreate submitCallback={this.fetchData} />
                </Route>
                <Route path="/Spellbook/Details/:spellbookId/AddSpell" 
                    render={(props) =>
                        <AddSpell {...props} callback={this.fetchData} />
                    } />
                <Route exact path="/Spellbook/Details/:spellbookId" component={SpellbookDetails} />
                <Route exact path="/Spellbook">
                    <SpellbookList spellbooks={this.state.spellbooks} />
                </Route>
            </div>
        );
    }
}

export default SpellbookIndex;