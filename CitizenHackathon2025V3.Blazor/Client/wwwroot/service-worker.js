// service-worker.js - Dev Mode

// In development, always fetch from the network and do not enable offline support.
// This avoids caching issues that hinder rapid iteration.

self.addEventListener("install", () => {
    console.log("✅ Service worker installed (dev mode)");
    // Immediate activation
    self.skipWaiting();
});

self.addEventListener("activate", event => {
    console.log("✅ Service worker activated (dev mode)");
    return self.clients.claim();
});

self.addEventListener("fetch", event => {
    // Skip caching: Always fetch from network
    event.respondWith(fetch(event.request));
});












































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/