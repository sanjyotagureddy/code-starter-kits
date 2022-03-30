using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
  [TestClass]
  public class GameFixture
  {
    private IGame _game;

    [TestMethod]
    public void Gutter_game_score_should_be_zero_test()
    {
      _game = new Game();
      Roll(0, 20);
      Assert.AreEqual(0, _game.GetScore());
    }

    [TestMethod]
    public void All_Ones_game_score_should_be_twenty_test()
    {
      _game = new Game();
      Roll(1, 20);
      Assert.AreEqual(20, _game.GetScore());
    }

    [TestMethod]
    public void All_Ones_spare_and_all_gutter_score_should_be_10_test()
    {
      _game = new Game();
      _game.Roll(6);
      _game.Roll(4);

      Roll(0, 18);
      Assert.AreEqual(10, _game.GetScore());
    }

    [TestMethod]
    public void All_Ones_spare_one_nonspare_and_gutter_score_should_be_10_test()
    {
      _game = new Game();
      _game.Roll(new[] { 6, 4, 7 });


      Roll(0, 17);
      Assert.AreEqual(24, _game.GetScore());
    }

    [TestMethod]
    public void Spare_game_score_should_be_150_test()
    {
      _game = new Game();
      Roll(5, 21);
      Assert.AreEqual(150, _game.GetScore());
    }

    [TestMethod]
    public void Strike_game_score_should_be_300_test()
    {
      _game = new Game();
      Roll(10, 12);
      Assert.AreEqual(300, _game.GetScore());
    }

    [TestMethod]
    public void Random_pins_no_bonus_game_score_should_be_78_test()
    {
      _game = new Game();
      _game.Roll(3);
      _game.Roll(7);       // Frame 1 - 14
      _game.Roll(4);
      _game.Roll(3);       // Frame 2 - 21
      _game.Roll(2);
      _game.Roll(7);       // Frame 3 - 30
      _game.Roll(4);
      _game.Roll(1);       // Frame 4 - 35
      _game.Roll(0);
      _game.Roll(7);       // Frame 5 - 42
      _game.Roll(8);
      _game.Roll(2);       // Frame 6 - 55
      _game.Roll(3);
      _game.Roll(1);       // Frame 7 - 59
      _game.Roll(0);
      _game.Roll(3);       // Frame 8 - 62
      _game.Roll(7);
      _game.Roll(2);       // Frame 9 - 71
      _game.Roll(7);
      _game.Roll(0);       // Frame 10 - 78

      Assert.AreEqual(78, _game.GetScore());
    }

    [TestMethod]
    public void Random_pins_with_bonus_game_score_should_be_89_test()
    {
      _game = new Game();
      _game.Roll(3);
      _game.Roll(7);       // Frame 1 - 14
      _game.Roll(4);
      _game.Roll(3);       // Frame 2 - 21
      _game.Roll(2);
      _game.Roll(7);       // Frame 3 - 30
      _game.Roll(4);
      _game.Roll(1);       // Frame 4 - 35
      _game.Roll(0);
      _game.Roll(7);       // Frame 5 - 42
      _game.Roll(8);
      _game.Roll(2);       // Frame 6 - 55
      _game.Roll(3);
      _game.Roll(1);       // Frame 7 - 59
      _game.Roll(0);
      _game.Roll(3);       // Frame 8 - 62
      _game.Roll(7);
      _game.Roll(2);       // Frame 9 - 71
      _game.Roll(8);
      _game.Roll(2);
      _game.Roll(8);       // Bonus Frame 10 - 89

      Assert.AreEqual(89, _game.GetScore());
    }

    private void Roll(int pins, int times)
    {
      for (var i = 0; i < times; i++)
      {
        _game.Roll(pins);
      }
    }
  }
}