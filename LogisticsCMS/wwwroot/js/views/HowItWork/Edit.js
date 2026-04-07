// Character counters and preview
    const titleInput = document.getElementById('titleInput');
    const descriptionInput = document.getElementById('descriptionInput');
    const iconUrlInput = document.getElementById('iconUrlInput');
    
    const titleCounter = document.getElementById('titleCounter');
    const descCounter = document.getElementById('descCounter');
    
    const previewTitle = document.getElementById('previewTitle');
    const previewDescription = document.getElementById('previewDescription');
    const previewIcon1 = document.getElementById('previewIcon1');
    const iconPlaceholder1 = document.getElementById('iconPlaceholder1');

    // Update counters and preview
    titleInput.addEventListener('input', (e) => {
        titleCounter.textContent = e.target.value.length;
        previewTitle.textContent = e.target.value || 'Başlık Giriniz';
    });

    descriptionInput.addEventListener('input', (e) => {
        descCounter.textContent = e.target.value.length;
        previewDescription.textContent = e.target.value || 'Açıklama burada görünecek...';
    });

    // Update preview icon
    iconUrlInput.addEventListener('input', (e) => {
        const url = e.target.value.trim();
        if (url) {
            previewIcon1.src = url;
            previewIcon1.onload = () => {
                previewIcon1.style.display = 'block';
                iconPlaceholder1.style.display = 'none';
            };
            previewIcon1.onerror = () => {
                previewIcon1.style.display = 'none';
                iconPlaceholder1.style.display = 'block';
            };
        } else {
            previewIcon1.style.display = 'none';
            iconPlaceholder1.style.display = 'block';
        }
    });

    // Form validation
    const form = document.getElementById('howItWorkForm');
    form.addEventListener('submit', (e) => {
        const title = titleInput.value.trim();
        const description = descriptionInput.value.trim();
        const iconUrl = iconUrlInput.value.trim();

        if (!title || !description || !iconUrl) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
            
            if (!title) titleInput.style.borderColor = 'var(--pink)';
            if (!description) descriptionInput.style.borderColor = 'var(--pink)';
            if (!iconUrl) iconUrlInput.style.borderColor = 'var(--pink)';

            setTimeout(() => {
                titleInput.style.borderColor = '';
                descriptionInput.style.borderColor = '';
                iconUrlInput.style.borderColor = '';
            }, 2000);
        }
    });

    window.addEventListener('load', () => {
        titleCounter.textContent = titleInput.value.length;
        descCounter.textContent = descriptionInput.value.length;
        previewTitle.textContent = titleInput.value || 'Başlık Giriniz';
        previewDescription.textContent = descriptionInput.value || 'Açıklama burada görünecek...';

        if (iconUrlInput.value.trim()) {
            iconUrlInput.dispatchEvent(new Event('input'));
        }
    });
