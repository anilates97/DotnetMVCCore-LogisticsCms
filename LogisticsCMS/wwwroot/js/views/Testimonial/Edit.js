// Form inputs
    const nameInput = document.getElementById('nameInput');
    const titleInput = document.getElementById('titleInput');
    const imageUrlInput = document.getElementById('imageUrlInput');
    const reviewInput = document.getElementById('reviewInput');
    const reviewCounter = document.getElementById('reviewCounter');
    
    // Preview elements
    const previewName = document.getElementById('previewName');
    const previewTitle = document.getElementById('previewTitle');
    const previewReview = document.getElementById('previewReview');
    const previewAvatar = document.getElementById('previewAvatar');
    const avatarPlaceholder = document.getElementById('avatarPlaceholder');
    const previewStars = document.getElementById('previewStars');

    // Star rating
    const stars = document.querySelectorAll('.star');
    const reviewScoreInput = document.getElementById('reviewScoreInput');
    const ratingDisplay = document.getElementById('ratingDisplay');
    let currentRating = 5;

    // Update preview
    nameInput.addEventListener('input', (e) => {
        previewName.textContent = e.target.value || 'Ad Soyad';
    });

    titleInput.addEventListener('input', (e) => {
        previewTitle.textContent = e.target.value || 'Ünvan';
    });

    reviewInput.addEventListener('input', (e) => {
        reviewCounter.textContent = e.target.value.length;
        previewReview.textContent = `"${e.target.value}"` || '"Yorum metni burada g?r?necek..."';
    });

    // Image preview
    imageUrlInput.addEventListener('input', (e) => {
        const url = e.target.value.trim();
        if (url) {
            previewAvatar.src = url;
            previewAvatar.onload = () => {
                previewAvatar.classList.add('show');
                avatarPlaceholder.style.display = 'none';
            };
            previewAvatar.onerror = () => {
                previewAvatar.classList.remove('show');
                avatarPlaceholder.style.display = 'flex';
            };
        } else {
            previewAvatar.classList.remove('show');
            avatarPlaceholder.style.display = 'flex';
        }
    });

    // Star rating
    stars.forEach(star => {
        star.addEventListener('click', () => {
            currentRating = parseInt(star.getAttribute('data-value'));
            reviewScoreInput.value = currentRating;
            ratingDisplay.textContent = currentRating;
            
            // Update stars
            stars.forEach((s, index) => {
                if (index < currentRating) {
                    s.classList.add('active');
                } else {
                    s.classList.remove('active');
                }
            });
            
            // Update preview stars
            updatePreviewStars(currentRating);
        });
    });

    // Initialize all stars as active
    stars.forEach(star => star.classList.add('active'));

    function updatePreviewStars(rating) {
        const starSvgs = previewStars.querySelectorAll('svg');
        starSvgs.forEach((svg, index) => {
            if (index < rating) {
                svg.style.opacity = '1';
            } else {
                svg.style.opacity = '0.3';
            }
        });
    }

    // Form validation
    const form = document.getElementById('testimonialForm');
    form.addEventListener('submit', (e) => {
        const name = nameInput.value.trim();
        const title = titleInput.value.trim();
        const imageUrl = imageUrlInput.value.trim();
        const review = reviewInput.value.trim();

        if (!name || !title || !imageUrl || !review) {
            e.preventDefault();
            alert('L?tfen t?m zorunlu alanlar? doldurun!');
            
            if (!name) nameInput.style.borderColor = 'var(--gold)';
            if (!title) titleInput.style.borderColor = 'var(--gold)';
            if (!imageUrl) imageUrlInput.style.borderColor = 'var(--gold)';
            if (!review) reviewInput.style.borderColor = 'var(--gold)';

            setTimeout(() => {
                nameInput.style.borderColor = '';
                titleInput.style.borderColor = '';
                imageUrlInput.style.borderColor = '';
                reviewInput.style.borderColor = '';
            }, 2000);
        }
    });

    window.addEventListener('load', () => {
        reviewCounter.textContent = reviewInput.value.length;
        previewName.textContent = nameInput.value || 'Ad Soyad';
        previewTitle.textContent = titleInput.value || 'Ünvan';
        previewReview.textContent = reviewInput.value ? `"${reviewInput.value}"` : '"Yorum metni burada g?r?necek..."';

        currentRating = parseInt(reviewScoreInput.value || '5');
        ratingDisplay.textContent = currentRating;

        stars.forEach((s, index) => {
            if (index < currentRating) {
                s.classList.add('active');
            } else {
                s.classList.remove('active');
            }
        });

        updatePreviewStars(currentRating);

        if (imageUrlInput.value.trim()) {
            imageUrlInput.dispatchEvent(new Event('input'));
        }
    });
