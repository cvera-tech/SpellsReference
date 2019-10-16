import React, { Component } from 'react';
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
        </tr>
    );
}

class Index extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: [],
            previousSort: null,
            spellSelected: false,
            spellRedirect: null
        };

        this.mySort = this.mySort.bind(this);
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spell')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    spells: data.spells
                });
            });

        document.getElementById('tbody').addEventListener('click', (event) => {
            const td = event.target;
            const tr = event.target.parentNode;
            const redirectLink = tr.getAttribute('data');

            this.setState({
                spellSelected: true,
                spellRedirect: redirectLink
            });
        });

        const getColumnText = (text) => {
            const containsUpArrow = text.includes('▲');
            const containsDownArrow = text.includes('▼');
            if (containsUpArrow || containsDownArrow) {
                return text.substring(0, text.length-2)
            } else {
                return text;
            }
        };

        document.getElementById('thead').addEventListener('click', (event) => {
            const th = event.target;
            const sortByColumn = th.getAttribute('data-columnname');
            const columnType = th.getAttribute('data-columntype');

            const columnText = getColumnText(th.innerText);

            if (this.state.previousSort === sortByColumn && !(this.state.previousSortState === null)) {
                if (this.state.previousSortState === 'descending') {
                    th.innerText = columnText + ' ▲';
                    this.setState((state) => {
                        return {
                            spells: this.mySort(state.spells, sortByColumn, columnType, 'ascending'),
                            previousSortState: "ascending",
                            previousSort: sortByColumn
                        };
                    });
                }
                else {
                    th.innerText = columnText;
                    this.setState((state) => {
                        return {
                            spells: this.mySort(state.spells, sortByColumn, columnType, 'none'),
                            previousSortState: null,
                            previousSort: sortByColumn
                        };
                    });
                }
            }
            else {
                document.getElementById('name').innerText = 'Name';
                document.getElementById('level').innerText = 'Level';
                document.getElementById('school').innerText = 'School';
                document.getElementById('castingTime').innerText = 'Cast Time';
                document.getElementById('range').innerText = 'Range';
                document.getElementById('verbal').innerText = 'Verbal';
                document.getElementById('somatic').innerText = 'Somatic';
                document.getElementById('duration').innerText = 'Duration';
                document.getElementById('materials').innerText = 'Materials';
                document.getElementById('ritual').innerText = 'Ritual';

                th.innerText = columnText + ' ▼';
                this.setState((state) => {
                    return {
                        spells: this.mySort(state.spells, sortByColumn, columnType, 'descending'),
                        previousSortState: "descending",
                        previousSort: sortByColumn
                    };
                });
            }
        });
    }

    mySort(list, columnName, columnType, direction) {
        if (direction === 'descending') {
            if (columnType === 'string') {
                return list.sort(function (a, b) {
                    const x = a[columnName].toLowerCase();
                    const y = b[columnName].toLowerCase();
                    if (x < y) { return -1; }
                    if (x > y) { return 1; }
                    return 0;
                });
            }
            else {
                return list.sort(function (a, b) {
                    return a[columnName] - b[columnName];
                });
            }
        }
        else if (direction === 'ascending') {
            if (columnType === 'string') {
                return list.sort(function (a, b) {
                    const x = a.name.toLowerCase();
                    const y = b.name.toLowerCase();
                    if (x > y) { return -1; }
                    if (x < y) { return 1; }
                    return 0;
                });
            } 
            else {
                return list.sort(function (a, b) {
                    return b[columnName] - a[columnName];
                });
            }
        }
        else {
            return list.sort(function (a, b) {
                return a.id - b.id;
            });
        }
    }

    render() {
        if (this.state.spellSelected === true) {
            return (
                <Redirect to={this.state.spellRedirect} />
            );
        }
        return (
            <div className="full-page">
                <h1>Spell Index Page</h1>
                <div>
                    <Link to="/Spell/Create" className="btn btn-primary btn-lg mb-2">Create Spell</Link>
                    <Link to="/Spell/Filter" className="btn btn-outline-secondary btn-lg mb-2 ml-2">Filter</Link>
                    <table id="spellTable" className="table table-sm table-hover">
                        <thead id="thead" className="thead thead-dark">
                            <tr>
                                <th id="name" data-columnname="name" data-columntype="string">Name</th>
                                <th id="level" data-columnname="level" data-columntype="int">Level</th>
                                <th id="school" data-columnname="school" data-columntype="string">School</th>
                                <th id="castingTime" data-columnname="castingTime" data-columntype="string">Cast Time</th>
                                <th id="range" data-columnname="range" data-columntype="string">Range</th>
                                <th id="verbal" data-columnname="verbal" data-columntype="bool">Verbal</th>
                                <th id="somatic" data-columnname="somatic" data-columntype="bool">Somatic</th>
                                <th id="materials" data-columnname="materials" data-columntype="string">Materials</th>
                                <th id="duration" data-columnname="duration" data-columntype="string">Duration</th>
                                <th id="ritual" data-columnname="ritual" data-columntype="bool">Ritual</th>
                            </tr>
                        </thead>
                        <tbody id="tbody">
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