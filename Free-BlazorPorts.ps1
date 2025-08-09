Write-Host "🔍 Recherche des processus 'dotnet' et 'iisexpress'..."

$targets = @('dotnet', 'iisexpress', 'CitizenHackathon2025.API') # Ajoute ici le nom exact de ton .exe si connu

foreach ($name in $targets) {
    $procs = Get-Process -Name $name -ErrorAction SilentlyContinue
    foreach ($proc in $procs) {
        try {
            Write-Host "🛑 Fermeture de $($proc.ProcessName) (PID $($proc.Id))..."
            Stop-Process -Id $proc.Id -Force
        }
        catch {
            Write-Warning "❌ Impossible de tuer $($proc.ProcessName): $_"
        }
    }
}

Write-Host "✅ Tous les processus ciblés ont été terminés (si présents)."