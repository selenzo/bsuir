/**
 * Заполняем рандомными числами от Min до Max
 * @param   {number} min минимальное возможное значение
 * @param   {number} max максимальное возможное значение
 * @returns {Array}  возвращает измененный массив
 */
Array.prototype.fillRandom = function (min, max) {
    this.fill(0);
    this.forEach((element, index, array) => array[index] = Math.round(min + Math.random() * (max - min)));
    return this;
};

/**
 * Возвращает математическое ожидание массива
 * @returns {number} Математическое ожидание
 */
Array.prototype.mx = function () {
    return this.reduce((a, b) => a + b) / this.length;
}

/**
 * Возвращает среднеквадротичное отклонение массива
 */
Array.prototype.sigma = function () {
    var sigma = 0;
    var mx = this.mx();
    this.forEach((element) => sigma += Math.pow(element - mx, 2));
    return Math.sqrt(sigma / this.length);
}
