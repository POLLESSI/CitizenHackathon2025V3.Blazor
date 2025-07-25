window.signalrInterop = {
    startConnection: async (hubUrl) => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .withAutomaticReconnect()
            .build();

        connection.on("NewCrowdEvent", (data) => {
            const shape = {
                type: data.type,
                x: data.x,
                y: data.y,
                size: data.size || 60,
                radius: data.radius || 40,
                height: data.height || 60
            };

            if (window.GeometryCanvas) {
                window.GeometryCanvas.addShape(shape);
            }
        });

        try {
            await connection.start();
            console.log(`✅ SignalR connected to ${hubUrl}`);
        } catch (err) {
            console.error("❌ SignalR error:", err);
        }
    }
};


















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/