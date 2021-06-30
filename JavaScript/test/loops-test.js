'use strict';

var assert = require('assert');
var lint = require('mocha-eslint');
var tasks = require('../task/loops-task');

describe('loops-task', function() {

    it('getFactorial should return the functorial of given number', () => {
        [
            { n:  1, expected:       1 },
            { n:  5, expected:     120 },
            { n: 10, expected: 3628800 },
            { n: 41758, expected: Number.POSITIVE_INFINITY }
        ].forEach(data => {
            var actual = tasks.getFactorial(data.n);
            assert.equal(
                actual,
                data.expected,
                `${data.n}! = ${data.expected}, but actual ${actual}`
            )
        });
    });


    it('getSumBetweenNumbers should return the sum inside the specified interval', () => {
        [
            { n1:  1, n2:  2, expected:  3 },
            { n1:  5, n2: 10, expected: 45 },
            { n1: -1, n2:  1, expected:  0 }
        ].forEach(data => {
            var actual = tasks.getSumBetweenNumbers(data.n1, data.n2);
            assert.equal(
                actual,
                data.expected,
                `Sum of [${data.n1},${data.n2}] = ${data.expected}, but actual ${actual}`
            )
        });
    });

    it('findFirstSingleChar should return the first unrepeated char from string', () => {
        [
            { str: 'The quick brown fox jumps over the lazy dog', expected: 'T' },
            { str: 'abracadabra', expected: 'c' },
            { str: 'entente', expected: null }
        ].forEach(data => {
            var actual = tasks.findFirstSingleChar(data.str);
            assert.equal(
                actual,
                data.expected,
                `First single char of '${data.str}' = '${data.expected}', but actual '${actual}'`
            )
        });
    });

    it('reverseString should return the specified string in reverse order', () => {
        [
            { str: 'The quick brown fox jumps over the lazy dog', expected: 'god yzal eht revo spmuj xof nworb kciuq ehT' },
            { str: 'abracadabra', expected: 'arbadacarba' },
            { str: 'rotator', expected: 'rotator' },
            { str: 'noon', expected : 'noon'}
        ].forEach(data => {
            var actual = tasks.reverseString(data.str);
            assert.equal(
                actual,
                data.expected,
                `Reversed '${data.str}' = '${data.expected}', but actual '${actual}'`
            )
        });
    });


    it('reverseInteger should return the specified number in reverse order', () => {
        [
            { num: 12345, expected: 54321 },
            { num:  1111, expected:  1111 },
            { num: 87354, expected: 45378 },
            { num: 34143, expected :34143 }
        ].forEach(data => {
            var actual = tasks.reverseInteger(data.num);
            assert.equal(
                actual,
                data.expected,
                `Reversed ${data.num} = ${data.expected}, but actual ${actual}`
            )
        });
    });

    var paths = [
        'task/loops-task.js'
    ];

    var options = {
        formatter: 'compact',  // Defaults to `stylish`
        alwaysWarn: false,  // Defaults to `true`, always show warnings
        timeout: 5000,  // Defaults to the global mocha `timeout` option
        slow: 1000,  // Defaults to the global mocha `slow` option
        strict: true,  // Defaults to `false`, only notify the warnings
        contextName: 'eslint',  // Defaults to `eslint`, but can be any string
    };

    lint(paths, options);
});
