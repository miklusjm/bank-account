# bank-account

WCCI Bank Account Project.

I didn't try anything very interesting with this because it was quite a busy weekend. I would've liked to have put a lot of the menu functions in static methods because the repeated Console.WriteLines are tedious to scroll through and follow the program flow.

I felt that all the fields/properties/methods for the program requirements should be in the base class since they apply to all the account, so the subclass-specific ones are things like "OverdraftProtection" for checking and "InterestRate" for savings. These are used in main in menu option 2, account information.

I also did something that I'm not sure is okay -- I did a try/catch to verify user input for the menu options, but I put nothing in the catch statement. This is because if the input would cause an exception, it simply remains a zero -- and then ALL invalid input is handled in the final else of the if/else if routine. It seems there is no need to have one error message for the user enters a non-int value and another error message for if the user enters an int value that's out of scope.
