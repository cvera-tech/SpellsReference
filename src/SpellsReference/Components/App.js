import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Spells from './Spells';
import CreateSpell from './CreateSpell';

function App() {
    return (
        <Router>
            <div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/">Spells</Link>
                        </li>
                        <li>
                            <Link to="/Spell/Create">Create Spell</Link>
                        </li>
                    </ul>
                </nav>
                <Switch>
                    <Route path="/Spell/Create">
                        <CreateSpell />
                    </Route>
                    <Route path="/">
                        <Spells />
                    </Route>
                </Switch>
            </div>
        </Router>
    );
}

export default App;