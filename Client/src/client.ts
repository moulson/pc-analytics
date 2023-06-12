const API_URL: string = "https://localhost:44385/";

setInterval(getMetrics, 1000);

function getMetrics(): void{
    fetch(API_URL).then((response) => {
        response.json().then((data) => {
            updateValues(data);
        });
    });
}

function updateValues(data){
    const CPULoadGauge = document.getElementById("cpu-gauge");
    const CPULoad = document.getElementById("cpu-load-text");
    CPULoadGauge!.style.transform = `rotate(${data.CPULoad["CPU Total"] * 1.8}deg)translate3d(0,0,0)`;
    CPULoad!.textContent = `${Math.floor(data.CPULoad["CPU Total"])}%`;
}