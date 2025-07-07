// service-worker.js - Dev Mode

// In development, always fetch from the network and do not enable offline support.
// This avoids caching issues that hinder rapid iteration.

self.addEventListener("install", () => {
    console.log("✅ Service worker installed (dev mode)");
});

self.addEventListener("activate", event => {
    console.log("✅ Service worker activated (dev mode)");
    return self.clients.claim();
});

self.addEventListener("fetch", event => {
    // Skip caching: Always fetch from network
    return;
});
// Disabled to avoid dev caching
self.addEventListener('fetch', () => { });