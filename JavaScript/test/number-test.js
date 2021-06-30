'use strict';

var assert = require('assert').strict;
var lint = require('mocha-eslint');
var tasks = require('../task/number-task');

describe('number-task', function() {

    it('getAverage should return an average of two numbers', function() {
        assert.equal(tasks.getAverage(5, 5), 5);
        assert.equal(tasks.getAverage(10, 0), 5);
        assert.equal(tasks.getAverage(-3, 3), 0);
        assert.equal(tasks.getAverage(Number.MAX_VALUE-2, Number.MAX_VALUE), Number.MAX_VALUE-1);
        assert.equal(tasks.getAverage(Number.MAX_VALUE, -Number.MAX_VALUE / 2), Number.MAX_VALUE / 4);
    });

    it('getLinearEquationRoot should return a root of linear equation', function() {
        assert.equal(tasks.getLinearEquationRoot(5, -10), 2);
        assert.equal(tasks.getLinearEquationRoot(1, 8), -8);
        assert.equal(tasks.getLinearEquationRoot(5, 0), 0);
    });

    it('getLastDigit should return a last digit of the number', function() {
        assert.equal(tasks.getLastDigit(100), 0);
        assert.equal(tasks.getLastDigit(37), 7);
        assert.equal(tasks.getLastDigit(5), 5);
        assert.equal(tasks.getLastDigit(0), 0);
    });

    it('getParallelipidedDiagonal should return a diagonal length of the rectagular parallepiped', function() {
        assert.equal(tasks.getParallelipidedDiagonal(1,1,1), Math.sqrt(3));
        assert.equal(tasks.getParallelipidedDiagonal(3,3,3), Math.sqrt(27));
        //assert.equal(tasks.getParallelipidedDiagonal(1,2,3), Math.sqrt(14));
    });

    it('roundToPowerOfTen should return an number rounded to specified power of 10', function() {
        assert.equal(tasks.roundToPowerOfTen(1234,0), 1234);
        assert.equal(tasks.roundToPowerOfTen(1234,1), 1230);
        assert.equal(tasks.roundToPowerOfTen(1234,2), 1200);
        assert.equal(tasks.roundToPowerOfTen(1234,3), 1000);
        
        assert.equal(tasks.roundToPowerOfTen(9678,0), 9678);
        assert.equal(tasks.roundToPowerOfTen(9678,1), 9680);
        assert.equal(tasks.roundToPowerOfTen(9678,2), 9700);
        assert.equal(tasks.roundToPowerOfTen(9678,3), 10000);
    });

    it('isPrime should return true if specified number is prime', function() {
        assert.equal(tasks.isPrime(2), true, "2");
        assert.equal(tasks.isPrime(3), true, "3");
        assert.equal(tasks.isPrime(4), false, "4");
        assert.equal(tasks.isPrime(5), true, "5");
        assert.equal(tasks.isPrime(6), false, "6");
        assert.equal(tasks.isPrime(7), true, "7");
        assert.equal(tasks.isPrime(8), false, "8");
        assert.equal(tasks.isPrime(9), false, "9");
        assert.equal(tasks.isPrime(10), false, "10");
        assert.equal(tasks.isPrime(11), true, "11");
        assert.equal(tasks.isPrime(12), false, "12");
        assert.equal(tasks.isPrime(13), true, "13");
        assert.equal(tasks.isPrime(113), true, "113");
        assert.equal(tasks.isPrime(119), false, "119");
    });

    var paths = [
        'task/number-task.js'
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
