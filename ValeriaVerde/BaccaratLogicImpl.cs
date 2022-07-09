using System;

using System.Drawing;
using static OOPGDC.Deck;
using static OOPGDC.DeckImpl;
using static OOPGDC.Hand;
using static OOPGDC.HandImpl;




namespace OOPGDC
{
    /// <summary>
    /// Class that models the implementation of baccarat logic game
    /// </summary>
    public class BaccaratLogicImpl : BaccartLogic
    {
        private BalanceManager account;
        private Deck deck;
        private double bet;
        private Hand player;
        private Hand dealer;
        private int baccaratcard;

    /// <summary>
    ///  Constructor
    /// <!summary>

  public BaccaratLogicImpl(BalanceManager account)
        {
            this.deck = new DeckImpl(6);
            this.deck.generateDeck();
            this.account = account;
            this.bet = 0;
        }



        /// <summary>
        /// start of the game, both dealer and player start with 2 cards
        /// </summary>


        public void startGame(double bet)
        {
            this.bet = bet;
            account.withdraw(this.bet);
            this.player = new HandImpl();
            this.dealer = new HandImpl();

            this.player.addCard(this.deck.drawRandomCard());
            this.player.addCard(this.deck.drawRandomCard());
            this.baccaratcard = this.player.getCard(1).getValue();
            this.dealer.addCard(this.deck.drawRandomCard());
            this.dealer.addCard(this.deck.drawRandomCard());
            this.dealer.calculatePoints();
            this.player.calculatePoints();
        }

        /// <summary>
        /// next move of the game
        /// </summary>

        public void nextMove()
        {
            nextPlayerMove();
            nextDealerMove();
        }

        /// <summary>
        ///player draw a card
        /// </summary>

        public void playerDraw()
        {
            this.player.addCard(this.deck.drawRandomCard());
            this.player.calculatePoints();
        }

        /// <summary>
        /// dealer draw a card
        /// </summary>

        public void dealerDraw()
        {
            this.dealer.addCard(this.deck.drawRandomCard());
            this.dealer.calculatePoints();
        }

        /// <summary>
        /// check who wins
        /// </summary>
        /// <returns> 1 for player wins, -1 for dealer wins and 0 for tie </returns>

        public int checkWin()
        {
            if (getPlayerPoints() == getDealerPoints())
            {
                return 0;
            }
            if (getPlayerPoints() <= getDealerPoints())
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// next move of the dealer, can draw or do nothing
        /// </summary>

        public void nextDealerMove()
        {
            if (this.dealer.getCard(1).isFaceDown())
            {
                this.dealer.getCard(1).turnOver();
                nextDealerMove();
            }
            else if (checkBaccarat(this.dealer))
            {
                endGame();
            }
            else if (getDealerPoints() == 2 || getDealerPoints() == 1 || checkBaccarat(this.dealer))
            {
                dealerDraw();
            }
            else if (getDealerPoints() == 3 && this.baccaratcard != 8 && this.baccaratcard != 9)
            {
                dealerDraw();
            }
            else if (getDealerPoints() == 4 && this.baccaratcard >= 2 && this.baccaratcard <= 7)
            {
                dealerDraw();
            }
            else if (getDealerPoints() == 5 && this.baccaratcard >= 4 && this.baccaratcard <= 7)
            {
                dealerDraw();
            }
            else if (getDealerPoints() == 6 && this.baccaratcard == 6 || this.baccaratcard == 7)
            {
                dealerDraw();
            }
            else if (getDealerPoints() == 7)
            {
                //no draw
            }
        }

        /// <summary>
        /// next move of the player, can draw or do nothing
        /// </summary>

        public void nextPlayerMove()
        {
            if (checkBaccarat(this.player))
            {
                endGame();
            }
            else if (getPlayerPoints() != 6 && getPlayerPoints() != 7)
            {
                playerDraw();
            }
            //no draw
        }

        /// <summary>
        /// get the player hand
        /// </summary>
        /// /// <returns> player hand </returns>

        public Hand getPlayerHand()
        {
            return this.player;
        }

        /// <summary>
        /// get the dealer hand
        /// </summary>
        /// <returns> dealer hand </returns>

        public Hand getDealerHand()
        {
            return this.dealer;
        }


        /// <summary>
        /// get the player points
        /// </summary>
        /// <returns> player total points </returns>


        public int getPlayerPoints()
        {
            return this.player.getBaccaratPoints();

        }

        /// <summary>
        /// get the dealer points
        /// </summary>
        /// <returns> dealer total points </returns>


        public int getDealerPoints()
        {
            return this.dealer.getBaccaratPoints();
        }

        /// <summary>
        /// check the hand baccarat
        /// </summary>
        /// <returns> true if the hand in input have baccarat, false otherwise </returns>


        public bool checkBaccarat(Hand h)
        {
            return ((h.getBaccaratPoints() == 8 || h.getBaccaratPoints() == 9) && h.size() == 2);
        }


        /// <summary>
        /// end the game
        /// </summary>

        public void endGame()
        {
            if (this.deck.size() <= (this.deck.getnDecks() * 13 * 4) / 2)
            {
                this.deck.shuffle();
            }
            if (checkWin() == 1)
            {
                account.changeBalance(account.getBalance() + (this.bet * 2));
            }
            else if (checkWin() == 0)
            {
                account.changeBalance(account.getBalance() + (this.bet));
            }
        }


        /// <summary>
        /// get player bet
        /// </summary>
        /// <returns> the bet set by player </returns>

        public double getBet()
        {
            return this.bet;
        }
    }
}