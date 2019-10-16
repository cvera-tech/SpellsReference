import React, { Component } from 'react';
import SpellList from '../Spell/List';

class AddSpell extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedSpell: null,
            spells: []
        }
    }

    componentDidMount() {
        fetch(`http://localhost:61211/api/spellbook/${this.props.spellbookId}/nonmemberspells`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            })
            .then(obj => this.setState({ spells: obj }))
            .catch(() => {});
    }

    render() {
        if (this.state.selectedSpell !== null) {
            return null;
            // Redirect
        }
        return (
            <SpellList spells={this.state.spells} />
        );
    }
}

export default AddSpell;