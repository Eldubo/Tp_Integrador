
document.addEventListener("DOMContentLoaded", () => {
    // Animación para la barra de búsqueda
    const searchBar = document.querySelector(".search-bar");
    searchBar.style.opacity = 0;
    searchBar.style.transform = "translateY(-20px)";
    setTimeout(() => {
        searchBar.style.transition = "opacity 0.6s ease, transform 0.6s ease";
        searchBar.style.opacity = 1;
        searchBar.style.transform = "translateY(0)";
    }, 300);

    // Efecto de "zoom" en los testimonios
    const testimonials = document.querySelectorAll(".testimonial");
    testimonials.forEach((testimonial) => {
        testimonial.addEventListener("mouseenter", () => {
            testimonial.style.transform = "scale(1.05)";
            testimonial.style.transition = "transform 0.3s ease";
        });
        testimonial.addEventListener("mouseleave", () => {
            testimonial.style.transform = "scale(1)";
        });
    });

    // Animación de desvanecimiento en el scroll
    const fadeInElements = document.querySelectorAll(".fade-in");
    window.addEventListener("scroll", () => {
        fadeInElements.forEach((el) => {
            const elementTop = el.getBoundingClientRect().top;
            const windowHeight = window.innerHeight;
            if (elementTop < windowHeight - 50) {
                el.style.opacity = 1;
            }
        });
    });
});