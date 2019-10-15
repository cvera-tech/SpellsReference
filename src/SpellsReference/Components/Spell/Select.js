import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect
} from "react-router-dom";

class Select extends Component {
  constructor(props) {
    super(props);

    this.state = { 
      id: this.props.match.params.id,
      spell: null,
      success: false,
      toList: false
    };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  componentDidMount() {
    fetch(`http://localhost:61211/api/spell/${this.props.match.params.id}`)
      .then(response => {
        return response.json();
      })
      .then(data => {
        this.setState({
          spell: data.spell,
          success: true
        });
      })
      .catch(console.log("Catch"))
  }

  handleSubmit(event) {
    event.preventDefault();
  }

  handleChange(event) {
    event.preventDefault();
  }

  render() {
    if (this.state.toList === true) {
      return (
        <Redirect to="/" />
      );
    }

    console.log(this.state.spell);
    if(this.state.success === true) {
      return (
        <div className="mt-2">
          <h2>Select Spell</h2>
          <form onSubmit={this.handleSubmit} onChange={this.handleChange}>
            <div className="form-group row">
              <div className="col-sm-3">
                <label htmlFor="name">Name</label>
                <input id="name" className="form-control" name="name" defaultValue={this.state.spell.name} type="text" disabled />
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
              <button id="editButton" className="btn btn-success btn-lg" type="submit">Edit</button>
              <Link to="/" className="btn btn-outline-danger btn-lg ml-2">Cancel</Link>
            </div>
          </form>
        </div>
      );
    }

    return(
      <h1>Error</h1>
    );
  }
}

export default Select;