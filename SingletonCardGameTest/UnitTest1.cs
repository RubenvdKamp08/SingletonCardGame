using NUnit.Framework;
using SingletonCardGame.Model;

namespace Tests
{
    public class Tests
    {        
        [Test]
        public void getStack_stackGenerated_AllCardsInStack()
        {
            //Arrange
            StackSingleton stackInstance = StackSingleton.GetInstance();
            var cardsBeforeGrabbingCards = stackInstance.GetStack().Count;

            //Act
            
            //Assert
            var cardsAfterGrabbingCards = stackInstance.GetStack().Count;
            Assert.AreEqual(cardsBeforeGrabbingCards, cardsAfterGrabbingCards);
        }

        [Test]
        public void getStack_playerGetCards_CertainAmountOfCards()
        {
            //Arrange
            StackSingleton stackInstance = StackSingleton.GetInstance();
            var cardsBeforeGrabbingCards = stackInstance.GetStack().Count;
            User user = new User(1, "peter");

            //Act
            user.GrabCards(2);

            //Assert
            var cards = stackInstance.GetStack().Count;
            Assert.AreEqual(cardsBeforeGrabbingCards - 2, cards);
        }

        [Test]
        public void getStack_playersGetCards_CertainAmountOfCards()
        {
            //Arrange
            StackSingleton stackInstance = StackSingleton.GetInstance();
            var cardsBeforeGrabbingCards = stackInstance.GetStack().Count;
            User user = new User(1, "peter");
            User user2 = new User(2, "steve");

            //Act
            user.GrabCards(2);
            user2.GrabCards(4);

            //Assert
            var cards = stackInstance.GetStack().Count;
            Assert.AreEqual(cardsBeforeGrabbingCards - 6, cards);
        }

        [Test]
        public void getStack_threePlayersGetCards_CertainAmountOfCards()
        {
            //Arrange
            StackSingleton stackInstance = StackSingleton.GetInstance();
            var cardsBeforeGrabbingCards = stackInstance.GetStack().Count;
            User user = new User(1, "peter");
            User user2 = new User(2, "steve");
            User user3 = new User(2, "jack");

            //Act
            user.GrabCards(2);
            user2.GrabCards(4);
            user3.GrabCards(10);

            //Assert
            var cards = stackInstance.GetStack().Count;
            Assert.AreEqual(cardsBeforeGrabbingCards - 16, cards);
        }

        [Test]
        public void getPlayingStack_noCardsGiven_noCards()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amount = playingStackInstance.GetStack().Count;

            //Assert
            Assert.AreEqual(0, amount);
        }

        [Test]
        public void getPlayingStack_oneCardGiven_oneCard()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amountBeforePlay = playingStackInstance.GetStack().Count;
            StackSingleton stackInstance = StackSingleton.GetInstance();
            User user = new User(1, "peter");

            //Act
            user.GrabCards(2);
            string card = user.GetCards()[0];
            user.PlayCard(card);

            //Assert
            int amountAfterPlay = playingStackInstance.GetStack().Count;
            Assert.AreEqual(amountBeforePlay + 1, amountAfterPlay);
        }

        [Test]
        public void getPlayingStack_twoCardsGiven_twoCards()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amountBeforePlay = playingStackInstance.GetStack().Count;
            StackSingleton stackInstance = StackSingleton.GetInstance();
            User user = new User(1, "peter");
            User user2 = new User(2, "steve");

            //Act
            user.GrabCards(2);
            string card = user.GetCards()[0];
            user.PlayCard(card);

            user2.GrabCards(2);
            card = user2.GetCards()[0];
            user2.PlayCard(card);

            //Assert
            int amountAfterPlay = playingStackInstance.GetStack().Count;
            Assert.AreEqual(amountBeforePlay + 2, amountAfterPlay);
        }

        [Test]
        public void getPlayingStack_threeCardsGiven_threeCards()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amountBeforePlay = playingStackInstance.GetStack().Count;
            StackSingleton stackInstance = StackSingleton.GetInstance();
            User user = new User(1, "peter");
            User user2 = new User(2, "steve");
            User user3 = new User(3, "jack");

            //Act
            user.GrabCards(2);
            string card = user.GetCards()[0];
            user.PlayCard(card);

            user2.GrabCards(2);
            card = user2.GetCards()[0];
            user2.PlayCard(card);

            user3.GrabCards(2);
            card = user3.GetCards()[0];
            user3.PlayCard(card);

            //Assert
            int amountAfterPlay = playingStackInstance.GetStack().Count;
            Assert.AreEqual(amountBeforePlay + 3, amountAfterPlay);
        }

        [Test]
        public void getPlayingStackAndStack_multipleCardsGrabbedAndGiven_MultipleCards()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amountBeforePlay = playingStackInstance.GetStack().Count;
            StackSingleton stackInstance = StackSingleton.GetInstance();
            int amountBeforeGrab = stackInstance.GetStack().Count;
            User user = new User(1, "peter");
            User user2 = new User(2, "steve");
            User user3 = new User(3, "jack");

            //Act
            user.GrabCards(2);
            var card = user.GetCards()[0];
            user.PlayCard(card);

            user2.GrabCards(4);
            card = user2.GetCards()[0];
            user2.PlayCard(card);

            user3.GrabCards(4);
            card = user3.GetCards()[0];
            user3.PlayCard(card);

            //Assert
            int amountAfterPlay = playingStackInstance.GetStack().Count;
            int amountAfterGrab = stackInstance.GetStack().Count;
            Assert.AreEqual(amountBeforePlay + 3, amountAfterPlay);
            Assert.AreEqual(amountBeforeGrab - 10, amountAfterGrab);
        }

        [Test]
        public void getPlayingStack_oneWrongCardGiven_noCards()
        {
            //Arrange
            PlayingStackSingleton playingStackInstance = PlayingStackSingleton.GetInstance();
            int amountBeforePlay = playingStackInstance.GetStack().Count;
            StackSingleton stackInstance = StackSingleton.GetInstance();
            User user = new User(1, "peter");
            string card = "not possible";

            //Act
            user.PlayCard(card);

            //Assert
            int amountAfterPlay = playingStackInstance.GetStack().Count;
            Assert.AreEqual(amountBeforePlay, amountAfterPlay);
        }

    }
}