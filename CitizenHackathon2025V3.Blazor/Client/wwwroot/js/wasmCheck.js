window.checkWasmFile = async function () {
    try {
        const response = await fetch('/_framework/dotnet.native.wasm');
        return response.ok;
    } catch (err) {
        console.error("Erreur accès wasm :", err);
        return false;
    }
};


































































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/