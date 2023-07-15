

function deleteActor(id) {
    if (confirm("Are you sure?")) {
        let url = `${window.location.origin}/Actor/DeleteActor/${id}`
        window.location.href = url;
    }
}
