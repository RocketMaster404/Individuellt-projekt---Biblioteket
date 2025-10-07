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
         string user = Login();
         if(user != "failed")
         {
            //Lägg meny här
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
   }
}
