using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonCardGame.Model
{
    class User
    {
        private StapleSingleton StapleSingleton = StapleSingleton.getInstance();
        private List<string> Staple = new List<string>();

        //get cards from stock
        public void GrabCards(int amount)
        {
            List<string> NewCards;
            NewCards = StapleSingleton.getCards(amount);

            Staple.AddRange(NewCards);
        }

        //Print the user's cards
        public void PrintHand(int number)
        {
            Console.Write("Player " + number + " has: ");
            int amount = 0;
            foreach (string card in Staple)
            {
                if (amount != 0)
                {
                    Console.Write(", ");
                    amount++;
                }
                amount++;
                Console.Write(card);
            }
            if (amount == 0)
            {
                Console.Write("no cards");
            }
            Console.WriteLine();
        }

        public List<string> GetCards()
        {
            return Staple;
        }

        public bool GiveCard(string card)
        {
            if(Staple.Contains(card))
            {
                Staple.Remove(card);
                return true;
            }
            return false;
        }       
    }
}
