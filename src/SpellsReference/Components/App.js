import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Index from './Spell/Index';
import Create from './Spell/Create';
import Filter from './Spell/Filter';

import SpellbookIndex from './Spellbook/Index';

function App() {
    return (
        <Router>
            <div>
                <nav>
                    <Link to="/React/Index">Cheat Home</Link>
                    <Link to="/Spellbook">Spellbooks!</Link>
                </nav>
                <Switch>
                    <Route path="/Spell/Filter">
                        <Filter />
                    </Route>
                    <Route path="/Spell/Create">
                        <Create />
                    </Route>
                    <Route path="/React/Index">
                        <Index />
                    </Route>
                    <Route path="/Spellbook">
                        <SpellbookIndex />
                    </Route>

                </Switch>
            </div>
        </Router>
    );
}

export default App;