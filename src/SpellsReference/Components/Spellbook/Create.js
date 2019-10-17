import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';


class SpellbookCreate extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            redirectLink: null,
            success: null,
        };
    }

    // Bleeding edge technology right here
    handleChange = (event) => {
        this.setState({
            name: event.target.value
        })
    }

    handleSubmit = (event) => {
        const requestBody = {
            name: this.state.name
        };
        fetch('http://localhost:61211/api/spellbook', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestBody)
        })
            .then(response => {
                if (response.ok) {
                    const redirectLink = response.headers.get('location');
                    this.props.submitCallback();    // Update the spellbook list in the Index component
                    this.setState({
                        redirectLink: redirectLink
                    });
                } else {
                    throw response;
                }
            })
            .then(() => this.setState({ success: true }))
            .catch(() => this.setState({ success: false }));
        event.preventDefault();
    }

    render() {
        if (this.state.success === true) {
            return (
                <Redirect to={this.state.redirectLink} />
            );
        } else if (this.state.success === false){
            return (
                <div>
                    <h1>Create a Spellbook</h1>
                    <p>Unable to create spellbook.</p>
                    <form onSubmit={this.handleSubmit}>
                        <fieldset>
                            <label htmlFor='nameField'>Name</label>
                            <input type='text' id='nameField' onChange={this.handleChange} value={this.state.name} />
                        </fieldset>
                        <input type='submit' value='Creatify the Spellbook!' />
                    </form>
                </div>
            );
        } else {
            return (
                <div>
                    <h1>Create a Spellbook</h1>
                    <form onSubmit={this.handleSubmit}>
                        <fieldset>
                            <label htmlFor='nameField'>Name</label>
                            <input type='text' id='nameField' onChange={this.handleChange} value={this.state.name} />
                        </fieldset>
                        <input type='submit' value='Creatify the Spellbook!' />
                    </form>
                </div>
            );
        }

    }
}

export default SpellbookCreate;