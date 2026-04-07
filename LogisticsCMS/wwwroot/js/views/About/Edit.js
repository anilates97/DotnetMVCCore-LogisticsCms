// Character counters and preview
    const titleInput = document.getElementById('titleInput');
    const descriptionInput = document.getElementById('descriptionInput');
    const imageUrlInput = document.getElementById('imageUrlInput');
    
    const titleCounter = document.getElementById('titleCounter');
    const descCounter = document.getElementById('descCounter');
    
    const previewTitle = document.getElementById('previewTitle');
    const previewDescription = document.getElementById('previewDescription');
    const previewImage = document.getElementById('previewImage');
    const previewPlaceholder = document.getElementById('previewPlaceholder');

    // Update counters and preview
    titleInput.addEventListener('input', (e) => {
        titleCounter.textContent = e.target.value.length;
        previewTitle.textContent = e.target.value || 'Başlık Giriniz';
    });

    descriptionInput.addEventListener('input', (e) => {
        descCounter.textContent = e.target.value.length;
        previewDescription.textContent = e.target.value || 'Açıklama burada görünecek...';
    });

    // Update preview image
    imageUrlInput.addEventListener('input', (e) => {
        const url = e.target.value.trim();
        if (url) {
            previewImage.src = url;
            previewImage.onload = () => {
                previewImage.classList.add('show');
                previewPlaceholder.style.display = 'none';
            };
            previewImage.onerror = () => {
                previewImage.classList.remove('show');
                previewPlaceholder.style.display = 'block';
            };
        } else {
            previewImage.classList.remove('show');
            previewPlaceholder.style.display = 'block';
        }
    });

    // Form validation
    const aboutForm = document.getElementById('aboutForm');
    aboutForm.addEventListener('submit', (e) => {
        const title = titleInput.value.trim();
        const description = descriptionInput.value.trim();
        const imageUrl = imageUrlInput.value.trim();

        if (!title || !description || !imageUrl) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
            
            if (!title) titleInput.style.borderColor = 'var(--danger)';
            if (!description) descriptionInput.style.borderColor = 'var(--danger)';
            if (!imageUrl) imageUrlInput.style.borderColor = 'var(--danger)';

            setTimeout(() => {
                titleInput.style.borderColor = '';
                descriptionInput.style.borderColor = '';
                imageUrlInput.style.borderColor = '';
            }, 2500);
        }
    });
