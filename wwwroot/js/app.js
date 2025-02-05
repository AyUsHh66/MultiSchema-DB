document.addEventListener('DOMContentLoaded', function () {
    const schemaDropdown = document.getElementById('schemaDropdown');
    const searchInput = document.getElementById('searchInput');
    const customerList = document.getElementById('customerList'); // Container to render customer data

    schemaDropdown.addEventListener('change', loadCustomers);
    searchInput.addEventListener('input', searchCustomers);

    // Function to load customers when schema changes
    function loadCustomers() {
        const schema = schemaDropdown.value;
        const query = searchInput.value; // You might want to keep the search term

        fetchCustomers(schema, query);
    }

    // Function to search customers as the user types
    function searchCustomers() {
        const query = searchInput.value;
        const schema = schemaDropdown.value;

        fetchCustomers(schema, query);
    }

    // Function to fetch customer data from the server
    function fetchCustomers(schema, searchQuery) {
        // Construct the API URL, passing schema and searchQuery as query parameters
        const url = `/api/customers?schema=${schema}&searchQuery=${searchQuery}`;

        // Perform the fetch request
        fetch(url)
            .then(response => response.json())
            .then(data => {
                // Clear the current customer list
                customerList.innerHTML = '';

                // Render the new customer data
                if (data && data.length > 0) {
                    data.forEach(customer => {
                        const customerElement = document.createElement('div');
                        customerElement.classList.add('customer-item');
                        customerElement.innerHTML = `
                            <p>Customer ID: ${customer.customerID}</p>
                            <p>First Name: ${customer.firstName}</p>
                            <p>Last Name: ${customer.lastName}</p>
                            <p>Email: ${customer.email}</p>
                        `;
                        customerList.appendChild(customerElement);
                    });
                } else {
                    customerList.innerHTML = '<p>No customers found.</p>';
                }
            })
            .catch(error => {
                console.error('Error fetching customer data:', error);
            });
    }

    // Initial load when the page loads
    loadCustomers();
});
