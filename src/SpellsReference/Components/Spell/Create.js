import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

class Create extends Component {
    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        fetch('/api/spell/', {
            method: 'POST',
            body: data,
        });
    }

    render() {
        return (
            <div className="mt-2">
                <h2>Add Spell</h2>

                <form onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <div className="col-sm-3">
                            <label htmlFor="name">Name</label>
                            <input id="name" className="form-control" name="name" type="text" />
                        </div>
                        <div className="col-sm-1">
                            <label htmlFor="level">Level</label>
                            <input id="level" className="form-control" name="level" type="number" />
                        </div>
                        <div className="col-sm-2">
                            <label htmlFor="schoolOfMagic">School</label>
                            <select id="schoolOfMagic" className="form-control" defaultValue="abjuration">
                                <option value="0">Abjuration</option>
                                <option value="1">Conjuration</option>
                                <option value="2">Divination</option>
                                <option value="3">Enchantment</option>
                                <option value="4">Evocation</option>
                                <option value="5">Illusion</option>
                                <option value="6">Necromancy</option>
                                <option value="7">Transmutation</option>
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
                            <textarea id="description" className="form-control" name="description" type="textarea" />
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-4">
                            <label htmlFor="description">Materials</label>
                            <input id="description" className="form-control" name="description" type="textarea" />
                        </div>
                    </div>
                    <div>
                        <button className="btn btn-success btn-lg">Submit</button>
                        <Link to="/React/Index" className="btn btn-outline-danger btn-lg ml-2">Cancel</Link>
                    </div>
                </form>
            </div>
        );
    }
}

export default Create;