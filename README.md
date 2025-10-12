READ ME
Individuellt Projekt – Bilbiotekssystem

The program represents a loan system for a library.
It includes five users with associated PIN codes.
Each user has a profile where they can borrow books, return books, and view an overview of the library's collection as well as their current loans.

After the user has logged in, they are sent to the main menu. 
They can choose an option 1-5 depending on what the would like to do. 


My solution.
I choose to work with parallel arrays since all arrays had a fixed number of five. 
For ex, if the user has index 0 I would use index 0 for all element (pincode, loans)
To get the opportunity to practice on creating methods, I did my best to use as many as possible.
I also wanted to practice on passing argument which you can see in my LogIn method.
Instead of using a bool for the LogIn I return the username and use it as an argument in other methods.  

In my method I use for loops to go through the arrays and they are often controlled with if statements to control the output.
In some cases I use a counter in the loops – to keep track and then tie to an if statement depending on method. 
While loops occur as well, mainly in my Main, to make the user get back to the main menu after each completed task and to make sure we always have a user.
While loops my also occur as a security measure when we read input from users. 

Considered solutions 
My first thought was to make an 2d array for the user/pincode, but changed the approach since it would make the pincode a string instead of an int. 
I also tried to not use any 2d arrays but found it hard to tie the loans to the user. 
At first my LogIn method was a bool to control if a user is logged in or not. This changed as I wanted to keep track of the logged in user. 


Methods 

LogIn()
This is where the user inputs username and their pin. 
The method search through the arrayes for a match – if succeed to user logs in.
There is a counter who keeps tracks of each failed attempt and shuts down the program if the user fails to log in. 
Successful logins returns their username
A failed logIn return “failed”

PrintMenu()
This method prints the menu in the console.

GetUserNumber()
A method that takes an number input, it can be controlled with a min and max value. 
If the user is outside min/max an error accour and explains to the user they need to be within the span. 

MainMenu()
This is a Switch that reads a user input, each case represent the number given at PrintMenu(). 

ShowBooks()
This method loops through the arrays of title and copies. 
It shows the user what books are available and how many. 

BorrowBooks()
This method makes the user Borrow a book. 
It checks that the book is in stock, that the user haven´t borrowed the same title and that the user have not reached their limit of 5 books. 
If the loan is successful, the title of the book is saved at one of the spots in the 2d array loans (index 1), the user index is determined by GetUserIndex() method.

GetUserIndex()
A method that loops through the username array and find a match with the logged in user.
It returns the index of the logged in user.
This method is later used to match the logged in user with the right row in loans array


ReturnBooks()
A method that shows the users loaned books and gives the option to return. 
each loan have is represented with a number and the user can input the number of the book it wishes to return. 

ShowLoans()
Shows the users borrowed books, if none – it tells the user no active loans


