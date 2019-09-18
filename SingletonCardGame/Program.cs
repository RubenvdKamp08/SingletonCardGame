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
            PlayingStapleSingleton playingNewInstance = PlayingStapleSingleton.getInstance();
                                      
            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine("----------status---------- \n");
                playingNewInstance.printStaple();
                newInstance.PrintStock();
                if(i == 0)
                {
                    player1.PrintHand(1);
                    player2.PrintHand(2);
                    player3.PrintHand(3);
                    Console.WriteLine();
                }
                Console.WriteLine("----------round "+ (i+1) +"----------\n");
                Random r = new Random();
                int playerNumber = r.Next(1, 3);
                Console.Write("Player " + playerNumber + " grab amount of cards: ");
                int amountOfCards = Convert.ToInt32(Console.ReadLine());
                if(playerNumber == 1)
                {
                    player1.GrabCards(amountOfCards);
                    player1.PrintHand(playerNumber);

                    Console.Write("Player 1 gives card: ");
                    string givenCard = Console.ReadLine();
                    if (player1.GiveCard(givenCard))
                    {
                        playingNewInstance.addingCardToStaple(givenCard);
                    }

                } else if (playerNumber == 2)
                {
                    player2.GrabCards(amountOfCards);
                    Console.Write("Player 2 has: ");
                    player2.PrintHand(playerNumber);

                    Console.Write("Player 2 gives card: ");
                    string givenCard = Console.ReadLine();
                    if (player2.GiveCard(givenCard))
                    {
                        playingNewInstance.addingCardToStaple(givenCard);
                    }
                } else if (playerNumber == 3)
                {
                    player3.GrabCards(amountOfCards);
                    Console.Write("Player 3 has: ");
                    player3.PrintHand(playerNumber);

                    Console.Write("Player 3 gives card: ");
                    string givenCard = Console.ReadLine();
                    if (player3.GiveCard(givenCard))
                    {
                        playingNewInstance.addingCardToStaple(givenCard);
                    }
                }
                Console.WriteLine();
            }                   
            Console.ReadKey();
        }       
    }
}
