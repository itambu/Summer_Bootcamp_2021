'use strict';

/********************************************************************************************
 *                                        ЦИКЛЫ                                             *
 *******************************************************************************************/

/********************************************************************************************
 *                                                                                          *
 * Перед началом выполнения заданий рекомендуем ознакомиться с материалом:                  *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Guide/Loops_and_iteration           *
 *                                                                                          *
 *******************************************************************************************/

/**
 * Найдите факториал числа.
 *
 * @param {number} n
 * @return {number}
 *
 * @example:
 *   1  => 1
 *   5  => 120
 *   10 => 3628800
 */
 function getFactorial(n) {
    throw new Error('Not implemented');
}


/**
 * Найдите сумму чисел, находящихся между двумя указанными числами.
 *
 * @param {number} n1
 * @param {number} n2
 * @return {number}
 *
 * @example:
 *   1,2   =>  3  ( = 1+2 )
 *   5,10  =>  45 ( = 5+6+7+8+9+10 )
 *   -1,1  =>  0  ( = -1 + 0 + 1 )
 */
function getSumBetweenNumbers(n1, n2) {
    throw new Error('Not implemented');
}


/**
 * Найдите первый уникальный (неповторяющийся) символ в строке и верните его значение, если он не найден - верните null.
 *
 * @param {string} str
 * @return {string}
 *
 * @example:
 *   'The quick brown fox jumps over the lazy dog' => 'T'
 *   'abracadabra'  => 'c'
 *   'entente' => null
 */
function findFirstSingleChar(str) {
    throw new Error('Not implemented');
}

/**
 * Перепишите указанную строку в обратном порядке следования символов
 *
 * @param {string} str
 * @return {string}
 *
 * @example:
 * 'The quick brown fox jumps over the lazy dog' => 'god yzal eht revo spmuj xof nworb kciuq ehT'
 * 'abracadabra' => 'arbadacarba'
 * 'rotator' => 'rotator'
 * 'noon' => 'noon'
 */
function reverseString(str) {
    throw new Error('Not implemented');
}


/**
 * Перепишите указанное число в обратном порядке следования цифр
 *
 * @param {number} num
 * @return {number}
 *
 * @example:
 *   12345 => 54321
 *   1111  => 1111
 *   87354 => 45378
 *   34143 => 34143
 */
function reverseInteger(num) {
    throw new Error('Not implemented');
}

module.exports = {
    getFactorial: getFactorial,
    getSumBetweenNumbers: getSumBetweenNumbers,
    findFirstSingleChar: findFirstSingleChar,
    reverseString: reverseString,
    reverseInteger: reverseInteger,
};