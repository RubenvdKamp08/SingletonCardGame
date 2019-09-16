using SingletonCardGame.Model;
using System;

namespace SingletonCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StapleSingleton newInstance = StapleSingleton.getInstance();

            foreach(string card in newInstance.getCardsInStaple())
            {
                Console.Write(card + ", ");
            }

            Console.WriteLine();
            Console.WriteLine();
            newInstance.getCards(2);

            foreach (string card in newInstance.getCardsInStaple())
            {
                Console.Write(card + ", ");
            }
        }
    }
}
