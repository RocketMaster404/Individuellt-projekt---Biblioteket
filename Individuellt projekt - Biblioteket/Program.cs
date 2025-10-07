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
            
        }
    }
}
