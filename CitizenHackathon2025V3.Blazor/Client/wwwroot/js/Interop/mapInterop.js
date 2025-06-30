hubConnection.On < WazeFeed > ("ReceiveTraffic", feed => {
    TrafficInfo = $"{feed.Jams.Count} slowdowns, {feed.Alerts.Count} alerts";
    StateHasChanged();
});
window.mapInterop = {
    markers: {},
    iconCache: {},

    getIcon(level) {
        if (this.iconCache[level]) return this.iconCache[level];

        const colorMap = {
            1: "green",
            2: "orange",
            3: "red"
        };
        const icon = L.divIcon({
            className: 'traffic-icon',
            html: `<div class='pulse-${colorMap[level]}'></div>`,
            iconSize: [16, 16]
        });

        this.iconCache[level] = icon;
        return icon;
    }
}
window.mapInterop = (function () {
    let map;
    let markers = [];

    function getLevelColor(level) {
        switch (level) {
            case 1: return 'green';    // Low
            case 2: return 'orange';   // Medium
            case 3: return 'red';      // High
            default: return 'gray';
        }
    }

    return {
        initMap: function () {
            if (map) return; // already initialized

            map = L.map('leaflet-map').setView([48.8566, 2.3522], 11); // Paris

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; OpenStreetMap contributors'
            }).addTo(map);
        },
        updateTrafficMarkers: function (events) {
            if (!map) {
                console.warn("Map not initialized yet.");
                return;
            }

            // Deletes old markers
            markers.forEach(m => map.removeLayer(m));
            markers = [];

            events.forEach(e => {
                const marker = L.circleMarker([e.latitude, e.longitude], {
                    radius: 10,
                    color: getLevelColor(e.level),
                    fillOpacity: 0.8
                }).bindPopup(`<strong>${e.description}</strong><br>${new Date(e.timestamp).toLocaleString()}`);

                marker.addTo(map);
                markers.push(marker);
            });
        }
    };
})();
}


































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/