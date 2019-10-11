import React, { Component } from 'react';
import ReactDOM from 'react-dom';

function Spell(props) {
    return (
      <tr>
        <td>{props.spell.name}</td>
        <td>{props.spell.level}</td>
        <td>{props.spell.school}</td>
        <td>{props.spell.castingTime}</td>
        <td>{props.spell.range}</td>
        <td>{props.spell.verbal.toString()}</td>
        <td>{props.spell.somatic.toString()}</td>
        <td>{props.spell.materials}</td>
        <td>{props.spell.duration}</td>
        <td>{props.spell.ritual.toString()}</td>
        <td>{props.spell.description}</td>
      </tr>
    );
}

class App extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: []
        };
    }

    componentDidMount() {
        fetch('http://localhost:61211/api/spell')
            .then(response => response.json())
            .then(data => {
                console.log(data)
                this.setState({
                    spells: data.spells
                });
            });
    }

    render() {
        return (
          <div>
            <h3>Display Spells</h3>
            <div>
              <table htmlclass="table table-sm">
                <thead htmlclass="thead thead-dark">
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
                  {this.state.spells.map(spell => (
                      <Spell spell={spell} key={spell.id} />
                  ))}
            </tbody>
          </table>
        </div>
      </div>
    );
            }
}

ReactDOM.render(<App />, document.getElementById('root'));
