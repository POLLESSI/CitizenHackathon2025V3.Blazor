const iconCache = {};

// Color according to level
function getLevelColor(level) {
    switch (level) {
        case 1: return "green";    // Weak
        case 2: return "orange";   // Moderate
        case 3: return "red";      // Pupil
        default: return "gray";
    }
}

// Creating a custom icon with a pulsing effect
function getLevelIcon(level) {
    if (iconCache[level]) return iconCache[level];

    const color = getLevelColor(level);
    const icon = L.divIcon({
        className: 'traffic-icon',
        html: `<div class="pulse-${color}"></div>`,
        iconSize: [16, 16],
        iconAnchor: [8, 8],
        popupAnchor: [0, -10]
    });

    iconCache[level] = icon;
    return icon;
}

// Interop global
window.mapInterop = (() => {
    let map = null;
    let markers = [];

    function initMap(mapId = "leaflet-map", lat = 50.894966, lng = 4.341545, zoom = 13) {
        if (map) return;

        const mapElement = document.getElementById(mapId);
        if (!mapElement) {
            console.warn(`❌ Élément #${mapId} introuvable dans le DOM.`);
            return;
        }

        map = L.map(mapId).setView([lat, lng], zoom);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; OpenStreetMap contributors'
        }).addTo(map);
    }

    function updateTrafficMarkers(events = []) {
        if (!map) {
            console.warn("❌ La carte n'est pas encore initialisée.");
            return;
        }

        // Deleting old markers
        markers.forEach(marker => map.removeLayer(marker));
        markers = [];

        // Adding new markers
        events.forEach(e => {
            const marker = L.marker([e.latitude, e.longitude], {
                icon: getLevelIcon(e.level)
            }).bindPopup(`
                <strong>${e.description}</strong><br/>
                ${new Date(e.timestamp).toLocaleString()}
            `);

            marker.addTo(map);
            markers.push(marker);
        });
    }

    return {
        initMap,
        updateTrafficMarkers
    };
})();

/*export { getLevelColor, getLevelIcon };*/
































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/