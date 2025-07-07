let map;
let crowdMarkers = {};
let filterLevel = null;

const crowdIcons = {
    0: L.divIcon({ className: 'crowd-icon level-0', html: '🟢' }),
    1: L.divIcon({ className: 'crowd-icon level-1', html: '🟡' }),
    2: L.divIcon({ className: 'crowd-icon level-2', html: '🟠' }),
    3: L.divIcon({ className: 'crowd-icon level-3', html: '🔴' }),
};

export function initializeCrowdMap(mapId, centerLat, centerLng, zoom) {
    map = L.map(mapId).setView([centerLat, centerLng], zoom);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19
    }).addTo(map);
}

export function setFilterLevel(level) {
    filterLevel = level;
    updateVisibleMarkers();
}

function updateVisibleMarkers() {
    for (let id in crowdMarkers) {
        const m = crowdMarkers[id];
        const show = filterLevel === null || m.level === filterLevel;
        show ? m.marker.addTo(map) : map.removeLayer(m.marker);
    }
}

export function addOrUpdateCrowdMarker(id, lat, lng, level, info) {
    if (crowdMarkers[id]) {
        map.removeLayer(crowdMarkers[id].marker);
    }

    const marker = L.marker([lat, lng], {
        icon: crowdIcons[level] || crowdIcons[0]
    }).bindPopup(`<strong>${info.title}</strong><br/>${info.description}`);
    marker.addTo(map);
    blinkEffect(marker);
    crowdMarkers[id] = { marker, level };
}

function blinkEffect(marker) {
    const el = marker.getElement();
    if (!el) return;
    el.classList.add('fade-in', 'blink');
    setTimeout(() => el.classList.remove('blink'), 2000);
}

export function removeCrowdMarker(id) {
    if (crowdMarkers[id]) {
        map.removeLayer(crowdMarkers[id].marker);
        delete crowdMarkers[id];
    }
}















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/