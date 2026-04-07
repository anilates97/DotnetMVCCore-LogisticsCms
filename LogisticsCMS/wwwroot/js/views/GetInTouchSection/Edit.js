// Character counters
    const inputs = [
        { input: 'badgeInput', counter: 'badgeCounter', preview: 'previewBadge' },
        { input: 'mainTitleInput', counter: 'mainTitleCounter', preview: 'previewMainTitle' },
        { input: 'descriptionInput', counter: 'descCounter', preview: 'previewDescription' },
        { input: 'feature1TitleInput', counter: null, preview: 'previewFeature1Title' },
        { input: 'feature1DescInput', counter: null, preview: 'previewFeature1Desc' },
        { input: 'feature2TitleInput', counter: null, preview: 'previewFeature2Title' },
        { input: 'feature2DescInput', counter: null, preview: 'previewFeature2Desc' }
    ];

    inputs.forEach(({ input, counter, preview }) => {
        const inputEl = document.getElementById(input);
        const counterEl = counter ? document.getElementById(counter) : null;
        const previewEl = document.getElementById(preview);

        if (inputEl) {
            inputEl.addEventListener('input', (e) => {
                if (counterEl) {
                    counterEl.textContent = e.target.value.length;
                }
                if (previewEl) {
                    previewEl.textContent = e.target.value || previewEl.textContent;
                }
            });
        }
    });

    // Image preview
    const imageUrlInput = document.getElementById('imageUrlInput');
    const previewImage = document.getElementById('previewImage');
    const previewPlaceholder = document.getElementById('previewPlaceholder');

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
    const form = document.getElementById('getInTouchForm');
    form.addEventListener('submit', (e) => {
        const requiredInputs = form.querySelectorAll('[required]');
        let isValid = true;

        requiredInputs.forEach(input => {
            if (!input.value.trim()) {
                isValid = false;
                input.style.borderColor = 'var(--primary)';
                setTimeout(() => {
                    input.style.borderColor = '';
                }, 2000);
            }
        });

        if (!isValid) {
            e.preventDefault();
            alert('Lütfen tüm zorunlu alanları doldurun!');
        }
    });

    window.addEventListener('load', () => {
        inputs.forEach(({ input, counter, preview }) => {
            const inputEl = document.getElementById(input);
            const counterEl = counter ? document.getElementById(counter) : null;
            const previewEl = document.getElementById(preview);

            if (inputEl) {
                if (counterEl) {
                    counterEl.textContent = inputEl.value.length;
                }

                if (previewEl && inputEl.value.trim()) {
                    previewEl.textContent = inputEl.value;
                }
            }
        });

        if (imageUrlInput && imageUrlInput.value.trim()) {
            imageUrlInput.dispatchEvent(new Event('input'));
        }
    });
