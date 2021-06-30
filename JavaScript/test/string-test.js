'use strict';

var assert = require('assert');
var tasks = require('../task/string-task');
var lint = require('mocha-eslint');

describe('string-task', function() {

    it('extractCountryFromTemplate should parse country from given string', function() {
        assert.equal(tasks.extractCountryFromTemplate('I live in Belarus!'), 'Belarus');
        assert.equal(tasks.extractCountryFromTemplate('I live in Australia!'), 'Australia');
    });

    it('removeLeadingAndTrailingWhitespaces should remove leading and trailing whitespaces from the string', function() {
        assert.equal(tasks.removeLeadingAndTrailingWhitespaces('  Abracadabra'), 'Abracadabra');
        assert.equal(tasks.removeLeadingAndTrailingWhitespaces('cat'), 'cat');
        assert.equal(tasks.removeLeadingAndTrailingWhitespaces('\tHello, World! '), 'Hello, World!');
    });

    it('repeatString should repeat string specified number of times', function() {
        assert.equal(tasks.repeatString('A', 5), 'AAAAA');
        assert.equal(tasks.repeatString('cat', 3), 'catcatcat');
    });

    it('removeFirstOccurrences should remove all specified values from a string', function() {
        assert.equal(tasks.removeFirstOccurrences('To be or not to be', ' not'), 'To be or to be');
        assert.equal(tasks.removeFirstOccurrences('I like legends', 'end'), 'I like legs');
        assert.equal(tasks.removeFirstOccurrences('ABABAB','BA'), 'ABAB');
    });

    it('unbracketTag should remove first and last angle brackets from tag string', function() {
        assert.equal(tasks.unbracketTag('<div>'), 'div');
        assert.equal(tasks.unbracketTag('<span>'), 'span');
        assert.equal(tasks.unbracketTag('<a>'), 'a');
    });

    var paths = [
        'task/strings-task.js'
    ];

    var options = {
        // Specify style of output
        formatter: 'compact',  // Defaults to `stylish`
        // Only display warnings if a test is failing
        alwaysWarn: false,  // Defaults to `true`, always show warnings
        // Increase the timeout of the test if linting takes to long
        timeout: 5000,  // Defaults to the global mocha `timeout` option
        // Increase the time until a test is marked as slow
        slow: 1000,  // Defaults to the global mocha `slow` option
        // Consider linting warnings as errors and return failure
        strict: true,  // Defaults to `false`, only notify the warnings
        contextName: 'eslint',  // Defaults to `eslint`, but can be any string
    };

    lint(paths, options);
});
