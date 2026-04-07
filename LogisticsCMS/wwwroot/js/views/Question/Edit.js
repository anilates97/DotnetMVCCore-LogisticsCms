// Form inputs
    const titleInput = document.getElementById('titleInput');
    const descriptionInput = document.getElementById('descriptionInput');
    
    // Counters
    const titleCounter = document.getElementById('titleCounter');
    const descCounter = document.getElementById('descCounter');
    
    // Preview elements
    const previewTitle = document.getElementById('previewTitle');
    const previewDescription = document.getElementById('previewDescription');

    // Update counters and preview
    titleInput.addEventListener('input', (e) => {
        titleCounter.textContent = e.target.value.length;
        previewTitle.textContent = e.target.value || 'Soru Başlığı';
    });

    descriptionInput.addEventListener('input', (e) => {
        descCounter.textContent = e.target.value.length;
        previewDescription.textContent = e.target.value || 'Sorunun cevabı burada görünecek...';
    });

    titleCounter.textContent = titleInput.value.length;
    descCounter.textContent = descriptionInput.value.length;
    previewTitle.textContent = titleInput.value || 'Soru Başlığı';
    previewDescription.textContent = descriptionInput.value || 'Sorunun cevabı burada görünecek...';

    // Form validation
    const form = document.getElementById('questionForm');
    form.addEventListener('submit', (e) => {
        const title = titleInput.value.trim();
        const description = descriptionInput.value.trim();

        if (!title || !description) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
            
            if (!title) titleInput.style.borderColor = 'var(--secondary)';
            if (!description) descriptionInput.style.borderColor = 'var(--secondary)';

            setTimeout(() => {
                titleInput.style.borderColor = '';
                descriptionInput.style.borderColor = '';
            }, 2000);
        }
    });
