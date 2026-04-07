// Search functionality
    const searchInput = document.getElementById('searchInput');
    const contentGrid = document.getElementById('contentGrid');

    if (searchInput && contentGrid) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const cards = contentGrid.querySelectorAll('.about-card');

            cards.forEach(card => {
                const title = card.getAttribute('data-title');
                card.style.display = title.includes(searchTerm) ? '' : 'none';
            });
        });
    }

    // View toggle
    const viewButtons = document.querySelectorAll('.view-btn');
    
    viewButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            viewButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            
            const view = btn.getAttribute('data-view');
            
            if (view === 'list') {
                console.log('List view - to be implemented');
            }
        });
    });

    // Stagger animation for cards
    const aboutCards = document.querySelectorAll('.about-card');
    aboutCards.forEach((card, index) => {
        card.style.animationDelay = `${0.4 + (index * 0.06)}s`;
    });
