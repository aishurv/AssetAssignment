window.initializeBootstrapDropdowns = () => {
    document.querySelectorAll('.dropdown-toggle').forEach(dropdown => {
        new bootstrap.Dropdown(dropdown);
    });
};