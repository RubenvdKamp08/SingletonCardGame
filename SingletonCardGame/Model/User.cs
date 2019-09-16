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
        public void PrintHand()
        {
            foreach (string card in Staple)
            {
                Console.Write(card + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public List<string> GetCards()
        {
            return Staple;
        }
    }
}
