/*jshint -W117, esversion: 6*/

function Canvas() {
    var _obj = {},
        canvas = null,
        ctx = null,
        colors = ["#000000", "#ff0000", "#00ff00", "#00ffff", "#0000ff", "#0b670b", "#ffff00", "#ff00ff", "#797915", "#ff66cc"];

    function DrawPixel(x, y, c, size) {
        ctx.fillStyle = colors[c];
        ctx.fillRect(x, y, size, size);
    }

    _obj.DrawLine = function (x, y, c, x1, x2, k) {
        ctx.beginPath();
        ctx.lineWidth = k;
        ctx.strokeStyle = colors[c];
        ctx.moveTo(x, y);
        ctx.lineTo(x1, x2);
        ctx.stroke();
    };

    _obj.DrawArray = function (arr, size) {
        for (var i = 0; i < arr.length; i++) {
            DrawPixel(arr[i].x, arr[i].y, arr[i].c, size);
        }
    };

    _obj.DrawArray2 = function (arr, arr2) {
        for (var i = 0; i < arr.length; i++) {
            DrawPixel2(arr[i].x, arr[i].y, arr[i].c, arr2[arr[i].c].x, arr2[arr[i].c].y);
        }
    };

    _obj.Clear = function () {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    };

    _obj.Init = function (canvasId) {
        canvas = document.getElementById(canvasId);
        ctx = canvas.getContext('2d');
    };

    return _obj;
}

function Gauss(x, mx, sigma, pc) {
    var temp = 0;
    temp = Math.exp(-0.5 * Math.pow((x - 100 - mx) / sigma, 2)) * pc / (sigma * Math.sqrt(2 * Math.PI));
    return temp;
}

window.onload = function () {
    var tick = document.getElementById("text");
    var canvas = Canvas();
    canvas.Init("canvas");

    //количество точек
    var pointsCount = 10000;
    //вероятности p(c1) и p(c2)
    var pc1 = 0.6;
    var pc2 = 1 - pc1;
    //наборы точек
    var points1 = Array(pointsCount).fillRandom(100, 600);
    var points2 = Array(pointsCount).fillRandom(-100, 400);
    //математическое ожидание
    var mx1 = points1.mx();
    var mx2 = points2.mx();
    //среднеквадратичное отклонение
    var sigma1 = points1.sigma();
    var sigma2 = points2.sigma();
    //коэфициенты для графика
    var k = 100000;
    var height = 550;
    var width = 800;
    //результирующий график
    var result1 = Array(width);
    var result2 = Array(width);
    //вероятность ложной тревоги
    var error1 = 0;
    //вероятность пропуска обнаружения
    var error2 = 0;

    var temp = 0;
    var X = 0;

    for (var i = 0; i < width; i++) {
        result1[i] = Gauss(i, mx1, sigma1, pc1);
        result2[i] = Gauss(i, mx2, sigma2, pc2);
        canvas.DrawLine(i - 1, height - result1[i - 1] * k, 1, i, height - result1[i] * k, 2);
        canvas.DrawLine(i - 1, height - result2[i - 1] * k, 4, i, height - result2[i] * k, 2);

        if (Math.abs(result1[i] * 100 - result2[i] * 100) < 0.001) {
            X = i;
        }
    }

    for (i = 0; i < width; i++) {
        error1 += (i < X ? result2[i] : 0);
        error2 += (i > X ? (pc1 > pc2 ? result2[i] : result1[i]) : 0);
    }

    canvas.DrawLine(X, 0, 2, X, height, 2);

    canvas.DrawLine(100, 0, 0, 100, height, 3);
    canvas.DrawLine(100, 0, 0, 90, 20, 3);
    canvas.DrawLine(100, 0, 0, 110, 20, 3);

    canvas.DrawLine(0, height, 0, width, height, 3);
    canvas.DrawLine(width - 20, height - 10, 0, width, height, 3);
    canvas.DrawLine(width - 20, height + 10, 0, width, height, 3);

    tick.innerHTML = "Вероятность ложной тревоги: " + error1 + "<br>Вероятность пропуска обнаружения: " + error2 + "<br>Суммарная ошибка классификации: " + (error1 + error2);
};
