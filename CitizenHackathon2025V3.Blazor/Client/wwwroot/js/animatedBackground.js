﻿window.initAnimatedBackground = () => {
    console.log("✨ initAnimatedBackground() called");
    const svg = document.getElementById("animated-svg");
    const stop1 = document.getElementById("stop1");
    const stop2 = document.getElementById("stop2");

    if (!svg || !stop1 || !stop2) return;

    // Color animation
    let hue = 0;
    setInterval(() => {
        hue = (hue + 1) % 360;
        const color1 = `hsl(${hue}, 100%, 60%)`;
        const color2 = `hsl(${(hue + 120) % 360}, 100%, 60%)`;
        stop1.setAttribute("stop-color", color1);
        stop2.setAttribute("stop-color", color2);
    }, 50);

    // Mouse parallax effect
    document.addEventListener("mousemove", (e) => {
        const x = (e.clientX / window.innerWidth - 0.5) * 10;
        const y = (e.clientY / window.innerHeight - 0.5) * 10;
        svg.style.transform = `rotateX(${y}deg) rotateY(${x}deg) scale(1.05)`;
    });

    document.addEventListener("mouseleave", () => {
        svg.style.transform = "rotateX(0deg) rotateY(0deg)";
    });

    // React to scroll (zoom or deformation)
    document.addEventListener("scroll", () => {
        const scrollY = window.scrollY;
        const intensity = Math.min(scrollY / 1000, 1); // max 1
        svg.style.transform += ` scale(${1 + intensity * 0.05})`;
    });
    document.body.style.background = "linear-gradient(135deg, #000428, #004e92)";
};






























































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/