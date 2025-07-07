window.checkWasmFile = async function () {
    try {
        const response = await fetch('/_framework/dotnet.native.wasm');
        return response.ok;
    } catch (err) {
        console.error("Erreur accès wasm :", err);
        return false;
    }
};
