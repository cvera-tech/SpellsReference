import React, { Component } from 'react';
import ReactDOM from 'react-dom';

function Spell(props) {
    return (
        <tr>
            <td>{props.spell.name}</td>
            <td>{props.spell.level}</td>
            <td>{props.spell.school}</td>
            <td>{props.spell.castingTime}</td>
            <td>{props.spell.range}</td>
            <td>{props.spell.verbal.toString().charAt(0).toUpperCase() + props.spell.verbal.toString().slice(1)}</td>
            <td>{props.spell.somatic.toString().charAt(0).toUpperCase() + props.spell.somatic.toString().slice(1)}</td>
            <td>{props.spell.materials}</td>
            <td>{props.spell.duration}</td>
            <td>{props.spell.ritual.toString().charAt(0).toUpperCase() + props.spell.ritual.toString().slice(1)}</td>
            <td>{props.spell.description}</td>
        </tr>
    );
}

class App extends Component {

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

ReactDOM.render(<App />, document.getElementById('root'));
