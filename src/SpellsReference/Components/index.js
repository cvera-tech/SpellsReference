import React, { Component } from 'react';
import ReactDOM from 'react-dom';

class App extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: []
        };
    }

    render() {
        return (
            <h3>Display Benches</h3>
        );
    }
}

ReactDOM.render(<App />, document.getElementById('root'));
