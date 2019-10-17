import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    Redirect
} from "react-router-dom";

function Spell({ spell }) {
    return (
        <tr data={`/Spell/Select/${spell.id}`}>
            <td>{spell.name}</td>
            <td>{spell.level}</td>
            <td>{spell.school}</td>
            <td>{spell.castingTime}</td>
            <td>{spell.range}</td>
            <td>{spell.verbal ? 'True' : 'False'}</td>
            <td>{spell.somatic ? 'True' : 'False'}</td>
            <td>{spell.materials}</td>
            <td>{spell.duration}</td>
            <td>{spell.ritual ? 'True' : 'False'}</td>
        </tr>
    );
}

class Index extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: [],
            filteredSpells: [],
            previousSort: null,
            spellSelected: false,
            spellRedirect: null

        };

        this.handleFilterChange = this.handleFilterChange.bind(this);
        this.handleHeaderClick = this.handleHeaderClick.bind(this);
        this.handleBodyClick = this.handleBodyClick.bind(this);
        this.mySort = this.mySort.bind(this);
    }

    handleHeaderClick = (event) => {
        const th = event.target;
        const sortByColumn = th.getAttribute('data-columnname');
        const columnType = th.getAttribute('data-columntype');

        const getColumnText = (text) => {
            const containsUpArrow = text.includes('▲');
            const containsDownArrow = text.includes('▼');
            if (containsUpArrow || containsDownArrow) {
                return text.substring(0, text.length - 2)
            } else {
                return text;
            }
        };
        debugger;
        const columnText = getColumnText(th.innerText);

        if (this.state.previousSort === sortByColumn && !(this.state.previousSortState === null)) {
            if (this.state.previousSortState === 'descending') {
                th.innerText = columnText + ' ▲';
                this.setState((state) => {
                    return {
                        filteredSpells: this.mySort(state.filteredSpells, sortByColumn, columnType, 'ascending'),
                        previousSortState: "ascending",
                        previousSort: sortByColumn
                    };
                });
            }
            else {
                th.innerText = columnText;
                this.setState((state) => {
                    return {
                        filteredSpells: this.mySort(state.filteredSpells, sortByColumn, columnType, 'none'),
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
                    filteredSpells: this.mySort(state.filteredSpells, sortByColumn, columnType, 'descending'),
                    previousSortState: "descending",
                    previousSort: sortByColumn
                };
            });
        }
    }

    handleBodyClick = (event) => {
        const td = event.target;
        const tr = event.target.parentNode;
        const redirectLink = tr.getAttribute('data');

        this.setState({
            spellSelected: true,
            spellRedirect: redirectLink
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

    handleFilterChange = (event) => {
        const stringFilter = event.target.value;

        let uniqueStringFilteredSpells = [];
        
        if (stringFilter !== '') {
            let allStringFilteredSpells = [];

            const nameFilteredSpells = this.state.spells
                .filter(spell => spell.name.toLowerCase().includes(stringFilter.toLowerCase()))
            const castingTimeFilteredSpells = this.state.spells
                .filter(spell => spell.castingTime.toLowerCase().includes(stringFilter.toLowerCase()))
            const rangeFilteredSpells = this.state.spells
                .filter(spell => spell.range.toLowerCase().includes(stringFilter.toLowerCase()))
            const durationFilteredSpells = this.state.spells
                .filter(spell => spell.duration.toLowerCase().includes(stringFilter.toLowerCase()))
            const materialsFilteredSpells = this.state.spells
                .filter(spell => spell.materials.toLowerCase().includes(stringFilter.toLowerCase()))

            allStringFilteredSpells.push.apply(allStringFilteredSpells, nameFilteredSpells);
            allStringFilteredSpells.push.apply(allStringFilteredSpells, castingTimeFilteredSpells);
            allStringFilteredSpells.push.apply(allStringFilteredSpells, rangeFilteredSpells);
            allStringFilteredSpells.push.apply(allStringFilteredSpells, durationFilteredSpells);
            allStringFilteredSpells.push.apply(allStringFilteredSpells, materialsFilteredSpells);

            uniqueStringFilteredSpells = [...new Set(allStringFilteredSpells)];

            this.setState({ filteredSpells: uniqueStringFilteredSpells });
        }
        else {
            this.setState({ filteredSpells: this.state.spells });
        }
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spell')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    spells: data.spells,
                    filteredSpells: data.spells,
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
            <div className="full-page mt-2">
                <h1>Spell Index Page</h1>
                <div>
                    <div>
                        <Link to="/Spell/Create" className="btn btn-primary btn-lg mb-2">Create Spell</Link>
                        <Link to="/Spell/Filter" className="btn btn-outline-secondary btn-lg mb-2 ml-2">Filter</Link>
                    </div>
                    <div className="form-group row" onChange={this.handleFilterChange}>
                        <div className="col-sm-3">
                            <input id="stringFilter" className="form-control" placeholder="Keywords. . ." type="text"></input>
                        </div>
                    </div>
                    <table id="spellTable" className="table table-sm table-hover">
                        <thead id="thead" className="thead thead-dark" onClick={this.handleHeaderClick}>
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
                        <tbody id="tbody" onClick={this.handleBodyClick}>
                            {this.state.filteredSpells.map(spell => (
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