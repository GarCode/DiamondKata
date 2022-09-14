# DiamondKata
This is a solution done for the code kata that can be found at the following link.
https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

# Solution
I've done very little with the console application. I kept the input method as shown in the kata example, having the character passed through as an arguement. 
There is very basic error handling in the console application, currently just capturing the exception and outputting the error message. There are no tests around the
console application. Other than checking that there is an input it just outputs the result of the DiamondCreator.

The DiamondCreator class does the heavy lifting for the creation of the diamond. It has checks to make sure that the character passed into it is a letter, throwing an exception if it
encounters something other than an ASCII character. 

# Things to consider:
1) Using DI to inject the DiamondCreator into the conole
2) A more robust error handling. Currently it is at its most basic with just a try..catch block.
3) Consider moving the divider/spacer to a config file so it isn't hardcoded
