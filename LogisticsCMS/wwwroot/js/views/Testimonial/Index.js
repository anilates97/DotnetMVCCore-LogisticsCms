// Search functionality
    const searchInput = document.getElementById('searchInput');
    const testimonialsGrid = document.getElementById('testimonialsGrid');

    if (searchInput && testimonialsGrid) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const cards = testimonialsGrid.querySelectorAll('.testimonial-card');

            cards.forEach(card => {
                const name = card.getAttribute('data-name');
                card.style.display = name.includes(searchTerm) ? '' : 'none';
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
            const cards = document.querySelectorAll('.testimonial-card');

            cards.forEach(card => {
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
    const testimonialCards = document.querySelectorAll('.testimonial-card');
    testimonialCards.forEach((card, index) => {
        card.style.animationDelay = `${0.4 + (index * 0.05)}s`;
    });
