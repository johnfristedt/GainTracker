var canvas = document.querySelector('#graph-canvas');
var ctx = canvas.getContext('2d');

function showGraph(graphData) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    var wait = setInterval(function () {
        var lineGraphData = {
            labels: graphData,
            datasets: [
                {
                    fillColor: "rgba(50,220,50,0.2)",
                    strokeColor: "rgba(50,220,50,1)",
                    pointColor: "rgba(50,220,50,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: graphData
                }
            ]
        }

        var chart = new Chart(ctx).Line(lineGraphData);

        clearInterval(wait);
    }, 2000);
}