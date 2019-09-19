using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonCardGame.Model
{
    public class User
    {   
        public string Name { get; set; }
        public int Id { get; set; }
        private StackSingleton StapleSingleton = StackSingleton.GetInstance();
        private PlayingStackSingleton playingStackSingleton = PlayingStackSingleton.GetInstance();
        private List<string> Staple = new List<string>();

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void GrabCards(int amount)
        {
            List<string> NewCards;
            NewCards = StapleSingleton.GetCards(amount);

            Staple.AddRange(NewCards);
        }

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

        public void PlayCard(string card)
        {
            if(Staple.Contains(card))
            {
                Staple.Remove(card);
                playingStackSingleton.AddCardToStack(card);
            }
        }       
    }
}
