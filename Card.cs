using System;
using System.Collections.Generic;
using System.Linq;

namespace Proje_2
{
    class Card
    {
        enum Sizes {XS=1, S, M, L, XL}
        enum Progresses {TODO=1,INPROGRESS=2,DONE}
        public string Header;
        public string Content;
        public int ID;
        public int Size;
        public int Progress;

        public Card(){
            Console.WriteLine("Please enter header : ");
            string header = Console.ReadLine();
            Console.WriteLine("Please enter content : ");
            string content = Console.ReadLine();
            Console.WriteLine("Please enter ID ( 1 - 2 - 3 - 4 - 5 - 6 ) : ");
            int id= int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Size ( 1 - XS, 2 - S, 3 - M, 4 - L, 5 - XL ) : ");
            int size = int.Parse(Console.ReadLine());
            int progress=1;

            this.Progress=progress;
            this.Content=content;
            this.Header=header;
            this.Size=size;
            this.ID=id;
        }
        public static void AddCard(List<Card>dataBase,Card newCard){
            dataBase.Add(newCard);
        }
        public static void RemoveCard(List<Card>dataBase,string cardQuery){
            int listCount=dataBase.Count;
            Card toBeRemoved=null;
            foreach (Card cardToBeRemoved in dataBase)
            {
            if(cardToBeRemoved.Header==cardQuery||cardToBeRemoved.Content==cardQuery||cardToBeRemoved.ID==int.Parse(cardQuery))
                toBeRemoved=cardToBeRemoved;
            }
            if (dataBase.Contains(toBeRemoved))
                dataBase.Remove(toBeRemoved);
            if (dataBase.Count!=listCount)
                Console.WriteLine("Removal is successfull");
            else
                Console.WriteLine("The card is not on the to-do list.");
        }
        public static void UpdateCard(List<Card> dataBase,string CardQuery){
            int listCount=dataBase.Count;
            Card toBeUpdated=null;
            foreach (Card CardToBeUpdated in dataBase)
            {
            if(CardToBeUpdated.Header==CardQuery||CardToBeUpdated.Content==CardQuery||CardToBeUpdated.ID==int.Parse(CardQuery))
                toBeUpdated=CardToBeUpdated;
            }
            if (dataBase.Contains(toBeUpdated)){
                dataBase.Remove(toBeUpdated);
                Card updatedCard = new Card();
                dataBase.Add(updatedCard);
            }
            if (dataBase.Count==listCount)
                Console.WriteLine("Update is successfull.");
            else
                Console.WriteLine("The update has failed.");
        }
        public static void ListCards(List<Card>dataBase,Dictionary<int,string>TeamMembers){
            dataBase = dataBase.OrderBy(o=>o.ID).ToList();

            Console.WriteLine("TODO Line"); 
            Console.WriteLine("*************************");
                    Console.WriteLine(" ");
            foreach (Card card in dataBase){
                if (card.Progress==1){
                    Console.WriteLine("Header          : "+card.Header);
                    Console.WriteLine("Content         : "+card.Content);
                    Console.WriteLine("Assigned Person : "+ TeamMembers.GetValueOrDefault(card.ID));
                    if(card.Size==1){Console.WriteLine("Size            : "+Sizes.XS);}
                    else if(card.Size==2){Console.WriteLine("Size            : "+Sizes.S);}
                    else if(card.Size==3){Console.WriteLine("Size            : "+Sizes.M);}
                    else if(card.Size==4){Console.WriteLine("Size            : "+Sizes.L);}
                    else{Console.WriteLine("Size            : "+Sizes.XL);}
                    Console.WriteLine(" ");}}

            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("*************************");
                    Console.WriteLine(" ");
            foreach (Card card in dataBase){
                if (card.Progress==2){
                    Console.WriteLine("Header          : "+card.Header);
                    Console.WriteLine("Content         : "+card.Content);
                    Console.WriteLine("Assigned Person      : "+TeamMembers.GetValueOrDefault(card.ID));
                    if(card.Size==1){Console.WriteLine("Size            : "+Sizes.XS);}
                    else if(card.Size==2){Console.WriteLine("Size            : "+Sizes.S);}
                    else if(card.Size==3){Console.WriteLine("Size            : "+Sizes.M);}
                    else if(card.Size==4){Console.WriteLine("Size            : "+Sizes.L);}
                    else{Console.WriteLine("Size           : "+Sizes.XL);}
                    Console.WriteLine(" ");}}

            Console.WriteLine("DONE Line");
            Console.WriteLine("*************************");
                    Console.WriteLine(" ");
            foreach (Card card in dataBase){
                if (card.Progress==3){
                    Console.WriteLine("Header          : "+card.Header);
                    Console.WriteLine("Content         : "+card.Content);

                    Console.WriteLine("Assigned Person      : "+TeamMembers.GetValueOrDefault(card.ID));
                    if(card.Size==1){Console.WriteLine("Size            : "+Sizes.XS);}
                    else if(card.Size==2){Console.WriteLine("Size            : "+Sizes.S);}
                    else if(card.Size==3){Console.WriteLine("Size            : "+Sizes.M);}
                    else if(card.Size==4){Console.WriteLine("Size            : "+Sizes.L);}
                    else{Console.WriteLine("Size            : "+Sizes.XL);}
                    Console.WriteLine("  ");}}
        }
        public static void MoveCard(List<Card>dataBase,string cardQuery){
            foreach (var card in dataBase)
            {
                if (card.Header==cardQuery||card.Content==cardQuery)
                {
                    Console.WriteLine("Which line do you want to move the card into? ( 1 - Into TODO Line, 2 - Into INPROGRESS Line, 3 - Into DONE Line )");
                    card.Progress=int.Parse(Console.ReadLine());
                    break;
                }
            }
        }
    }
}