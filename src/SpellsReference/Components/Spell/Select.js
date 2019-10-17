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

            success: false,
            toList: false
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.toggleFormLock = this.toggleFormLock.bind(this);
    }

    componentDidMount() {
        fetch(`http://localhost:61211/api/spell/${this.props.match.params.id}`)
            .then(response => {
                return response.json();
            })
            .then(data => {
                this.setState({
                    name: data.spell.name,
                    level: data.spell.level,
                    school: data.spell.school,
                    castingTime: data.spell.castingTime,
                    range: data.spell.range,
                    verbal: data.spell.verbal,
                    somatic: data.spell.somatic,
                    duration: data.spell.duration,
                    ritual: data.spell.ritual,
                    description: data.spell.description,
                    materials: data.spell.materials,

                    success: true
                });
            })
    }

    toggleFormLock() {
        const submitButton = document.getElementById('submitButton');
        const editButton = document.getElementById('editButton');
        const deleteButton = document.getElementById('deleteButton');
        const inputs = document.getElementsByClassName('inputField');

        if (submitButton.hidden === true) {
            for (let input of inputs) {
                input.disabled = false;
            }
            submitButton.hidden = false;
            editButton.hidden = true;
            deleteButton.hidden = true;
        }
        else {
            for (let input of inputs) {
                input.disabled = true;
            }
            submitButton.hidden = true;
            editButton.hidden = false;
            deleteButton.hidden = false;
        }
    }

    handleSubmit(event) {
        event.preventDefault();

        const editedSpell = {
            name: this.state.name,
            level: parseInt(this.state.level),
            school: this.state.school,
            castingTime: this.state.castingTime,
            range: this.state.range,
            verbal: this.state.verbal,
            somatic: this.state.somatic,
            duration: this.state.duration,
            ritual: this.state.ritual,
            description: this.state.description,
            materials: this.state.materials
        };

        fetch(`http://localhost:61211/api/spell/${this.state.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(editedSpell)
        })

        this.toggleFormLock();
    }

    handleChange(event) {
        event.preventDefault();

        const editedField = {};
        if (event.target.type === "checkbox")
            editedField[event.target.id] = event.target.checked;
        else
            editedField[event.target.id] = event.target.value;
        this.setState(editedField);
    }

    handleDelete(event) {
        event.preventDefault();

        var deleteReponse = prompt('Please type the name of the spell to confirm delete.','');
        if (deleteReponse.toLowerCase() === this.state.name.toLowerCase()) {
            fetch(`http://localhost:61211/api/spell/${this.state.id}`, {
                method: 'DELETE'
            })
            .then(response => response.json())
            .then(data => {
                if(data.success){
                    this.setState({
                        toList: true
                    });
                }
            });
        }
         else {
            alert('Incorrect spell name.');
        }
    }

    render() {
        if (this.state.toList === true) {
            return (
                <Redirect to="/" />
            );
        }

        if (this.state.success === true) {
            return (
                <div className="mt-2">
                    <form id="deleteSpell" onSubmit={this.handleDelete}>
                        <button id="deleteButton" className="btn btn-danger btn-lg float-right" type="submit">Delete</button>
                    </form>
                    <br />
                    <h2>Select Spell</h2>
                    <form id="editSpell" onSubmit={this.handleSubmit} onChange={this.handleChange}>
                        <div className="form-group row">
                            <div className="col-sm-3">
                                <label htmlFor="name">Name</label>
                                <input id="name" className="form-control inputField" name="name" defaultValue={this.state.name} type="text" disabled />
                            </div>
                            <div className="col-sm-3">
                                <label htmlFor="level">Level</label>
                                <input id="level" className="form-control inputField" name="level" defaultValue={this.state.level} type="number" disabled />
                            </div>
                            <div className="col-sm-3">
                                <label htmlFor="school">School</label>
                                <select id="school" className="form-control inputField" defaultValue={this.state.school} disabled>
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
                                <input id="castingTime" className="form-control inputField" name="castingTime" defaultValue={this.state.castingTime} type="text" disabled />
                            </div>
                        </div>
                        <div className="form-group row">
                            <div className="col-sm-3">
                                <label htmlFor="range">Range</label>
                                <input id="range" className="form-control inputField" name="range" defaultValue={this.state.range} type="text" disabled />
                            </div>
                            <div className="col-xs-1 ml-2">
                                <label htmlFor="verbal">Verbal</label>
                                <input id="verbal" className="form-control inputField" name="verbal" defaultChecked={this.state.verbal} type="checkbox" disabled />
                            </div>
                            <div className="col-xs-1 ml-2">
                                <label htmlFor="somatic">Somatic</label>
                                <input id="somatic" className="form-control inputField" name="somatic" defaultChecked={this.state.somatic} type="checkbox" disabled />
                            </div>
                            <div className="col-sm-3">
                                <label htmlFor="duration">Duration</label>
                                <input id="duration" className="form-control inputField" name="duration" defaultValue={this.state.duration} type="text" disabled />
                            </div>
                            <div className="col-xs-1 ml-2">
                                <label htmlFor="ritual">Ritual</label>
                                <input id="ritual" className="form-control inputField" name="ritual" defaultChecked={this.state.ritual} type="checkbox" disabled />
                            </div>
                        </div>
                        <div className="form-group row">
                            <div className="col-sm-6">
                                <label htmlFor="description">Description</label>
                                <textarea id="description" className="form-control inputField" name="description" defaultValue={this.state.description} type="text" disabled />
                            </div>
                        </div>
                        <div className="form-group row">
                            <div className="col-sm-4">
                                <label htmlFor="materials">Materials</label>
                                <input id="materials" className="form-control inputField" name="materials" defaultValue={this.state.materials} type="text" disabled />
                            </div>
                        </div>
                        <div>
                            <button id="editButton" onClick={this.toggleFormLock} className="btn btn-warning btn-lg" type="button">Edit</button>
                            <button id="submitButton" className="btn btn-success btn-lg" type="submit" hidden>Save</button>
                            <Link to="/" className="btn btn-outline-danger btn-lg ml-2">Cancel</Link>
                        </div>
                    </form>
                </div>
            );
        }

        return (
            <h1>Loading...</h1>
        );
    }
}

export default Select;