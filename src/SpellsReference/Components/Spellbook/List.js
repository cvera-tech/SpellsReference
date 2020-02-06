import React, { Component } from 'react';
import { Link } from "react-router-dom";

class Spellbook extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.spellbook.name}</td>
                <td>{this.props.spellbook.numberOfSpells}</td>
                <td><Link to={`/Spellbook/Details/${this.props.spellbook.id}`}>Details</Link></td>
            </tr>
        );
    }
}

class SpellbookList extends Component {
    render() {
        return (
            <div className="mt-4">
                <table className="table table-sm table-hover">
                    <thead className="thead thead-dark">
                        <tr>
                            <th>Name</th>
                            <th>Number of Spells</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.props.spellbooks.map(spellbook => (
                                <Spellbook spellbook={spellbook} key={spellbook.id} />
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

export default SpellbookList;