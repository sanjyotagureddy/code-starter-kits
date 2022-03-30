namespace BowlingBall
{
  public class Game : IGame
  {
    private readonly int[] _rolls;
    private int _rollIndex;

    public Game()
    {
      _rolls = new int[21];
    }

    public void Roll(int pin)
    {
      _rolls[_rollIndex++] = pin;
    }

    public void Roll(int[] pins)
    {
      foreach (var pin in pins)
        Roll(pin);
    }

    public int GetScore()
    {
      var score = 0;
      var frameIndex = 0;
      for (var frame = 0; frame < 10; frame++)
      {
        if (IsSpare(frameIndex))
        {
          score += 10 + _rolls[frameIndex + 2];
          frameIndex += 2;
        }
        else if (IsStrike(frameIndex))
        {
          score += 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
          frameIndex++;
        }
        else
        {
          score += _rolls[frameIndex] + _rolls[frameIndex + 1];
          frameIndex += 2;
        }
      }

      return score;
    }

    #region Private Methods

    private bool IsSpare(int frameIndex)
      => (_rolls[frameIndex] + _rolls[frameIndex + 1] == 10) && (_rolls[frameIndex] != 10);

    private bool IsStrike(int frameIndex)
      => _rolls[frameIndex] == 10;

    #endregion Private Methods
  }
}