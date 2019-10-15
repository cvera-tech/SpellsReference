import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    useRouteMatch
} from "react-router-dom";
import SpellbookList from './List';
import SpellbookCreate from './Create';
import SpellbookDetails from './Details';

class SpellbookIndex extends Component {
    constructor(props) {
        super(props);
        this.state = {
            spellbooks = []
        };
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spellbook')
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    throw "Unable to fetch spellbooks";
                }
            })
            .then(obj => {
                this.setState({
                    spellbooks: obj
                })
            })
            .catch(() => {});   // Do nothing
    }

    render() {
        return (
            <div>
                <h1>Hello, this is the Spellbook Index.</h1>
                <ul>
                    <li><Link to={`/Spellbook`}>Spellbook Index</Link></li>
                    <li><Link to={`/Spellbook/Create`}>Create a Spellbook!</Link></li>
                </ul>
                    <Route path={`/Spellbook/Create`}>
                        <SpellbookCreate />
                    </Route>
                    <Route path="/Spellbook/Details/:spellbookId" component={SpellbookDetails} />
                    {/* 
                    <Route path="/Spellbook/Details/:spellbookId" >
                        <SpellbookDetails />
                    </Route>
                     */}
                    <Route exact path={`/Spellbook`}>
                        <SpellbookList spellbooks={this.state.spellbooks} />
                    </Route>
            </div>
        );
    }
}

export default SpellbookIndex;