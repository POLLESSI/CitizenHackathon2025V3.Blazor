window.initializeLeafletMap = () => {
    const map = L.map('map').setView([48.8584, 2.2945], 13); // Paris Tour Eiffel

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
    }).addTo(map);
};
document.addEventListener("DOMContentLoaded", function () {
    const sections = document.querySelectorAll("section");
    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) entry.target.classList.add("visible");
        });
    }, { threshold: 0.1 });

    sections.forEach(section => observer.observe(section));
});























































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/
