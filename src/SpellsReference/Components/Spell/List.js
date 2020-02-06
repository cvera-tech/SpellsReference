import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class Spell extends Component {
    render() {
        return (
            <tr id="spellRow">
                <td>{this.props.spell.name}</td>
                <td>{this.props.spell.level}</td>
                <td>{this.props.spell.school}</td>
                <td>{this.props.spell.castingTime}</td>
                <td>{this.props.spell.range}</td>
                <td>{this.props.spell.verbal ? 'True' : 'False'}</td>
                <td>{this.props.spell.somatic ? 'True' : 'False'}</td>
                <td>{this.props.spell.materials}</td>
                <td>{this.props.spell.duration}</td>
                <td>{this.props.spell.ritual ? 'True' : 'False'}</td>
                <td><Link to={`/Spell/Select/${this.props.spell.id}`}>Details</Link></td>
            </tr>
        );
    }
}

export class SpellList extends Component {
    render() {
        return (
            <div>
                <table className="table table-sm table-hover mt-2">
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
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.props.spells.map(spell => (
                                <Spell spell={spell} key={spell.id} />
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}
