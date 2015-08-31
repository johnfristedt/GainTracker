function showGraph(graphData) {
    console.log('test');
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

        var ctx = document.getElementById('graph-canvas').getContext('2d');
        var chart = new Chart(ctx).Line(lineGraphData);

        clearInterval(wait);
    }, 2000);
}