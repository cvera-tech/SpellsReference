import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect
} from "react-router-dom";

class Create extends Component {
  constructor(props) {
    super(props);

    this.state = {
      name: null,
      level: null,
      school: null,
      castingTime: null,
      range: null,
      verbal: null,
      somatic: null,
      duration: null,
      ritual: null,
      description: null,
      materials: null,
      toList: false
    };

    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    
  }

  handleSubmit(event) {
    event.preventDefault();
    const data = {
      name: event.target.name.value,
      level: parseInt(event.target.level.value),
      school: event.target.schoolOfMagic.value,
      castingTime: event.target.castingTime.value,
      range: event.target.range.value,
      verbal: event.target.verbal.checked,
      somatic: event.target.somatic.checked,
      duration: event.target.duration.value,
      ritual: event.target.ritual.checked,
      description: event.target.description.value,
      materials: event.target.materials.value
    };
    fetch('http://localhost:61211/api/spell', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
      .then(response => {
        this.setState({ toList: true });
      })
      .catch(error => {
      });
  }

  handleChange(event) {

  }

  render() {
    if (this.state.toList === true) {
      return (
        <Redirect to="/" />
      );
    }

    return (
      <div className="mt-2">
        <h2>Add Spell</h2>
        <form onSubmit={this.handleSubmit} onChange={this.handleChange}>
          <div className="form-group row">
            <div className="col-sm-3">
              <label htmlFor="name">Name</label>
              <input id="name" className="form-control" name="name" type="text" />
            </div>
            <div className="col-sm-1">
              <label htmlFor="level">Level</label>
              <input id="level" className="form-control" name="level" defaultValue="0" type="number" />
            </div>
            <div className="col-sm-2">
              <label htmlFor="schoolOfMagic">School</label>
              <select id="schoolOfMagic" className="form-control" defaultValue="0">
                <option>Abjuration</option>
                <option>Conjuration</option>
                <option>Divination</option>
                <option>Enchantment</option>
                <option>Evocation</option>
                <option>Illusion</option>
                <option>Necromancy</option>
                <option>Transmutation</option>
              </select>
            </div>
            <div className="col-sm-3">
              <label htmlFor="castingTime">Cast Time</label>
              <input id="castingTime" className="form-control" name="castingTime" type="text" />
            </div>
            <div className="col-sm-3">
              <label htmlFor="range">Range</label>
              <input id="range" className="form-control" name="range" type="text" />
            </div>
          </div>
          <div className="form-group row">
            <div className="col-xs-1 ml-2">
              <label htmlFor="verbal">Verbal</label>
              <input id="verbal" className="form-control" name="verbal" type="checkbox" />
            </div>
            <div className="col-xs-1 ml-2">
              <label htmlFor="somatic">Somatic</label>
              <input id="somatic" className="form-control" name="somatic" type="checkbox" />
            </div>
            <div className="col-sm-3">
              <label htmlFor="duration">Duration</label>
              <input id="duration" className="form-control" name="duration" type="text" />
            </div>
            <div className="col-xs-1 ml-2">
              <label htmlFor="ritual">Ritual</label>
              <input id="ritual" className="form-control" name="ritual" type="checkbox" />
            </div>
          </div>
          <div className="form-group row">
            <div className="col-sm-6">
              <label htmlFor="description">Description</label>
              <textarea id="description" className="form-control" name="description" type="text" />
            </div>
          </div>
          <div className="form-group row">
            <div className="col-sm-4">
              <label htmlFor="materials">Materials</label>
              <input id="materials" className="form-control" name="materials" type="text" />
            </div>
          </div>
          <div>
            <button id="submitButton" className="btn btn-success btn-lg" type="submit">Submit</button>
            <Link to="/" className="btn btn-outline-danger btn-lg ml-2">Cancel</Link>
          </div>
        </form>
      </div>
    );
  }
}

export default Create;