window.scrollInterop = {
    getScrollTop: () => window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0,
    getScrollHeight: (elementId) => {
        const el = document.getElementById(elementId);
        return el ? el.scrollHeight : 0;
    },
    getClientHeight: (elementId) => {
        const el = document.getElementById(elementId);
        return el ? el.clientHeight : 0;
    }
};























































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/