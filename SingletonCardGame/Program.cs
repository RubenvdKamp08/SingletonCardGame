using SingletonCardGame.Model;
using System;
using System.Collections.Generic;

namespace SingletonCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StapleSingleton newInstance = StapleSingleton.getInstance();
            PlayingStapleSingleton playingNewInstance = PlayingStapleSingleton.getInstance();

            List<User> users = new List<User>();

            Console.Write("How many players: ");
            int amountOfPlayers = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= amountOfPlayers; i++)
            {
                Console.Write("Name of player " + i + ": ");
                string userName = Console.ReadLine();
                users.Add(new User(i, userName));
            }

            Console.Write("How many rounds: ");
            int amountOfRounds = Convert.ToInt32(Console.ReadLine());

            Random r = new Random();

            for (int i = 0; i <= amountOfRounds; i++)
            {
                int playerNumber = r.Next(1, amountOfPlayers + 1);
                Console.WriteLine("\n----------status---------- \n");
                playingNewInstance.printStaple();
                newInstance.PrintStock();
                
                Console.WriteLine("----------round "+ (i+1) +"----------\n");                
                foreach(User user in users)
                {
                    if(user.Id == playerNumber)
                    {
                        Console.Write(user.Name + " grab amount of cards: ");
                        int amountOfCards = Convert.ToInt32(Console.ReadLine());

                        user.GrabCards(amountOfCards);
                        user.PrintHand();

                        Console.Write(user.Name + " gives card: ");
                        string givenCard = Console.ReadLine();
                        if (user.GiveCard(givenCard))
                        {
                            playingNewInstance.addingCardToStaple(givenCard);
                        }
                    }
                }                                
            }
            Console.WriteLine("\n----------end result----------\n");
            playingNewInstance.printStaple();
            newInstance.PrintStock();

            foreach (User user in users)
            {
                user.PrintHand();
            }
            Console.ReadKey();
        }       
    }
}
