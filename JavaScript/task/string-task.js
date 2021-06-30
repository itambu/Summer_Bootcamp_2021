'use strict';

/********************************************************************************************
 *                                        СТРОКИ                                            *
 *******************************************************************************************/

/********************************************************************************************
 *                                                                                          *
 * Перед началом выполнения заданий рекомендуем ознакомиться с материалом:                  *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Global_Objects/String     *
 *                                                                                          *
 *******************************************************************************************/

/**
 * Извлеките название страны из строки формата 'I live in <Страна>!'.
 *
 * @param {string} value
 * @return {string}
 *
 * @example
 *   'I live in Belarus!' => 'Belarus'
 *   'I live in England!' => 'England'
 */
function extractCountryFromTemplate(value) {
    throw new Error('Not implemented');
}

/**
 * Удалите ведущие и конечные пробелы из строки.
 *
 * @param {string} value
 * @return {string}
 *
 * @example
 *   '  Abracadabra'    => 'Abracadabra'
 *   'EPAM'              => 'EPAM'
 *   '\tHello, World! ' => 'Hello, World!'
 */
function removeLeadingAndTrailingWhitespaces(value) {
    throw new Error('Not implemented');
}

/**
 * Повторите строку указанное число раз и верните результирующую строку.
 *
 * @param {string} value
 * @param {string} count
 * @return {string}
 *
 * @example
 *   'A', 5  => 'AAAAA'
 *   'cat', 3 => 'catcatcat'
 */
function repeatString(value, count) {
    throw new Error('Not implemented');
}

/**
 * Удалите указанную строку из другой строки и верните усечённый вариант. 
 * 
 * @param {string} str
 * @param {string} value
 * @return {string}
 *
 * @example
 *   'To be or not to be', 'not'  => 'To be or to be'
 *   'I like legends', 'end' => 'I like legs',
 *   'Penny', 'ny' => 'Pen'
 */
function removeFirstOccurrences(str, value) {
    throw new Error('Not implemented');
}

/**
 * Удалите первую и последнюю угловые скобки из заданной строки.
 *
 * @param {string} str
 * @return {string}
 *
 * @example
 *   '<div>' => 'div'
 *   '<span>' => 'span'
 *   '<a>' => 'a'
 */
function unbracketTag(str) {
    throw new Error('Not implemented');
}

module.exports = {
    extractCountryFromTemplate: extractCountryFromTemplate,
    removeLeadingAndTrailingWhitespaces: removeLeadingAndTrailingWhitespaces,
    repeatString: repeatString,
    removeFirstOccurrences: removeFirstOccurrences,
    unbracketTag: unbracketTag,
};