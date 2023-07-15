function deleteWatchers() {
    if (confirm("Are you sure?")) {
        let url = `${window.location.origin}/Showing/RefreshWatchers`;
        window.location.href = url;
    }
}
