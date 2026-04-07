// Character counters
    const titleInput = document.getElementById('titleInput');
    const descriptionInput = document.getElementById('descriptionInput');
    const imageUrlInput = document.getElementById('imageUrlInput');
    const statusToggle = document.getElementById('statusToggle');

    const titleCounter = document.getElementById('titleCounter');
    const descCounter = document.getElementById('descCounter');

    const previewTitle = document.getElementById('previewTitle');
    const previewDesc = document.getElementById('previewDesc');
    const previewImage = document.getElementById('previewImage');
    const previewIconPlaceholder = document.getElementById('previewIconPlaceholder');
    const previewStatus = document.getElementById('previewStatus');

    // Update counters
    titleInput.addEventListener('input', (e) => {
        titleCounter.textContent = e.target.value.length;
        previewTitle.textContent = e.target.value || 'Hizmet Başlığı';
    });

    descriptionInput.addEventListener('input', (e) => {
        descCounter.textContent = e.target.value.length;
        previewDesc.textContent = e.target.value || 'Hizmet açıklaması burada görünecek';
    });

    // Update preview image
    imageUrlInput.addEventListener('input', (e) => {
        const url = e.target.value.trim();
        if (url) {
            previewImage.src = url;
            previewImage.onload = () => {
                previewImage.classList.add('show');
                previewIconPlaceholder.classList.add('hide');
            };
            previewImage.onerror = () => {
                previewImage.classList.remove('show');
                previewIconPlaceholder.classList.remove('hide');
            };
        } else {
            previewImage.classList.remove('show');
            previewIconPlaceholder.classList.remove('hide');
        }
    });

    // Update status
    statusToggle.addEventListener('change', (e) => {
        const isActive = e.target.checked;
        const statusDot = previewStatus.querySelector('.status-dot');
        
        if (isActive) {
            previewStatus.classList.remove('inactive');
            statusDot.classList.remove('inactive');
            previewStatus.innerHTML = '<span class="status-dot"></span>Aktif';
        } else {
            previewStatus.classList.add('inactive');
            statusDot.classList.add('inactive');
            previewStatus.innerHTML = '<span class="status-dot inactive"></span>Pasif';
        }
    });

    // Form validation
    const offerForm = document.getElementById('offerForm');
    offerForm.addEventListener('submit', (e) => {
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
            }, 2000);
        }
    });
