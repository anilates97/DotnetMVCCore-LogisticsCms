// Real-time preview
    const brandNameInput = document.getElementById('brandNameInput');
    const imageUrlInput = document.getElementById('imageUrlInput');
    const statusToggle = document.getElementById('statusToggle');
    const previewPlaceholder = document.getElementById('previewPlaceholder');
    const brandPreview = document.getElementById('brandPreview');
    const previewLogo = document.getElementById('previewLogo');
    const previewName = document.getElementById('previewName');
    const previewStatus = document.getElementById('previewStatus');

    function updatePreview() {
        const hasName = brandNameInput.value.trim();
        const hasImage = imageUrlInput.value.trim();

        if (hasName || hasImage) {
            previewPlaceholder.style.display = 'none';
            brandPreview.classList.add('show');

            if (hasName) {
                previewName.textContent = brandNameInput.value;
            }

            if (hasImage) {
                previewLogo.src = imageUrlInput.value;
                previewLogo.onerror = () => {
                    previewLogo.src = 'https://via.placeholder.com/200x200?text=Logo';
                };
            }

            const isActive = statusToggle.checked;
            previewStatus.className = isActive ? 'preview-status active' : 'preview-status inactive';
            previewStatus.innerHTML = `
                <span class="preview-status-dot"></span>
                ${isActive ? 'Aktif' : 'Pasif'}
            `;
        } else {
            previewPlaceholder.style.display = 'flex';
            brandPreview.classList.remove('show');
        }
    }

    brandNameInput.addEventListener('input', updatePreview);
    imageUrlInput.addEventListener('input', updatePreview);
    statusToggle.addEventListener('change', updatePreview);

    // Form validation
    const brandForm = document.getElementById('brandForm');
    brandForm.addEventListener('submit', (e) => {
        const brandName = brandNameInput.value.trim();
        const imageUrl = imageUrlInput.value.trim();

        if (!brandName || !imageUrl) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
            
            if (!brandName) brandNameInput.style.borderColor = 'var(--danger)';
            if (!imageUrl) imageUrlInput.style.borderColor = 'var(--danger)';

            setTimeout(() => {
                brandNameInput.style.borderColor = '';
                imageUrlInput.style.borderColor = '';
            }, 2000);
        }
    });

    // Clear error on input
    brandNameInput.addEventListener('input', () => {
        brandNameInput.style.borderColor = '';
    });

    imageUrlInput.addEventListener('input', () => {
        imageUrlInput.style.borderColor = '';
    });
