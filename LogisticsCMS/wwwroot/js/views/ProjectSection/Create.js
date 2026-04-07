// Form inputs
    const titleInput = document.getElementById('titleInput');
    const descriptionInput = document.getElementById('descriptionInput');
    const imageUrlInput = document.getElementById('imageUrlInput');
    
    // Counters
    const titleCounter = document.getElementById('titleCounter');
    const descCounter = document.getElementById('descCounter');
    
    // Preview elements
    const previewTitle = document.getElementById('previewTitle');
    const previewDescription = document.getElementById('previewDescription');
    const previewImage = document.getElementById('previewImage');
    const imagePlaceholder = document.getElementById('imagePlaceholder');

    // Update counters and preview
    titleInput.addEventListener('input', (e) => {
        titleCounter.textContent = e.target.value.length;
        previewTitle.textContent = e.target.value || 'Proje Başlığı';
    });

    descriptionInput.addEventListener('input', (e) => {
        descCounter.textContent = e.target.value.length;
        previewDescription.textContent = e.target.value || 'Proje açıklaması burada görünecek...';
    });

    // Update preview image
    imageUrlInput.addEventListener('input', (e) => {
        const url = e.target.value.trim();
        if (url) {
            previewImage.src = url;
            previewImage.onload = () => {
                previewImage.classList.add('show');
                imagePlaceholder.style.display = 'none';
            };
            previewImage.onerror = () => {
                previewImage.classList.remove('show');
                imagePlaceholder.style.display = 'flex';
            };
        } else {
            previewImage.classList.remove('show');
            imagePlaceholder.style.display = 'flex';
        }
    });

    // Form validation
    const form = document.getElementById('projectForm');
    form.addEventListener('submit', (e) => {
        const title = titleInput.value.trim();
        const description = descriptionInput.value.trim();
        const imageUrl = imageUrlInput.value.trim();

        if (!title || !description || !imageUrl) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
            
            if (!title) titleInput.style.borderColor = '#DA1E28';
            if (!description) descriptionInput.style.borderColor = '#DA1E28';
            if (!imageUrl) imageUrlInput.style.borderColor = '#DA1E28';

            setTimeout(() => {
                titleInput.style.borderColor = '';
                descriptionInput.style.borderColor = '';
                imageUrlInput.style.borderColor = '';
            }, 2000);
        }
    });

    window.addEventListener('load', () => {
        if (imageUrlInput.value.trim()) {
            imageUrlInput.dispatchEvent(new Event('input'));
        }
    });
