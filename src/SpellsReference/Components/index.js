import React, { Component } from 'react';
import ReactDOM from 'react-dom';

//function Spell(props) {
//    return (
//      <tr>
//        <td>{props.spell.Name}</td>
//        <td>{props.spell.Level}</td>
//        <td>{props.spell.School}</td>
//      </tr>
//    );
//}

class App extends Component {

    constructor(props) {
        super(props);

        this.state = {
            spells: [{name: 'mySpell', id: 1}]
        };
    }

    //componentDidMount() {
    //    const obj = getList();
    //    this.setState({
    //        spells: obj
    //    });
    //    debugger;
    //}

    //async getList() {
    //    const response = await fetch('http://localhost:61211/api/spell');
    //    const obj = await response.json();
    //    return obj;
    //}

    render() {
        return (
          <div>
            <h3>Display Benches</h3>
            <div>
              <h1>Benches</h1>
              <table>
                <thead>
                  <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Seats</th>
                  </tr>
                </thead>
                <tbody>
                  {this.state.spells.map(spell => (
                    <tr key = {spell.id}><td>{spell.name}</td></tr>
                  ))}
            </tbody>
          </table>
        </div>
      </div>
    );
            }
}

ReactDOM.render(<App />, document.getElementById('root'));
