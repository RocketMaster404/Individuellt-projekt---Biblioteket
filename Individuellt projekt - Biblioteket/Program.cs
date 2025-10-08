namespace Individuellt_projekt___Biblioteket
{
   internal class Program
   {
      // Arrays for the userprofiles, each user is tied to the index of array.
      // Each user has a username, a PIN code, and an empty slot with space for 5 books to borrow. The number five represents the number of titles in the library
      static string[] userNames = { "Erik", "Pontus", "Julia", "Viktor", "Daniel" };
      static int[] pinCodes = { 1112, 1114, 1116, 1118, 1120 };
      static string[,] loans = new string[5, 5];

      //Arrays for Books/copies.
      static string[] titles = { "Livet Deluxe", "VIP Rummet", "Snabba Cash", "Top Dog", "Paradise City" };
      static int[] copies = { 2, 5, 3, 4, 5 };

      static void Main(string[] args)
      {
         bool running = true;

         while (running)
         {
            string user = Login();
            if (user == "failed")
            {
               Console.WriteLine("Programmet avslutas");
               break;
            }

            // As long as mainMenu is true we run the program, as soon as it´s false (option 5) we exit the loop to the login again.
            bool correctLogin = true;
            while (correctLogin)
            {
               PrintMenu(user);
               correctLogin = MainMenu(user);
               Console.WriteLine("Tryck enter för att komma tillbaka till huvudmeny");
               Console.ReadKey();

            }
         }
      }

      static string Login()
      {
         int attempts = 3;
         int pinCode;
         // While loops controls the users attempts
         while (attempts != 0)
         {

            Console.Clear();
            Console.Write("Ange ditt användarnamn: ");
            string userName = Console.ReadLine();
            Console.Write("Ange din pinkod: ");
            while (!int.TryParse(Console.ReadLine(), out pinCode))
            {
               Console.WriteLine("Pinkoden består av endast siffror");
            }
            // This loop goes through usernames and pincodes to find a match, since both arrayes have an index of 5 we use i<5. 
            // For each loop we count down with one attempts - if we reach zero the program returns "failed"
            for (int i = 0; i < 5; i++)
            {

               if (userNames[i] == userName && pinCodes[i] == pinCode)
               {
                  Console.WriteLine("Du är inloggad");
                  return userName;
               }
            }
            attempts--;
            Console.WriteLine("Felaktigt användarnamn eller pinkod");
            Console.ReadKey();

         }
         return "failed";
      }

      static void PrintMenu(string userName)
      {
         Console.Clear();
         Console.WriteLine($"Användare:{userName}\n");
         Console.WriteLine("1. Visa böcker");
         Console.WriteLine("2. Låna Bok");
         Console.WriteLine("3. Lämna tillbaka bok");
         Console.WriteLine("4. Mina lån");
         Console.WriteLine("5. Logga ut\n");
         Console.Write("Ange ditt val: ");
      }

      static int GetUserNumber(int min, int max)
      {
         int input;
         while (!int.TryParse(Console.ReadLine(), out input))
         {
            Console.WriteLine($"Ogiltigt val, du måste ange en siffra mellan {min} & {max}");
         }
         return input;
      }

      // MainMenu is a bool - so we can control if the user wants to log out 
      static bool MainMenu(string user)
      {
         int input = GetUserNumber(1, 5);
         switch (input)
         {
            case 1:
               ShowBooks();
               break;
            case 2:
               BorrowBook(user);
               break;
            case 3:
               ReturnBook(user);
               break;
            case 4:
               ShowLoans(user);
               break;
            case 5:
               return false;
         }
         return true;
      }
      static void ShowBooks()
      {
         Console.Clear();
         for (int i = 0; i < 5; i++)
         {
            Console.WriteLine($"{titles[i]}\nExemplar:{copies[i]}\n");
         }
      }

      static void BorrowBook(string userName)
      {
         Console.Clear();
         // Show all books and copies
         for (int i = 0; i < 5; i++)
         {
            Console.WriteLine($"{i + 1}. {titles[i]} | Tillgänglighet:{copies[i]}st");
         }
         Console.WriteLine("Ange boken du önskar låna: ");
         int input = GetUserNumber(1, 5);
         // corrects the index so we don´t start at zero. 
         int bookIndex = input - 1;



         // Save book to user, loop goes through the second index of 2d array (1).
         int userIndex = GetUserIndex(userName);

         // Check if we have the book in stock 

         if (copies[bookIndex] == 0)
         {
            Console.WriteLine("Boken finns inte i lager");
            return;
         }


         // Adds the book to the user "loans.GetLength(1)" and then removes one copy
         for (int i = 0; i < loans.GetLength(1); i++)
         {
            if (loans[userIndex, i] == null)
            {
               loans[userIndex, i] = titles[bookIndex];  
               copies[bookIndex]--;                      
               Console.WriteLine($"Du har lånat \"{titles[bookIndex]}\".");
               return;
            }
         }

         Console.WriteLine("Du har redan lånat max antal böcker");

      }

      // This method is needes since we use a 2d array to save/remove books from users
      static int GetUserIndex(string userName)
      {
         //Loop to find the coorect user index (i), if we don´t find a match we return -1 (invalid number for array index)
         for (int i = 0; i < 5; i++)
         {
            if (userNames[i] == userName)
            {
               return i;
            }
         }
         return -1;
      }

      static void ReturnBook(string userName)
      {

         int userIndex = GetUserIndex(userName);
         Console.Clear();
         Console.WriteLine("Dina lånade böcker:");
         int count = 0;

         // Visa användarens lån
         for (int i = 0; i < loans.GetLength(1); i++)
         {
            if (loans[userIndex, i] != null)
            {
               count++;
               Console.WriteLine($"{count}. {loans[userIndex, i]}");
            }
         }

         if (count == 0)
         {
            Console.WriteLine("Du har inga böcker att lämna tillbaka.");
            return;
         }

         Console.WriteLine("Vilken bok önskar du lämna tillbaka: ");
         int input = GetUserNumber(1, count);

         // Find the right spot in loans array
         int visIndex = 0;
         for (int i = 0; i < loans.GetLength(1); i++)
         {
            if (loans[userIndex, i] != null)
            {
               visIndex++;
               if (visIndex == input)
               {
                  string returnedBook = loans[userIndex, i];

                  // Find the book
                  for (int j = 0; j < titles.Length; j++)
                  {
                     if (titles[j] == returnedBook)
                     {
                        copies[j]++;
                        break;
                     }
                  }

                  loans[userIndex, i] = null;
                  Console.WriteLine($"Du har lämnat tillbaka \"{returnedBook}\".");
                  return;
               }
            }
         }


      }

      static void ShowLoans(string userName)
      {
         int count = 0;
         int userIndex = GetUserIndex(userName);
         Console.Clear();

         Console.WriteLine("Dina lån\n");
         for (int i = 0; i < loans.GetLength(1); i++)
         {
            if (loans[userIndex, i] != null)
            {
               Console.WriteLine($"{i + 1}.{loans[userIndex, i]}");
               count++;
            }

         }
         if (count == 0)
         {
            Console.WriteLine("Du har inga aktiva lån");
         }
      }

   }
}
