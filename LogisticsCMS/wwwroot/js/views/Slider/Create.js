// Character counters
    const inputs = [
        { input: 'input[name="Title"]', counter: 'titleCounter' },
        { input: 'input[name="SubTitle"]', counter: 'subtitleCounter' },
        { input: 'textarea[name="Description"]', counter: 'descCounter' }
    ];

    inputs.forEach(({ input, counter }) => {
        const element = document.querySelector(input);
        const counterElement = document.getElementById(counter);
        
        if (element && counterElement) {
            element.addEventListener('input', (e) => {
                counterElement.textContent = e.target.value.length;
            });
        }
    });

    // Image preview
    const imageUrlInput = document.getElementById('imageUrlInput');
    const previewImage = document.getElementById('previewImage');
    const previewPlaceholder = document.getElementById('previewPlaceholder');

    if (imageUrlInput && previewImage) {
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
                    previewPlaceholder.style.display = 'flex';
                };
            } else {
                previewImage.classList.remove('show');
                previewPlaceholder.style.display = 'flex';
            }
        });
    }

    // Form validation enhancement
    const form = document.getElementById('sliderForm');
    if (form) {
        form.addEventListener('submit', (e) => {
            const requiredInputs = form.querySelectorAll('[required]');
            let isValid = true;

            requiredInputs.forEach(input => {
                if (!input.value.trim()) {
                    isValid = false;
                    input.style.borderColor = '#ef4444';
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
    }
