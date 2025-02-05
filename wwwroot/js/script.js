function loadData() {
    const schema = document.getElementById("schemaDropdown").value;
    const searchBar = document.getElementById("searchBar");

    // Check if searchBar exists before trying to modify its style
    if (searchBar) {
        if (schema) {
            searchBar.style.display = "block";
            // Fetch and populate data based on selected schema
            fetchData(schema);
        } else {
            searchBar.style.display = "none";
            document.getElementById("dataTable").innerHTML = "";
        }
    } else {
        console.error('searchBar element not found.');
    }
}
