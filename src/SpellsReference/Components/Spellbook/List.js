import React, { Component } from 'react';

class Spellbook extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.spellbook.name}</td>
                <td>{this.props.spellbook.numberOfSpells}</td>
                <td>Button!</td>
            </tr>
        );
    }
}

class SpellbookList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            spellbooks: []
        };
    }

    renderSpellbooks() {
        const rows = [];
        for (spellbook of this.state.spellbooks) {
            rows.push(
                <Spellbook spellbook={spellbook} key={spellbook.id} />
            );
        }
        return rows;
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spellbook')
            .then(response => response.json())
            .then(obj => this.setState({
                spellbooks: obj
            }));
    }

    render() {
        return (
            <div>
                <h1>Hello, this is a list of Spellbooks.</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Number of Spells</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.spellbooks.map(spellbook => (
                            <Spellbook spellbook = {spellbook} key = {spellbook.id} />
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default SpellbookList;