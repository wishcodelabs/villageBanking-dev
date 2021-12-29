
window.setup = (searchChartdata,clicksData,applyChartData,admissionData,consolData ) => {
    new Chart(document.getElementById("chartjs-7"), {
        "type": "bar",
        "data": {
            "labels": ["January", "February", "March", "April"],
            "datasets": [{
                "label": "Search Appearances",
                "data": searchChartdata,
                "borderColor": "rgb(255, 99, 132)",
                "backgroundColor": "rgba(255, 99, 132, 0.2)"
            }, {
                "label": "Ad Clicks",
                "data": clicksData,
                "type": "line",
                "fill": false,
                "borderColor": "rgb(54, 162, 235)"
            }]
        },
        "options": {
            "scales": {
                "yAxes": [{
                    "ticks": {
                        "beginAtZero": true
                    }
                }]
            }
        }
    });
    new Chart(document.getElementById("chartjs-0"), {
        "type": "line",
        "data": {
            "labels": ["January", "February", "March", "April", "May", "June", "July"],
            "datasets": [{
                "label": "Applications Received",
                "data": applyChartData,
                "fill": false,
                "borderColor": "rgb(75, 192, 192)",
                "lineTension": 0.1
            }]
        },
        "options": {}
    });

    new Chart(document.getElementById("chartjs-1"), {
        "type": "bar",
        "data": {
            "labels": ["January", "February", "March", "April", "May", "June", "July"],
            "datasets": [{
                "label": "Addmissions",
                "data": admissionData,
                "fill": false,
                "backgroundColor": ["rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
                "borderColor": ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(54, 162, 235)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
                "borderWidth": 1
            }]
        },
        "options": {
            "scales": {
                "yAxes": [{
                    "ticks": {
                        "beginAtZero": true
                    }
                }]
            }
        }
    });

    new Chart(document.getElementById("chartjs-4"), {
        "type": "doughnut",
        "data": {
            "labels": ["Paid", "Accepted", "Rejected"],
            "datasets": [{
                "label": "Issues",
                "data": consolData, 
                "backgroundColor": ["rgb(255, 99, 132)", "rgb(54, 162, 235)", "rgb(255, 205, 86)"]
            }]
        },
        "options": {
            "scales": {
                "yAxes": [{
                    "ticks": {
                        "beginAtZero": true
                    }
                }]
            }
        }
    });
}