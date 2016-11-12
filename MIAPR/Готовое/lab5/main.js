/*jshint -W117, esversion: 6*/
window.onload = function () {
    var points = [
        {
            x: -1,
            y: 0,
            c: 0
        },
        {
            x: 1,
            y: 1,
            c: 0
        },
        {
            x: 2,
            y: 0,
            c: 1
        },
        {
            x: 1,
            y: -2,
            c: 1
        }
    ];
    //результирующий массив формата: Х коэфициент, Y коэфициент, XY коэфициент, свободный член
    var result = [0, 0, 0, 0];
    var correction = 1;
    var canvas = Canvas();
    canvas.Init("canvas");

    var iterationsCount = 0;
    var ok = true;
    while (ok && iterationsCount++ < 1000) {
        ok = false;
        for (var i = 0; i < 4; i++) {
            result = result.sumArray(potencialFunction(points[i]).map(el => el * correction));
            var nextPoint = points[(i != 3 ? i + 1 : 0)];
            var functionValue = getFunctionValue(result, nextPoint);
            correction = 0;
            if (functionValue < 0 && (i < 1 || i > 2)) {
                correction = 1;
            }
            if (functionValue > 0 && i > 0 && i < 3) {
                correction = -1;
            }
            if (correction != 0) ok = true;
        }
    }

    var pointsArray = Array();
    var x = -400;

    while (x < 400) {
        var temp = {};
        temp.x = x;
        temp.y = getY(result, x);
        temp.c = 1;
        pointsArray.push(temp);
        x += 0.01;
    }
    canvas.DrawArray2(pointsArray, 1);
    canvas.DrawArray(points, 5);
    canvas.DrawLine(400, 0, 0, 400, 600, 1);
    canvas.DrawLine(0, 300, 0, 800, 300, 1);

    document.getElementById("res").innerHTML = "Разделяющая функция: " + resultToString(result);

    function resultToString(res) {
        if (res[2] != 0) {
            return "y=(" + -res[0] + "*x" + (-res[3] < 0 ? "" : "+") + -res[3] + ")/(" + res[2] + "*x" + (res[1] < 0 ? "" : "+") + res[1] + ")";
        }
        if (res[1] != 0) {
            return "y=" + -res[0] / res[1] + "*x" + (-res[3] / res[1] < 0 ? "" : "+") + -res[3] / res[1];
        }
        return "x=" + -res[3] / res[0];
    }

    btn0.onclick = function () {
        var tempPoint = [{
            x: parseInt(document.getElementById("inp0").value),
            y: parseInt(document.getElementById("inp1").value),
            c: 2
        }];
        var temp = (getFunctionValue(result, tempPoint[0]) >= 0 ? 0 : 1);
        document.getElementById("text").innerHTML = "Принадлежит классу " + (temp + 1);
        tempPoint[0].c = (temp === 0 ? 2 : 1);
        canvas.DrawArray(tempPoint, 10);
    }

    function getY(func, x) {
        return -(func[0] * x + func[3]) / (func[2] * x + func[1]);
    }

    //начальная функция
    function potencialFunction(point) {
        var temp = Array(4);
        temp[0] = 4 * point.x;
        temp[1] = 4 * point.y;
        temp[2] = 16 * point.x * point.y;
        temp[3] = 1;
        return temp;
    }

    //Находим значение функции с данными координатами в следующей точке
    function getFunctionValue(func, point) {
        return func[0] * point.x + func[1] * point.y + func[2] * point.x * point.y + func[3];
    }

};
