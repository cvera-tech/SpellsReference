﻿import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    Redirect
} from "react-router-dom";

function Spell(props) {
    return (
        <tr data={`/Spell/Select/${props.spell.id}`}>
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

class Index extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: [],
            spellSelected: false,
            spellRedirect: null
        };
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spell')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    spells: data.spells
                });
            });

        document.getElementById('spellTable').addEventListener('click', (event) => {
            const td = event.target;
            const tr = event.target.parentNode;
            const redirectLink = tr.getAttribute('data');

            this.setState({
                spellSelected: true,
                spellRedirect: redirectLink
            });
        });
    }

    render() {
        if (this.state.spellSelected === true) {
            return (
                <Redirect to={this.state.spellRedirect} />
            );
        }
        return (
            <div className="mt-2">
                <h1>Spell Index Page</h1>
                <div>
                    <Link to="/Spell/Create" className="btn btn-primary btn-lg mb-2">Create Spell</Link>
                    <Link to="/Spell/Filter" className="btn btn-outline-secondary btn-lg mb-2 ml-2">Filter</Link>
                    <table id="spellTable" className="table table-sm table-hover">
                        <thead className="thead thead-dark">
                            <tr>
                                <th>Name</th>
                                <th>Level</th>
                                <th>School</th>
                                <th>Cast Time</th>
                                <th>Range</th>
                                <th>Verbal</th>
                                <th>Somatic</th>
                                <th>Materials</th>
                                <th>Duration</th>
                                <th>Ritual</th>
                                <th>Description</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.spells.map(spell => (
                                <Spell spell={spell} key={spell.id} />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

export default Index;