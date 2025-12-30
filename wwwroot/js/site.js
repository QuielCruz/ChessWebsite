// Mobile menu toggle functionality
document.addEventListener('DOMContentLoaded', function () {
    const mobileMenuBtn = document.querySelector('.mobile-menu-btn');
    const navMenu = document.querySelector('.nav-menu');
    const navButtons = document.querySelector('.nav-buttons');

    // Toggle mobile menu
    if (mobileMenuBtn) {
        mobileMenuBtn.addEventListener('click', function () {
            navMenu.style.display = navMenu.style.display === 'flex' ? 'none' : 'flex';
            navButtons.style.display = navButtons.style.display === 'flex' ? 'none' : 'flex';

            if (navMenu.style.display === 'flex') {
                navMenu.style.flexDirection = 'column';
                navMenu.style.position = 'absolute';
                navMenu.style.top = '100%';
                navMenu.style.left = '0';
                navMenu.style.width = '100%';
                navMenu.style.backgroundColor = 'var(--maroon-dark)';
                navMenu.style.padding = '20px';
                navMenu.style.gap = '15px';

                navButtons.style.flexDirection = 'column';
                navButtons.style.position = 'absolute';
                navButtons.style.top = 'calc(100% + 180px)';
                navButtons.style.left = '0';
                navButtons.style.width = '100%';
                navButtons.style.backgroundColor = 'var(--maroon-dark)';
                navButtons.style.padding = '20px';
                navButtons.style.gap = '15px';
            }
        });
    }

    // Button hover effects
    const buttons = document.querySelectorAll('button');
    buttons.forEach(button => {
        button.addEventListener('mouseenter', function () {
            this.style.transform = 'scale(1.05)';
        });

        button.addEventListener('mouseleave', function () {
            this.style.transform = 'scale(1)';
        });
    });

    // Animate chess pieces on scroll
    const chessPieces = document.querySelectorAll('.chess-pieces i');

    function animateChessPieces() {
        if (chessPieces.length > 0) {
            chessPieces.forEach((piece, index) => {
                setTimeout(() => {
                    piece.style.transform = 'translateY(0)';
                    piece.style.opacity = '1';
                }, index * 200);
            });
        }
    }

    // Trigger animation when page loads
    setTimeout(animateChessPieces, 500);

    // Add scroll effect to navbar
    window.addEventListener('scroll', function () {
        const navbar = document.querySelector('.navbar');
        if (navbar) {
            if (window.scrollY > 50) {
                navbar.style.boxShadow = '0 6px 20px rgba(0, 0, 0, 0.15)';
                navbar.style.padding = '15px 0';
            } else {
                navbar.style.boxShadow = '0 4px 12px rgba(0, 0, 0, 0.1)';
                navbar.style.padding = '20px 0';
            }
        }
    });

    // Feature cards animation on scroll
    const featureCards = document.querySelectorAll('.feature-card');

    if (featureCards.length > 0) {
        const observerOptions = {
            threshold: 0.2,
            rootMargin: '0px 0px -50px 0px'
        };

        const observer = new IntersectionObserver(function (entries) {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.style.opacity = '1';
                    entry.target.style.transform = 'translateY(0)';
                }
            });
        }, observerOptions);

        featureCards.forEach(card => {
            card.style.opacity = '0';
            card.style.transform = 'translateY(20px)';
            card.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
            observer.observe(card);
        });
    }
});