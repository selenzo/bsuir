/*jshint -W117, esversion: 6*/
window.onload = function () {
    var max = true;
    var canvas = Canvas();
    canvas.Init("canvas");
    var n = 4;
    var stepX = 50;
    var stepY = 50;
    //начальыне значения расстояний
    var points = Array(n).fillArrayRandom(n, 1, 10);
    //    var points = [[0, 0.3, 0.5, 2], [5, 0, 1, 0.6], [0.5, 1, 0, 2.5], [2, 0.6, 2.5, 0]];

    if (!max) {
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                points[i][j] = (1 / points[i][j]).toFixed(2);
            }
        }
        stepY = 1000;
    }
    //массив всех расстояний без повторений и отсортированный
    var pointsArray = [];
    //массив всех расстояний, которые будут отрисованы
    var distanceArray = [];
    //массив элементов в их очередности отрисовки на графике
    var graphArray = [];

    for (var i = 0; i < n; i++) {
        for (var j = i; j < n; j++) {
            if (i < j) {
                var temp = {
                    x1: i,
                    x2: j,
                    point: [-1, -1],
                    arr: [i, j],
                    value: points[i][j]
                };
                pointsArray.push(temp);
            } else {}
            points[j][i] = points[i][j];
            if (i === j) points[i][j] = 0;
        }
    }

    pointsArray = sortArray(pointsArray);

    var ok = true;
    while (ok) {
        var temp = pointsArray.shift();
        console.log(temp);
        if (graphArray.length < n) {
            if (inGraphArray(temp.x1, graphArray)) graphArray.push(temp.x1);
            if (inGraphArray(temp.x2, graphArray)) graphArray.push(temp.x2);
        }
        temp = unionReenter(temp, distanceArray, temp.x1);
        temp = unionReenter(temp, distanceArray, temp.x2);
        if (temp.arr.length >= n) ok = false;
        distanceArray.push(temp);
    }

    canvas.DrawLine(50, 0, 0, 50, 600, 1);
    canvas.DrawLine(0, 550, 0, 800, 550, 1);

    for (var i = 0; i < distanceArray.length; i++) {
        var tmp1 = graphArray.indexOf(distanceArray[i].x1);
        var tmp2 = 0;
        var tmp3 = graphArray.indexOf(distanceArray[i].x2);
        var tmp4 = 0;
        var tmp5 = distanceArray[i].value;

        if (distanceArray[i].point[0] != -1) {
            tmp1 = distanceArray[distanceArray[i].point[0]].center.x;
            tmp2 = distanceArray[distanceArray[i].point[0]].center.y;
        }
        if (distanceArray[i].point[1] != -1) {
            tmp3 = distanceArray[distanceArray[i].point[1]].center.x;
            tmp4 = distanceArray[distanceArray[i].point[1]].center.y;
        }
        distanceArray[i].center = {
            x: Math.abs(tmp3 - tmp1) / 2 + (distanceArray[i].point[1] != -1 ? tmp3 : tmp1),
            y: tmp5
        };

        tmp1 *= stepX;
        tmp2 *= stepY;
        tmp3 *= stepX;
        tmp4 *= stepY;
        tmp5 *= stepY;

        canvas.DrawLine(100 + tmp1, 550 - tmp2, 1, 100 + tmp1, 550 - tmp5, 2);
        canvas.DrawLine(100 + tmp3, 550 - tmp4, 1, 100 + tmp3, 550 - tmp5, 2);
        canvas.DrawLine(100 + tmp1, 550 - tmp5, 1, 100 + tmp3, 550 - tmp5, 2);

    }

    for (var i = 0; i < graphArray.length; i++) {
        canvas.DrawText(95 + i * stepX, 565, 0, "x" + graphArray[i]);
    }

    for (var i = 0; i < distanceArray.length; i++) {
        canvas.DrawText(20, 550 - distanceArray[i].value * stepY, 0, distanceArray[i].value);
    }

    var str = "<table><tr>";
    for (var i = -1; i < n; i++) str += (i === -1 ? "<td></td>" : "<td>x<sub>" + i + "</sub></td>");
    str += "</tr>";
    for (var i = 0; i < n; i++) {
        str += "<tr><td>x<sub>" + i + "</sub></td>";
        for (var j = 0; j < n; j++) {
            str += "<td>";
            str += points[i][j];
            str += "</td>";
        }
        str += "</tr>";
    }
    text.innerHTML = str + "</table><br>";

    console.log(graphArray);
    console.log(distanceArray);

    function unionReenter(temp, array, x) {
        var i = array.length - 1;
        var find = false;
        while (i > -1 && !find) {
            if (array[i].arr.indexOf(x) != -1) {
                temp.arr = unionArray(array[i].arr, temp.arr);
                if (temp.x1 === x) temp.point[0] = i;
                if (temp.x2 === x) temp.point[1] = i;
                find = true;
            }
            i--;
        }
        return temp;
    }

    function unionArray(arr1, arr2) {
        // объединяем массивы
        arr3 = arr1.concat(arr2);
        // сортируем полученный массив
        arr3.sort();
        // формируем новый массив без повторяющихся элементов
        var arr = [arr3[0]];
        for (var i = 1; i < arr3.length; i++) {
            if (arr3[i] != arr3[i - 1]) {
                arr.push(arr3[i]);
            }
        }
        return arr;
    }

    function inGraphArray(index, array) {
        for (var i = 0; i < array.length; i++) {
            if (index === array[i]) return false;
        }
        return true;
    }

    function sortArray(array) {
        if (array.length === 1) {
            return array;
        }
        for (var i = 0; i < array.length - 1; i++) {
            for (var j = i + 1; j < array.length; j++) {
                if (array[i].value > array[j].value) {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }

};
