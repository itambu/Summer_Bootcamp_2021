'use strict';

var assert = require('assert');
var lint = require('mocha-eslint');
var tasks = require('../task/array-task');

describe('array-task', function() {

    it('generateOdds should return the array of odd numbers of specified size', function () {
        [
            {
                len:      1,
                expected: [ 1 ]
            },{
                len:      2,
                expected: [ 1, 3 ]
            },{
                len:      5,
                expected: [ 1, 3, 5, 7, 9 ]
            },{
                len:      16,
                expected: [ 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 ]
            } 
        ].forEach(data => {
            assert.deepEqual(
                tasks.generateOdds(data.len),
                data.expected
            );
        });
    });

    it('getArrayOfPositives should return the array of positive values from specified array', function () {
        [
            {
                arr:      [ 0, 1, 2, 3, 4, 5 ],
                expected: [    1, 2, 3, 4, 5 ]
            },{
                arr:      [-1, 2, -5, -4, 0],
                expected: [    2           ]
            },{
                arr:      [],
                expected: []
            }
        ].forEach(data => {
            var actual = tasks.getArrayOfPositives(data.arr);
            assert.deepEqual(
                actual,
                data.expected
            );
        });
    });

    it('getUpperCaseStrings should convert strings from specified array to uppercase', function () {
        [
            {
                arr:      [ 'permanent-internship', 'glutinous-shriek', 'multiplicative-elevation' ],
                expected: [ 'PERMANENT-INTERNSHIP', 'GLUTINOUS-SHRIEK', 'MULTIPLICATIVE-ELEVATION' ]
            },{
                arr:      [ 'a', 'b', 'c', 'd', 'e', 'f', 'g' ],
                expected: [ 'A', 'B', 'C', 'D', 'E', 'F', 'G' ]
            }
        ].forEach(data => {
            var actual = tasks.getUpperCaseStrings(data.arr);
            assert.deepEqual(
                actual,
                data.expected
            );
        });
    });


    it('getStringsLength should convert strings from specified array to uppercase', function () {
        [
            {
                arr:      [ '', 'a', 'bc', 'def', 'ghij' ],
                expected: [  0,  1,    2,     3,     4   ]
            },{
                arr:      [ 'angular', 'react', 'ember' ],
                expected: [        7,       5,       5  ]
            }
        ].forEach(data => {
            var actual = tasks.getStringsLength(data.arr);
            assert.deepEqual(
                actual,
                data.expected
            );
        });
    });

    it('getHead should return the n first items from the specified array', function () {
        [
            {
                arr:      [ 1, 2, 3, 4, 5 ],
                n:        2,
                expected: [ 1, 2 ]
            },{
                arr:      [ 'a', 'b', 'c', 'd' ],
                n:        3,
                expected: [ 'a', 'b', 'c' ]
            }
        ].forEach(data => {
            assert.deepEqual(
                tasks.getHead(data.arr, data.n),
                data.expected
            );
        });
    });

    it('getSecondItems should return every second item from the specified array', function () {
        [
            {
                arr:      [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ],
                expected: [    2,    4,    6,    8,    10 ]
            }, {
                arr:      [ 'a', 'b', 'c' , null ],
                expected: [      "b",       null ]
            }, {
                arr:      [ "a" ],
                expected: [     ]
            }
        ].forEach(data => {
            var actual = tasks.getSecondItems(data.arr);
            assert.deepEqual(
                actual,
                data.expected
            );
        });
    });

    it('get3TopItems should return the 3 largest items from integer array', function () {
        [
            {
                arr:      [],
                expected: []
             }, {
                 arr:      [ 1,2 ],
                 expected: [ 2,1 ]
            }, {
                arr:      [ 1, 2, 3 ],
                expected: [ 3, 2, 1 ]
            }, {
                arr:      [ 1,2,3,4,5,6,7,8,9,10 ],
                expected: [ 10,9,8 ]
            }, {
                arr:      [ 10, 10, 10, 10],
                expected: [ 10, 10, 10 ]
            }
        ].forEach(data => {
            var actual = tasks.get3TopItems(data.arr);
            assert.deepEqual(
                actual,
                data.expected
            );
        });
    });

    it('getPositivesCount should return the number of positive integers in the specified array', function () {
        [
            {
                arr:      [],
                expected: 0
             }, {
                 arr:      [ -1, 0, 1 ],
                 expected: 1
            }, {
                arr:      [ 1, 2, 3 ],
                expected: 3
            }, {
                arr:      [ null, 1, 'elephant' ],
                expected: 1
            }, {
                arr:      [ 1, '2' ],
                expected: 1
            }
        ].forEach(data => {
            var actual = tasks.getPositivesCount(data.arr);
            assert.equal(
                actual,
                data.expected,
                `Test failed for argument [${data.arr}]`
            );
        });
    });

    var paths = [
        'task/04-arrays-tasks.js'
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
