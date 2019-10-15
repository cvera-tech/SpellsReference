import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link,
    useParams
} from 'react-router-dom';

class SpellbookDetails extends Component {
    constructor(props) {
        super(props);

        this.state = {
            spellbookId: props.match.params.spellbookId,
            spellbook: null,
            success: null
        };
    }

    componentDidMount() {
        fetch(`http://localhost:61211/api/spellbook/${this.state.spellbookId}`)
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    this.setState({
                        success: false
                    });
                    throw "What";
                }
            })
            .then(obj => this.setState({
                success: true,
                spellbook: obj
            }))
            .catch(msg => console.log(msg));
    }

    render() {
        if (this.state.success === true) {
            return (
                <div>
                    <h1>Hello, this is a Spellbook's details.</h1>
                    <table>
                        <tbody>
                            <tr>
                                <td>Id</td>
                                <td>{this.state.spellbook.id}</td>
                            </tr>
                            <tr>
                                <td>Name</td>
                                <td>{this.state.spellbook.name}</td>
                            </tr>
                            <tr>
                                <td>Number of Spells</td>
                                <td>{this.state.spellbook.numberOfSpells}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            );
        }
        else {
            return (
                <h1>Something wicked this way comes.</h1>
            );
        }
    }
}

export default SpellbookDetails;