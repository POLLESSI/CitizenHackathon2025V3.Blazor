export function startBackgroundCanvas() {
    const canvas = document.getElementById("layoutBackgroundCanvas");
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    let width = canvas.width = window.innerWidth;
    let height = canvas.height = 300;

    const stars = Array.from({ length: 60 }, () => ({
        x: Math.random() * width,
        y: Math.random() * height,
        radius: Math.random() * 2,
        speed: 0.5 + Math.random()
    }));

    function animate() {
        ctx.clearRect(0, 0, width, height);
        ctx.fillStyle = "#fff";

        for (let s of stars) {
            ctx.beginPath();
            ctx.arc(s.x, s.y, s.radius, 0, Math.PI * 2);
            ctx.fill();

            s.x -= s.speed;
            if (s.x < 0) {
                s.x = width;
                s.y = Math.random() * height;
            }
        }

        requestAnimationFrame(animate);
    }

    animate();
}

