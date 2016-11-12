/*jshint -W117, esversion: 6*/
window.onload = function () {
    //количество классов
    var N = 3;
    //количество признаков
    var K = 2;
    //массив обучающих векторов
    var teachingVectors = Array(N).fillArrayRandom(K + 1, -10, 10);
    //массив разделяющих функций
    var funcs = Array(N).fillArrayRandom(K + 1, 0, 0);
    //дополняем образы
    for (var i = 0; i < teachingVectors.length; i++) {
        teachingVectors[i][teachingVectors[i].length - 1] = 1;
    }
    //находим искомые функции
    funcs = perceptron(teachingVectors, funcs);

    var str = "Классы и образы: <br>";
    for (var i = 0; i < N; i++) {
        str += (i + 1) + " класс: <br>[" + teachingVectors[i].toString() + "]<br>";
    }

    str += "<br>Разделяющие функции:<br>";
    for (var i = 0; i < N; i++) {
        str += "d<sub>" + (i + 1) + "</sub>(x) =";
        for (var j = 0; j < K; j++) {
            str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]) + "x<sub>" + (j + 1) + "</sub>";
        }
        str += (funcs[i][j] > 0 ? " " : " - ") + Math.abs(funcs[i][j]) + " = ";

        for (var j = 0; j < K; j++) {
            if (funcs[i][j] != 0) {
                str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]) + "x<sub>" + (j + 1) + "</sub>";
            }
        }
        if (funcs[i][j] != 0) {
            str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]);
        }
        str += "<br>";
    }

    document.getElementById("text").innerHTML = str;

    str = 'Классифицировать вектор: <br><table><tr>';
    for (var i = 0; i < K; i++) {
        str += '<td><input type="text" id="inp' + i + '"></td>';
    }
    str += '<td><input type="text" id="inpLast" value="1" disabled></td><td><button id="btn0">Классифицировать</button></td></tr></table>';
    document.getElementById("inp").innerHTML = str;

    btn0.onclick = function () {
        var arr = Array(K);
        for (var i = 0; i < K; i++) {
            arr[i] = parseInt(document.getElementById("inp" + i).value);
        }
        arr.push(1);

        var results = Array(funcs.length);
        for (var i = 0; i < funcs.length; i++) {
            results[i] = (funcs[i].multiplyArray(arr)).reduce((a, b) => a + b);
        }
        var max = results.getMax();
        document.getElementById("res").innerHTML = "Данный вектор принадлежит " + (max.index + 1) + " классу";
    }
};

/**
 * КЛАССИФИКАЦИЯ ОБЪЕКТОВ НА N КЛАССОВ МЕТОДОМ ПЕРСЕПТРОНА
 * @param   {Array} teachingVectors Классы-образы
 * @param   {Array} funcs           Функции
 * @returns {Array} Результирующие функции
 */
function perceptron(teachingVectors, funcs) {
    var results, max, iterationsCount = 0,
        ok = true;
    while (ok && ++iterationsCount < 100) {
        ok = false;
        //за один проход проходим по всем обучающим векторам

        //цикл по образам классов
        for (var j = 0; j < teachingVectors.length; j++) {
            results = Array(funcs.length);
            for (var i = 0; i < funcs.length; i++) {
                //сумма произведения обучающего вектора и i функции
                results[i] = (funcs[i].multiplyArray(teachingVectors[j])).reduce((a, b) => a + b);
            }
            max = results.getMax();

            //если произведения больше либо равны вводим корекции
            if (!max.unique || max.index != j) {
                ok = true;
                for (var g = 0; g < funcs.length; g++) {
                    //искомую фуункцию суммируем, остальные в разность
                    if (g === j) {
                        funcs[g] = funcs[g].sumArray(teachingVectors[j]);
                    } else {
                        funcs[g] = funcs[g].differenceArray(teachingVectors[j]);
                    }
                }
            }
        }
    }
    return funcs;
}
