window.OutZenTimeEffects = {
    init: function () {
        const hour = new Date().getHours();

        if (hour < 8) OutZenTimeEffects.spawnFireflies();
        else if (hour < 17) OutZenTimeEffects.animateLeaves();
        else if (hour < 20) OutZenTimeEffects.animateSunset();
        else OutZenTimeEffects.spawnStars();
    },

    spawnStars: function () {
        const container = document.body;
        for (let i = 0; i < 60; i++) {
            const star = document.createElement('div');
            star.className = 'oz-star';
            star.style.left = Math.random() * 100 + '%';
            star.style.top = Math.random() * 100 + '%';
            container.appendChild(star);
        }
    },

    spawnFireflies: function () {
        const container = document.body;
        for (let i = 0; i < 30; i++) {
            const firefly = document.createElement('div');
            firefly.className = 'oz-firefly';
            firefly.style.left = Math.random() * 100 + '%';
            firefly.style.top = Math.random() * 100 + '%';
            container.appendChild(firefly);
        }
    },

    animateLeaves: function () {
        const container = document.body;
        for (let i = 0; i < 25; i++) {
            const leaf = document.createElement('div');
            leaf.className = 'oz-leaf';
            leaf.style.left = Math.random() * 100 + '%';
            container.appendChild(leaf);
        }
    },

    animateSunset: function () {
        const container = document.body;
        const sun = document.createElement('div');
        sun.className = 'oz-sunset';
        container.appendChild(sun);
    }
};

document.addEventListener('DOMContentLoaded', function () {
    OutZenTimeEffects.init();
});