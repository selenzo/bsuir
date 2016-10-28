function Canvas() {
    var _obj = {},
        canvas = null,
        ctx = null,
        colors = ["#000000", "#ff0000", "#00ff00", "#00ffff", "#0000ff", "#0b670b", "#ffff00", "#ff00ff", "#797915", "#ff66cc"];

    function DrawPixel(x, y, c, size) {
        ctx.fillStyle = colors[c];
        ctx.fillRect(x, y, size, size);
    }

    function DrawPixel2(x, y, c, x1, x2) {
        ctx.beginPath();
        ctx.strokeStyle = colors[c];
        ctx.moveTo(x, y);
        ctx.lineTo(x1, x2);
        ctx.stroke();
    }

    _obj.DrawArray = function (arr, size) {
        for (var i = 0; i < arr.length; i++) {
            DrawPixel(arr[i].x, arr[i].y, arr[i].c, size);
        }
    }

    _obj.DrawArray2 = function (arr, arr2) {
        for (var i = 0; i < arr.length; i++) {
            DrawPixel2(arr[i].x, arr[i].y, arr[i].c, arr2[arr[i].c].x, arr2[arr[i].c].y);
        }

    }

    _obj.Clear = function () {
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
    var run = true;
    var c = 2;
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

    var temp1 = -1;
    var temp2 = -1;
    var max = 0;
    for (var i = 0; i < n - 1; i++) {
        for (var j = i; j < n; j++) {
            var temp = Math.sqrt(Math.pow(points[i].x - points[j].x, 2) + Math.pow(points[i].y - points[j].y, 2));
            if (max < temp) {
                max = temp;
                temp1 = i;
                temp2 = j;
            }
        }
    }

    centers[0] = {
        x: points[temp1].x,
        y: points[temp1].y,
        c: 0
    };
    centers[1] = {
        x: points[temp2].x,
        y: points[temp2].y,
        c: 1
    };
    while (run) {
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

        var sum = 0;
        var temp = 0;
        for (var i = 0; i < c - 1; i++) {
            for (var j = i; j < c; j++) {
                temp = Math.sqrt(Math.pow(centers[i].x - centers[j].x, 2) + Math.pow(centers[i].y - centers[j].y, 2));
                sum += temp;
            }
        }
        temp1 = 0;

        max = 0;
        for (var i = 0; i < c; i++) {
            for (var j = 0; j < n; j++) {
                if (points[j].c === i) {
                    temp = Math.sqrt(Math.pow(centers[i].x - points[j].x, 2) + Math.pow(centers[i].y - points[j].y, 2));
                    if (temp > max) {
                        max = temp;
                        temp1 = j;
                    }
                }
            }
        }

        temp2 = 0;
        var min = 0;
        for (var i = 0; i < c; i++) {
            temp = Math.sqrt(Math.pow(centers[i].x - points[temp1].x, 2) + Math.pow(centers[i].y - points[temp1].y, 2));
            if (temp > min) {
                min = temp;
                temp2 = i;
            }
        }

        if (min > sum / (c * 2 )) {

            centers[c] = {
                x: points[temp1].x,
                y: points[temp1].y,
                c: c
            };
            c++;
        } else {
            run = false;
        }
    }
        a.DrawArray2(points, centers);
    a.DrawArray(centers, 10);


}
