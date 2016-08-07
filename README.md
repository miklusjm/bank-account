# bank-account

WCCI Bank Account Project.

I didn't try anything very interesting with this because it was quite a busy weekend. I would've liked to put a lot of the menu functions in static methods because the repeated Console.WriteLines are tedious to scroll through and follow the program flow.

I felt that all the fields/properties/methods for the program requirements should be in the base class since they apply to all the account, so the subclass-specific ones are things like "OverdraftProtection" for checking and "InterestRate" for savings. These are used in main in menu option 2, account information.
