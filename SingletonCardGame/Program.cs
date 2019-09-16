using SingletonCardGame.Model;
using System;

namespace SingletonCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //get staple instance & create players
            StapleSingleton newInstance = StapleSingleton.getInstance();
            User player1 = new User();
            User player2 = new User();
            User player3 = new User();

            //print Stock
            Console.WriteLine("Stock");
            newInstance.PrintStock();
            
            //Player 1 grabs cards
            Console.Write("Player 1 grab amount of cards: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            player1.GrabCards(amount);

            Console.Write("Player 1 has: ");
            player1.PrintHand();


            //Player 2 grabs cards
            Console.Write("Player 2 grab amount of cards: ");
            amount = Convert.ToInt32(Console.ReadLine());
            player2.GrabCards(amount);

            Console.Write("Player 2 has: ");
            player2.PrintHand();


            //Player 3 grabs cards
            Console.Write("Player 3 grab amount of cards: ");
            amount = Convert.ToInt32(Console.ReadLine());
            player3.GrabCards(amount);

            Console.Write("Player 3 has: ");
            player3.PrintHand();


            //print Stock
            Console.WriteLine("Stock");
            foreach (string card in newInstance.getCardsInStaple())
            {
                Console.Write(card + ", ");
            }

            Console.ReadKey();
        }
    }
}
