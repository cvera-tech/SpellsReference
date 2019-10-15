﻿import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Index from './Spell/Index';
import Create from './Spell/Create';
import Filter from './Spell/Filter';

function App() {
    return (
        <Router>
            <div>
                <nav>
                    <Link to="/">Cheat Home</Link>
                    <p>THIS IS A REACT PAGE</p>
                </nav>
                <Switch>
                    <Route path="/Spell/Filter">
                        <Filter />
                    </Route>
                    <Route path="/Spell/Create">
                        <Create />
                    </Route>
                    <Route path="/">
                        <Index />
                    </Route>

                </Switch>
            </div>
        </Router>
    );
}

export default App;