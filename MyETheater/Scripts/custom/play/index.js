
function deletePlay(id)
{
    if (confirm("Are you sure?")) {
        let url = `${window.location.origin}/Play/DeletePlay/${id}`
        window.location.href = url;
    }
}
