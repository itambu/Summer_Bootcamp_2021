**Task 1**

Count the minimum number of coins that must be reversed to have all the coins lying on the same side.
There are N coins, each showing either heads or tails. We would like all the coins to show the same face. What is the minimum number of coins that
must be reversed?

Write a function:

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A consisting of N integers representing the coins, returns the minimum number of coins that must be reversed.
Consecutive elements of array A represent consecutive coins and contain only a 0 (heads) or a 1 (tails).

For example, given array A = [1, 0, 0, 1, 0, 0], there are four coins showing heads and two coins showing tails. The function should return 2, as after
reversing two coins (in positions 0 and 3), all the coins will be showing the same face (heads).

Assume that:
N is an integer within the range [1..100];
each element of array A is an integer that can have one of the following values: 0, 1.

**Task 2**

Find the longest sentence in the given text.
You would like to find the sentence containing the largest number of words in some given text. The text is specified as a string S consisting of N
characters: letters, spaces, dots (.), question marks (?) and exclamation marks (!).
The text can be divided into sentences by splitting it at dots, question marks and exclamation marks. A sentence can be divided into words by splitting
it at spaces. A sentence without words is valid, but a valid word must contain at least one letter.

For example, given S = "We test coders. Give us a try?", there are three sentences: "We test coders", " Give us a try" and "". The first sentence
contains three words: "We", "test" and "coders". The second sentence contains four words: "Give", "us", "a" and "try". The third sentence is empty.
Write a function:

class Solution { public int solution(String S); }

that, given a string S consisting of N characters, returns the maximum number of words in a sentence.

For example, given S = "We test coders. Give us a try?", the function should return 4, as explained above.
Given S = "Forget CVs..Save time . x x", the function should return 2, as there are four sentences: "Forget CVs" (2 words), "" (0 words), "Save time "
(2 words) and " x x" (2 words).

Assume that:
the length of S is within the range [1..100];
string S consists only of letters (a−z, A−Z), spaces, dots (.), question marks (?) and exclamation marks (!).
In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.

**Task 3**

Shuffle the digits of an integer.
There is a company that has a very creative way of managing its accounts. Every time they want to write down a number, they shuffle its digits in the
following way: they alternatively write one digit from the front of the number and one digit from the back, then the second digit from the front and the
second from the back, and so on until the length of the shuffled number is the same as that of the original.

Write a function

class Solution { public int solution(int A); }

that, given a positive integer A, returns its shuffled representation.

For example, given A = 123456 the function should return 162534.
Given A = 130 the function should return 103.

Assume that:
A is an integer within the range [0..100,000,000].
