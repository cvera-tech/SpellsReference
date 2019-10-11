import React, { Component } from 'react';

function Spell(props) {
    return (
        <tr>
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

class Spells extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: []
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
    }

    render() {
        return (
            <div className="mt-2">
                <h1>Spell Index Page</h1>
                <div>
                <a className="btn btn-primary btn-lg mb-2" href="/Spell/Create">Create Spell</a>
                    <table className="table table-sm table-hover">
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

export default Spells;