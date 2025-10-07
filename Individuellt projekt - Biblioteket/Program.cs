namespace Individuellt_projekt___Biblioteket
{
   internal class Program
   {
      // Arrays for the userprofiles, each user is tied to the index of array.
      // Each user has a username, a PIN code, and an empty slot with space for 5 books to borrow. The number five represents the number of titles in the library
      static string[] userNames = { "Erik", "Pontus", "Julia", "Viktor", "Daniel" };
      static int[] pinCodes = { 1112, 1114, 1116, 1118, 1120 };
      static string[] loans = new string[5];

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

      static void PrintMenu(string user)
      {
         Console.Clear();
         Console.WriteLine($"Användare:{user}\n");
         Console.WriteLine("1. Visa böcker");
         Console.WriteLine("2. Låna Bok");
         Console.WriteLine("3. Lämna tillbaka bok");
         Console.WriteLine("4. Mina lån");
         Console.WriteLine("5. Logga ut");
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
               // Visa Böcker
               break;
            case 2:
               //Låna bok
               break;
            case 3:
               // Lämna tillbaka bok
               break;
            case 4:
               // Mina Lån
               break;
            case 5:
               return false;
               break;

         }
         return true;
      }
   }
}
