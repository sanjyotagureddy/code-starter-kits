namespace BowlingBall
{
  public interface IGame
  {
    void Roll(int pin);
    void Roll(int[] pins);
    int GetScore();
  }
}