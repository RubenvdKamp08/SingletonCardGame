using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonCardGame.Model
{
    public class PlayingStackSingleton
    {        
        private static PlayingStackSingleton firstInstance = null;

        private static readonly object Instancelock = new object();

        List<string> Staple = new List<string>();

        private PlayingStackSingleton() { }

        public static PlayingStackSingleton GetInstance()
        {
            //check if there is already an instance
            if (firstInstance == null)
            {
                //double checked locking to prevent multithreading errors
                lock (Instancelock)
                {
                    if (firstInstance == null)
                    { 
                        firstInstance = new PlayingStackSingleton();
                    }
                }
            }
            return firstInstance;
        }

        public void AddCardToStack(string card)
        {
            Staple.Add(card);
        }

        public List<string> GetStack()
        {
            return firstInstance.Staple;
        }

        public void PrintStaple()
        {
            Console.Write("Playing stack: ");
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
                Console.Write("No cards");
            }
            Console.WriteLine("\n");
        }

    }
}
