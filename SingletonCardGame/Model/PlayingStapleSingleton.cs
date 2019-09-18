using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonCardGame.Model
{
    class PlayingStapleSingleton
    {
        private static PlayingStapleSingleton firstInstance = null;

        List<string> Staple = new List<string>();

        private PlayingStapleSingleton() { }

        public static PlayingStapleSingleton getInstance()
        {
            if (firstInstance == null)
            {
                firstInstance = new PlayingStapleSingleton();

            }
            return firstInstance;
        }

        public void addingCardToStaple(string card)
        {
            Staple.Add(card);
        }

        public void printStaple()
        {
            Console.Write("Stock of playing staple: ");
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
            if(amount == 0)
            {
                Console.Write("Empty");
            }
            Console.WriteLine("\n");
        }

    }
}
