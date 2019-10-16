import React, { Component } from 'react';
import { Link } from "react-router-dom";

class Spell extends Component {
    componentDidMount() {
        document.getElementById('spellRow')
    }
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
                <td>{this.props.spell.description}</td>
            </tr>
        );
    }
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
                        {
                            this.props.spells.map(spell => (
                                <Spell spell={spell} key={spell.id} clickCallback={this.props.clickCallback} />
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

export default SpellList;