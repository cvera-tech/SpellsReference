export class SpellbookAPI {
    fetchSpellbookList() {
        debugger;
        fetch('http://localhost:61211/api/spellbooks')
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            })
            .then(obj => obj)
            .catch(() => null);
    }
}