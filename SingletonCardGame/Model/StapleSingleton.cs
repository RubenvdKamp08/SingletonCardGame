using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SingletonCardGame.Model
{
    public class StapleSingleton
    {
        private static StapleSingleton firstInstance = null;

        static string[] cards = { "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "B♥", "Q♥", "H♥",
                                   "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "B♦", "Q♦", "H♦",
                                   "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "B♣", "Q♣", "H♣",
                                   "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "B♠", "Q♠", "H♠",};

        static string[] cards1 = { "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "10h", "Jh", "Qh", "Kh",
                                   "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "10d", "Jd", "Qd", "Kd",
                                   "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "10c", "Jc", "Qc", "Kc",
                                   "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "10s", "Js", "Qs", "Ks",};

        List<string> cardList = cards1.OfType<string>().ToList();

        private StapleSingleton() { }

        public static StapleSingleton getInstance()
        {
            if(firstInstance == null)
            {
                firstInstance = new StapleSingleton();

                firstInstance.cardList.Shuffle();
            }
            return firstInstance;
        }


        //get cards in the staple
        public List<string> getCardsInStaple()
        {
            return firstInstance.cardList;
        }


        //get cards from the staple

            //TODO : make sure that the cards will add to the user
        public List<string> getCards(int amount)
        {
            List<string> cardsToGive = new List<string>();

            for(int i = 0; i < amount; i++)
            {
                cardsToGive.Add(firstInstance.cardList.First());
                firstInstance.cardList.RemoveAt(0);
            }

            return cardsToGive;
        }       

        public void PrintStock()
        {
            foreach (string card in getCardsInStaple())
            {
                Console.Write(card + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    //to make the shuffle functionality
    public static class IListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
