// Search functionality
    const searchInput = document.getElementById('searchInput');
    const servicesGrid = document.getElementById('servicesGrid');

    if (searchInput && servicesGrid) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const serviceCards = servicesGrid.querySelectorAll('.service-card');

            serviceCards.forEach(card => {
                const title = card.getAttribute('data-title');
                card.style.display = title.includes(searchTerm) ? '' : 'none';
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
            const serviceCards = document.querySelectorAll('.service-card');

            serviceCards.forEach(card => {
                const status = card.getAttribute('data-status');
                
                if (filter === 'all') {
                    card.style.display = '';
                } else {
                    card.style.display = status === filter ? '' : 'none';
                }
            });
        });
    });

    // Stagger animation for cards
    const serviceCards = document.querySelectorAll('.service-card');
    serviceCards.forEach((card, index) => {
        card.style.animationDelay = `${0.4 + (index * 0.05)}s`;
    });
