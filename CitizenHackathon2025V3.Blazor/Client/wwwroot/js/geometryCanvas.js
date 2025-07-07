export function startCanvas(canvasId) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error(`❌ Canvas with id '${canvasId}' not found.`);
        return;
    }

    const ctx = canvas.getContext("2d");
    if (!ctx) {
        console.error("❌ Unable to get 2D context");
        return;
    }

    let angle = 0;
    let time = 0;
    const shapes = [];

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        angle += 0.01;
        time += 0.05;
        shapes.forEach(shape => drawShape(shape));
        requestAnimationFrame(draw);
    }

    function drawCube(x, y, size, pulse) {
        ctx.save();
        ctx.translate(x, y);
        ctx.rotate(angle);
        ctx.fillStyle = "#b30000";
        ctx.fillRect(-size / 2 * pulse, -size / 2 * pulse, size * pulse, size * pulse);
        ctx.restore();
    }

    function drawSphere(x, y, radius, pulse) {
        ctx.beginPath();
        const gradient = ctx.createRadialGradient(x - radius / 4, y - radius / 4, radius / 8, x, y, radius);
        gradient.addColorStop(0, "#ff4d4d");
        gradient.addColorStop(1, "#400000");
        ctx.fillStyle = gradient;
        ctx.arc(x, y, radius * pulse, 0, Math.PI * 2);
        ctx.fill();
    }

    function drawCone(x, y, height, pulse) {
        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x - height / 2 * pulse, y + height * pulse);
        ctx.lineTo(x + height / 2 * pulse, y + height * pulse);
        ctx.closePath();
        ctx.fillStyle = "#a00000";
        ctx.fill();
    }

    function drawShape(shape) {
        const pulse = 1 + 0.1 * Math.sin(time + shape.offset);
        switch (shape.type) {
            case "cube": drawCube(shape.x, shape.y, shape.size, pulse); break;
            case "sphere": drawSphere(shape.x, shape.y, shape.radius, pulse); break;
            case "cone": drawCone(shape.x, shape.y, shape.height, pulse); break;
        }
    }

    function addShape(shape) {
        shape.offset = Math.random() * 10;
        shapes.push(shape);
    }

    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    addShape({ type: "sphere", x: centerX - 200, y: centerY, radius: 40 });
    addShape({ type: "cube", x: centerX, y: centerY, size: 60 });
    addShape({ type: "cone", x: centerX + 200, y: centerY - 30, height: 60 });

    draw();

    return { addShape };
}































































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/