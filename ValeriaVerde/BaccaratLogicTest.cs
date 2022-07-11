using NUnit.Framework;
using OOPGDC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static OOPGDC.BaccaratLogic;
using static OOPGDC.BaccaratLogicImpl;
using static OOPGDC.AccountManager;
using static OOPGDC.AdvancedAccountManagerImpl;
using static OOPGDC.AdvancedBalanceManagerImpl;
using static OOPGDC.BalanceManager;

namespace OOP21
{
    /// <summary>
    /// Test for LogicBaccarat 
    /// </summary>

    class TestLogicBaccarat
{
        private AccountManager account;
	    private BalanceManager balanceaccount;
	    private BaccaratLogic game;



        [Test]
        public void StartGame()
        {
            this.game.startGame(5);
	        Assert.AreEqual(this.game.getDealerHand().size(), 2);
	        Assert.AreEqual(this.game.getPlayerHand().size(), 2);
	        Assert.IsTrue(this.game.getPlayerPoints() >= 0 && this.game.getPlayerPoints() <= 9);
	        Assert.IsTrue(this.game.getDealerPoints() >= 0 && this.game.getDealerPoints() <= 9);
	        Assert.AreEqual(this.game.getBet(), 5, 0);
        }

        [Test]
        public void nextMove()
        {
            this.game.startGame(5);
	        this.game.nextMove();
	        Assert.IsTrue(this.game.getPlayerHand().size() >= 2);
	        Assert.IsTrue(this.game.getDealerHand().size() >= 2);
        }

        [Test]
        public void PlayerDraw()
        {
            this.game.startGame(5);
	        this.game.playerDraw();
	        Assert.AreEqual(this.game.getPlayerHand().size(), 3);
	        Assert.IsFalse(this.game.getPlayerHand().size() > 3);
        }

        [Test]
        public void DealerDraw()
        {
            this.game.startGame(5);
	        this.game.dealerDraw();
	        Assert.AreEqual(this.game.getDealerHand().size(), 3);
	        Assert.IsFalse(this.game.getDealerHand().size() > 3);
        }

        [Test]
        public void checkBaccarat()
        {
            this.game.startGame(5);
	        if(this.game.getPlayerPoints() == 8 || this.game.getPlayerPoints() == 9) {
	        	Assert.IsTrue(this.game.checkBaccarat(this.game.getPlayerHand()));
	        }
	        if(this.game.getDealerPoints() == 8 || this.game.getDealerPoints() == 9) {
	        	Assert.IsTrue(this.game.checkBaccarat(this.game.getDealerHand()));
	        }
        }

        [Test]
        public void testEndGame()
        {
	    	this.game.startGame(5);
	        this.game.nextMove();
	        this.game.endGame();
	        Assert.IsTrue(this.game.getDealerHand().size() <= 3);
	        Assert.IsTrue(this.game.getPlayerHand().size() <= 3);
	        Assert.IsFalse( this.game.getPlayerPoints() > 9);
	        Assert.IsFalse( this.game.getDealerPoints() > 9);
        }
    }
}