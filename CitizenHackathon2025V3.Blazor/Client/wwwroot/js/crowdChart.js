export function initCrowdChart() {
    const ctx = document.getElementById('crowdChart')?.getContext('2d');
    if (!ctx) {
        console.warn("📉 #crowdChart not found.");
        return;
    }

    window.crowdChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [],
            datasets: [{
                label: 'Crowd Level (%)',
                data: [],
                borderColor: '#FFD700',
                backgroundColor: 'rgba(255,215,0,0.3)'
            }]
        },
        options: {
            scales: {
                y: { beginAtZero: true, max: 100 }
            }
        }
    });
}

export function updateCrowdChart(val) {
    const now = new Date().toLocaleTimeString();
    const chart = window.crowdChart;
    if (!chart) return;

    chart.data.labels.push(now);
    chart.data.datasets[0].data.push(parseInt(val));

    if (chart.data.labels.length > 20) {
        chart.data.labels.shift();
        chart.data.datasets[0].data.shift();
    }

    chart.update();
}



































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/