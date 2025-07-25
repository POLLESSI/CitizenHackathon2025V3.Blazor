export function showSuggestionsOnMap(suggestions) {
    if (!window.leafletMap) return;

    suggestions.forEach(suggestion => {
        const icon = L.icon({
            iconUrl: "/icons/suggestion-marker.png",
            iconSize: [32, 32]
        });

        const marker = L.marker([suggestion.latitude, suggestion.longitude], { icon })
            .addTo(window.leafletMap)
            .bindPopup(`<strong>${suggestion.title}</strong><br/>À ${suggestion.distanceKm} km`);
    });
}
















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/