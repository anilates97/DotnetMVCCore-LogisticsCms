// Search Functionality
    const searchInput = document.getElementById('searchInput');
    const brandsGrid = document.getElementById('brandsGrid');

    if (searchInput && brandsGrid) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const brandCards = brandsGrid.querySelectorAll('.brand-card');

            brandCards.forEach(card => {
                const brandName = card.getAttribute('data-name');
                card.style.display = brandName.includes(searchTerm) ? '' : 'none';
            });
        });
    }

    // Filter Functionality
    const filterButtons = document.querySelectorAll('.filter-btn');
    
    filterButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            filterButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            
            const filter = btn.getAttribute('data-filter');
            const brandCards = document.querySelectorAll('.brand-card');

            brandCards.forEach(card => {
                const status = card.getAttribute('data-status');
                
                if (filter === 'all') {
                    card.style.display = '';
                } else {
                    card.style.display = status === filter ? '' : 'none';
                }
            });
        });
    });

    // View Toggle
    const viewButtons = document.querySelectorAll('.view-btn');
    
    viewButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            viewButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            
            const view = btn.getAttribute('data-view');
            
            if (view === 'list') {
                // You can implement list view here if needed
                console.log('List view - to be implemented');
            }
        });
    });

    // Stagger animation for cards
    const brandCards = document.querySelectorAll('.brand-card');
    brandCards.forEach((card, index) => {
        card.style.animationDelay = `${0.5 + (index * 0.05)}s`;
    });
