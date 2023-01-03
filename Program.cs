using System;
using System.Collections.Generic;
using System.Linq;

namespace Proje_2
{
    class Program
    {
        static void Main(string[] args)
        {
                Dictionary<int,string> teamMembers = new Dictionary<int, string>
                {
                    {1, "Emre Aygener"},
                    {2, "Mustafa Altun"},
                    {3, "Egehan Onel"},
                    {4, "Berfin Şimşek"},
                    {5, "Emir Yeniyiğit"},
                    {6, "Selin İpek Arıkan"}
                };
                List<Card> dataBase = new();
            while(true){
                Console.WriteLine("Please select what to do :)");
                Console.WriteLine("***************************");
                Console.WriteLine("(1) Listing the cards.");
                Console.WriteLine("(2) Adding cards.");
                Console.WriteLine("(3) Removing cards.");
                Console.WriteLine("(4) Updateing cards.");
                Console.WriteLine("(5) Moving cards.");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" ");
                        Card.ListCards(dataBase, teamMembers);
                        break;
                    case 2:
                        Console.WriteLine(" ");
                        Card newCard = new();
                        Card.AddCard(dataBase, newCard);
                        dataBase = dataBase.OrderBy(o=>o.ID).ToList();
                        break;
                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("Which card do you want to remove?");
                        string cardQuery = Console.ReadLine();
                        Card.RemoveCard(dataBase, cardQuery);
                        dataBase = dataBase.OrderBy(o=>o.ID).ToList();
                        break;
                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("Which card do you want to update?");
                        cardQuery = Console.ReadLine();
                        Card.UpdateCard(dataBase, cardQuery);
                        dataBase = dataBase.OrderBy(o=>o.ID).ToList();
                        break;
                    case 5:
                        Console.WriteLine(" ");
                        Console.WriteLine("Which card do you want to move?");
                        cardQuery = Console.ReadLine();
                        Card.MoveCard(dataBase, cardQuery);
                        dataBase = dataBase.OrderBy(o=>o.ID).ToList();
                        break;
                }
                        Console.WriteLine(" ");
                Console.WriteLine("Do you want anything else? ( y / n )");
                if (Console.ReadLine()=="n")
                    break;
            }        
            Console.WriteLine("Program ran successfully!");
            Console.ReadLine();
        }
    }
}
