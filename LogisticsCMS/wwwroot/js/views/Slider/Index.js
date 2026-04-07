// Search Functionality
    const searchInput = document.getElementById('searchInput');
    const tableBody = document.getElementById('sliderTableBody');

    if (searchInput && tableBody) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const rows = tableBody.getElementsByTagName('tr');

            Array.from(rows).forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(searchTerm) ? '' : 'none';
            });
        });
    }

    // Filter Functionality
    const filterButtons = document.querySelectorAll('.filter-btn');

    filterButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            // Remove active class from all buttons
            filterButtons.forEach(b => b.classList.remove('active'));
            // Add active class to clicked button
            btn.classList.add('active');

            // Here you can add filtering logic based on data-filter attribute
            const filter = btn.getAttribute('data-filter');
            console.log('Filter:', filter);
        });
    });

    // Refresh button
    const refreshBtn = document.querySelector('.btn-icon');
    if (refreshBtn) {
        refreshBtn.addEventListener('click', () => {
            location.reload();
        });
    }
