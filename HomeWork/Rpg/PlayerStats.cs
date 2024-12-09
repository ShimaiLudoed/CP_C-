namespace PlayerGame
{
  public class PlayerStats
  {
    public int _health;
    public int CurHealth;
    public int Power { get; set; }
    public float Crit { get; set; }
    public int Experience { get;  set; }
    public int Level { get;  set; }
    public PlayerStats(int health, int power, float crit)
    {
      _health = health;
      CurHealth = _health;
      Power = power;
      Crit = crit;
      Level = 0;
      Experience = 0;
    }
  }
}