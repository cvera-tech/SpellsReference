import React from 'react';

function Spell({ spell }) {
    return (
        <tr data-name={spell.name} data-id={spell.id}>
            <td>{spell.name}</td>
            <td>{spell.level}</td>
            <td>{spell.school}</td>
            <td>{spell.castingTime}</td>
            <td>{spell.range}</td>
            <td>{spell.verbal ? 'True' : 'False'}</td>
            <td>{spell.somatic ? 'True' : 'False'}</td>
            <td>{spell.materials}</td>
            <td>{spell.duration}</td>
            <td>{spell.ritual ? 'True' : 'False'}</td>
            <td>{spell.description}</td>
        </tr>
    );
}

function SpellList(props) {
    function handleSpellClick(event) {
        // Grab the data from the table rows
        const tr = event.target.parentNode;
        const spellName = tr.getAttribute('data-name');
        const spellId = tr.getAttribute('data-id');

        // Invoke the callback function to confirm adding the spell
        props.clickCallback({ spellName: spellName, spellId: spellId });
    }

    return (
        <div>
            <table>
                <thead>
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
                <tbody onClick={handleSpellClick}>
                    {
                        props.spells.map(spell => (
                            <Spell spell={spell} key={spell.id} />
                        ))
                    }
                </tbody>
            </table>
        </div>
    );
}

export { Spell, SpellList };