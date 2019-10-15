import React, { Component } from 'react';

class SpellbookDetails extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbook: null
        };
    }

    componentDidMount() {
        console.log(this.props.match.params.spellbookId);
        // fetch(`http://localhost:61211/api/spellbook/${this.props.match.params.id}`)
    }

    render() {
        return (<h1>Hello, this is a form to create a Spellbook.</h1>);
    }
}

export default SpellbookDetails;