// Search functionality
    const searchInput = document.getElementById('searchInput');
    const table = document.getElementById('shipmentTable');

    if (searchInput && table) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const rows = table.querySelectorAll('tbody tr');

            rows.forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(searchTerm) ? '' : 'none';
            });
        });
    }

    // Filter functionality
    const filterButtons = document.querySelectorAll('.filter-btn');
    
    filterButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            filterButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            
            const filter = btn.getAttribute('data-filter');
            const rows = document.querySelectorAll('#shipmentTable tbody tr');

            rows.forEach(row => {
                const status = row.getAttribute('data-status');
                
                if (filter === 'all') {
                    row.style.display = '';
                } else {
                    row.style.display = status === filter ? '' : 'none';
                }
            });
        });
    });
