import React, { Component } from 'react';
import { Link } from "react-router-dom";

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

class SpellList extends Component {
    render() {
        return (
            <div>
                <table>
                    <thead>
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
                        {this.props.spells.map(spell => (
                            <Spell spell={spell} key={spell.id} />
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default SpellList;