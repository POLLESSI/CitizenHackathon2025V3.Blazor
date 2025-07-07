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


