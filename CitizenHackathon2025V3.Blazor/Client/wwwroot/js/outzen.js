// Leaflet
window.outzen = {
    initializeLeafletMap: () => {
        const map = L.map('leafletMap').setView([48.8584, 2.2945], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; OpenStreetMap contributors'
        }).addTo(map);

        L.marker([48.8584, 2.2945]).addTo(map)
            .bindPopup('Tourist activity : Eiffel Tower')
            .openPopup();
    },
    // Scroll Animations
    initScrollAnimations: () => {
        const revealElements = document.querySelectorAll('.scroll-reveal');
        const observer = new IntersectionObserver(entries => {
            entries.forEach(e => {
                if (e.isIntersecting) e.target.classList.add('visible');
            });
        }, { threshold: 0.1 });

        revealElements.forEach(el => observer.observe(el));
    }
};
// Chart.js
window.initCrowdChart = () => {
    const ctx = document.getElementById('crowdChart').getContext('2d');
    window.crowdChart = new Chart(ctx, {
        type: 'line',
        data: { labels: [], datasets: [{ label: 'Crowd (%)', data: [], borderColor: '#FFD700', backgroundColor: 'rgba(255,215,0,0.2)' }] },
        options: { scales: { y: { beginAtZero: true, max: 100 } } }
    });
};

window.updateCrowdChart = (val) => {
    const now = new Date().toLocaleTimeString();
    const num = parseInt(val);
    const chart = window.crowdChart;
    chart.data.labels.push(now);
    chart.data.datasets[0].data.push(num);
    if (chart.data.labels.length > 20) {
        chart.data.labels.shift();
        chart.data.datasets[0].data.shift();
    }
    chart.update();
};

// OpenWeather API
window.getOpenWeatherInfo = async () => {
    try {
        /*const res = await fetch('https://api.openweathermap.org/data/2.5/weather?q=Waterloo&units=metric&appid=YOUR_APPID');*/
        const json = await res.json();
        if (!res.ok) throw new Error(`HTTP ${res.status}`);
        return `🌡️ ${json.main.temp}°C, ${json.weather[0].description}`;
    } catch (ex) {
        console.error("Error fetching OpenWeather data:", ex);
        return { error: ex.message || "Network error" };
    }
};

// Waze Traffic (simulation)
window.getWazeTrafficInfo = async () => {
    try {
        const res = await fetch("https://localhost:7254/traffic/latest"); // use the full URL of API
        if (!res.ok) throw new Error(`HTTP ${res.status}`);
        return await res.json();
    } catch (e) {
        console.error("Waze Traffic Error:", e);
        return { error: e.message || "Network error" };
    }
};

    window.toggleDarkMode = () => {
        document.body.classList.toggle("dark-mode");
    };






















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/