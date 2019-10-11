import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Spells from './Spells';

function About() {
    return (
        <h3>About</h3>
    );
}

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
                            <Link to="/About">About</Link>
                        </li>
                    </ul>
                </nav>
                <Switch>
                    <Route path="/About">
                        <About />
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