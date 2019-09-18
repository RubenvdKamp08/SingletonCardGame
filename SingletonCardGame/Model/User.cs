using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonCardGame.Model
{
    class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private StapleSingleton StapleSingleton = StapleSingleton.getInstance();
        private List<string> Staple = new List<string>();

        public User(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        //get cards from stock
        public void GrabCards(int amount)
        {
            List<string> NewCards;
            NewCards = StapleSingleton.getCards(amount);

            Staple.AddRange(NewCards);
        }

        //Print the user's cards
        public void PrintHand()
        {
            Console.Write(Name + " has: ");
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
