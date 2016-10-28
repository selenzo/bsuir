/*jshint -W117, esversion: 6*/

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
        result1[i] = GaussBaes(i, mx1, sigma1, pc1);
        result2[i] = GaussBaes(i, mx2, sigma2, pc2);
        canvas.DrawLine(i - 1, height - result1[i - 1] * k, 1, i, height - result1[i] * k, 2);
        canvas.DrawLine(i - 1, height - result2[i - 1] * k, 4, i, height - result2[i] * k, 2);

        X = (Math.abs(result1[i] * 100 - result2[i] * 100) < 0.001) ? i : X;
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

/**
 * Вычисление вероятности через Гаусса и Байеса
 * @param   {number} x     x
 * @param   {number} mx    Математическое ожидание
 * @param   {number} sigma Среднеквадротичное
 * @param   {number} pc    Вероятность
 * @returns {number} Результат
 */
function GaussBaes(x, mx, sigma, pc) {
    return Math.exp(-0.5 * Math.pow((x - mx) / sigma, 2)) * pc / (sigma * Math.sqrt(2 * Math.PI));
}
