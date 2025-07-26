// ===========================
// OUTZEN.JS - MAP & ANIMATIONS
// ===========================

// Initialisation de la carte Leaflet
window.initializeLeafletMap = () => {
    const mapElement = document.getElementById('map');
    if (!mapElement) {
        console.warn("❌ Element 'map' not found in the DOM.");
        return;
    }

    const map = L.map(mapElement).setView([50.8950, 4.3415], 13); // Brussels Atomium

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    console.info("✅ Leaflet map initialized successfully.");
};

// Scroll reveal effect using IntersectionObserver
(() => {
    const sections = document.querySelectorAll("section.animate-on-scroll, .scroll-reveal");

    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add("visible");
                observer.unobserve(entry.target); // Avoid triggering again
            }
        });
    }, { threshold: 0.1 });

    sections.forEach(section => observer.observe(section));
})();

// Dynamic background hue rotation
(() => {
    const stop1 = document.getElementById("stop1");
    const stop2 = document.getElementById("stop2");
    if (!stop1 || !stop2) return;

    let hue = 0;
    setInterval(() => {
        hue = (hue + 1) % 360;
        const color1 = `hsl(${hue}, 100%, 60%)`;
        const color2 = `hsl(${(hue + 120) % 360}, 100%, 60%)`;
        stop1.setAttribute("stop-color", color1);
        stop2.setAttribute("stop-color", color2);
    }, 50);
})();

// Parallax and animated SVG behavior
(() => {
    const svg = document.querySelector(".svg-background svg");

    if (!svg) return;

    document.addEventListener("mousemove", (e) => {
        const x = (e.clientX / window.innerWidth - 0.5) * 20;
        const y = (e.clientY / window.innerHeight - 0.5) * 20;
        svg.style.transform = `rotateX(${y}deg) rotateY(${x}deg) scale(1.05)`;
    });

    document.addEventListener("mouseleave", () => {
        svg.style.transform = "rotateX(0deg) rotateY(0deg)";
    });
})();





















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/