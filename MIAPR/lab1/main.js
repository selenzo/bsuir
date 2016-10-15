function Canvas() {
    var _obj = {},
        canvas = null,
        ctx = null,
        colors = ["#000000", "#ff0000", "#00ff00", "#00ffff", "#0000ff", "#137413", "#ffff00", "#ff00ff", "#f7a762", "#ff66cc"];

    function DrawPixel(x, y, c, size) {
        ctx.fillStyle = colors[c];
        ctx.fillRect(x, y, size, size);
    }

    _obj.DrawArray = function (arr, size) {
        for (var i = 0; i < arr.length; i++) {
            DrawPixel(arr[i].x, arr[i].y, arr[i].c, size);
        }
    }

    _obj.Clear = function() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }

    _obj.Init = function (canvasId) {
        canvas = document.getElementById(canvasId);
        ctx = canvas.getContext('2d');
    }

    return _obj;
}

function randomInteger(min, max) {
    var rand = min + Math.random() * (max - min)
    rand = Math.round(rand);
    return rand;
}

window.onload = function () {
    var tickCount = 0;
    var n = 10000;
    var c = 10;
    var a = Canvas();
    a.Init("canvas");

    var points = [];
    var centers = [];

    for (var i = 0; i < n; i++) {
        points[i] = {
            x: randomInteger(0, 800),
            y: randomInteger(0, 600),
            c: 0
        };
    }

    for (var i = 0; i < c; i++) {
        var temp = Math.floor((n - 1) / (i + 1));
        centers[i] = {
            x: points[temp].x,
            y: points[temp].y,
            c: i
        }
    }

    function Tick() {
        tickCount++;

        //задание цвета относительно центров
        for (var i = 0; i < n; i++) {
            var min = 100000;
            var temp_j = c + 1;
            var temp = 0;
            for (var j = 0; j < c; j++) {
                temp = Math.sqrt(Math.pow(points[i].x - centers[j].x, 2) + Math.pow(points[i].y - centers[j].y, 2));

                if (temp < min) {
                    min = temp;
                    temp_j = j;
                }
            }
            points[i].c = temp_j;
        }

        //вычисление нового центра как средняя точка между максимально удаленными объектами
        for (var j = 0; j < c; j++) {
            var max = 0;
            var temp1 = {
                x: n + 1,
                y: n + 1
            };
            var temp2 = {
                x: n + 1,
                y: n + 1
            };
            for (var i = 0; i < n - 1; i++) {
                for (var g = i; g < n; g++) {

                    if (points[i].c === j && j === points[g].c) {
                        var temp = Math.sqrt(Math.pow(points[i].x - points[g].x, 2) + Math.pow(points[i].y - points[g].y, 2));
                        if (temp > max) {
                            temp1.x = points[i].x;
                            temp1.y = points[i].y;
                            temp2.x = points[g].x;
                            temp2.y = points[g].y;
                            max = temp;
                        }
                    }
                }
            }

            var tempX = (temp1.x + temp2.x) / 2;
            var tempY = (temp1.y + temp2.y) / 2;
            //        console.log(tempX);

            var min = 100000;
            var temp_x = n + 1;
            var temp_y = n + 1;
            var point = n + 1;
            for (var i = 0; i < n; i++) {
                if (points[i].c === j) {
                    temp = Math.sqrt(Math.pow(points[i].x - tempX, 2) + Math.pow(points[i].y - tempY, 2));

                    if (temp < min) {
                        min = temp;
                        temp_x = points[i].x;
                        temp_y = points[i].y;
                        point = i;
                    }
                }

            }
            //        console.log(point);
            centers[j].x = points[point].x;
            centers[j].y = points[point].y;

        }


            a.Clear();
        a.DrawArray(points, 2);
        a.DrawArray(centers, 10);




        console.log(tickCount);
    }

    setInterval(Tick, 500);
//    Tick();


}
