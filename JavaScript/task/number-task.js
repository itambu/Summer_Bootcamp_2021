'use strict';

/********************************************************************************************
 *                                        ЧИСЛА                                             *
 *******************************************************************************************/

/********************************************************************************************
 *                                                                                          *
 * Перед началом выполнения заданий рекомендуем ознакомиться с материалом:                  *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Guide/Numbers_and_dates             *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Global_Objects/Number     *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Global_Objects/Math       *
 *                                                                                          *
 *******************************************************************************************/

/**
 * Найдите среднее значение двух чисел.
 *
 * @param {numder} value1
 * @param {number} value2
 * @return {number}
 *
 * @example:
 *   5, 5  => 5
 *  10, 0  => 5
 *  -3, 3  => 0
 */
 function getAverage(value1, value2) {
    throw new Error('Not implemented');
}

/**
 * Решите уравнение a*x + b = 0 при заданных параметрах a и b.
 *
 * @param {number} a
 * @param {number} b
 * @return {number}
 *
 * @example:
 *   5*x - 10 = 0    => 2
 *   x + 8 = 0       => -8
 *   5*x = 0         => 0
 */
function getLinearEquationRoot(a, b) {
    throw new Error('Not implemented');
}

/**
 * Выведите последнюю цифру указанного числа.
 *
 * @param {number} value
 * @return {number}
 *
 * @example:
 *   100     => 0
 *    37     => 7
 *     5     => 5
 *     0     => 0
 */
function getLastDigit(value) {
    throw new Error('Not implemented');
}

/**
 * Найдите длину диагонали параллелограмма, если даны длины его рёбер a,b,c.
 *
 * @param {number} a
 * @param {number} b
 * @param {number} c
 * @return {number}
 *
 * @example:
 *   1,1,1   => 1.7320508075688772
 *   3,3,3   => 5.196152422706632
 *   1,2,3   => 3.741657386773941
 */
function getParallelipidedDiagonal(a,b,c) {
    throw new Error('Not implemented');
}

/**
 * Округлите число до указанного разряда.
 *
 * @param {number} num
 * @param {number} pow
 * @return {number}
 *  
 * @example:
 *   1234, 0  => 1234
 *   1234, 1  => 1230
 *   1234, 2  => 1200
 *   1234, 3  => 1000
 *   1678, 0  => 1678
 *   1678, 1  => 1680
 *   1678, 2  => 1700
 *   1678, 3  => 2000
 */
function roundToPowerOfTen(num, pow) {
    throw new Error('Not implemented');
}

/**
 * Определите, является число простым (выведите true), или составным (выведите false).
 * См. https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%BE%D1%81%D1%82%D0%BE%D0%B5_%D1%87%D0%B8%D1%81%D0%BB%D0%BE
 *
 * @param {number} n
 * @return {bool}
 * 
 * @example:
 *   4 => false
 *   5 => true
 *   6 => false
 *   7 => true
 *   11 => true
 *   12 => false
 *   16 => false
 *   17 => true
 */
function isPrime(n) {
    throw new Error('Not implemented');
}

module.exports = {
    getAverage: getAverage,
    getLinearEquationRoot: getLinearEquationRoot,
    getLastDigit: getLastDigit,
    getParallelipidedDiagonal: getParallelipidedDiagonal,
    roundToPowerOfTen: roundToPowerOfTen,
    isPrime: isPrime,
};
