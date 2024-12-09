using PlayerGame;

namespace EnemyGame;

public class Enemy
{
  public string Name;
  public int Health;
  public int AttackPower;

  public Enemy(string name, int health, int attackPower)
  {
    Name = name;
    Health = health;
    AttackPower = attackPower;
  }

  public void Attack(Player player)
  {
    player.Stats.CurHealth -= AttackPower;
    Console.WriteLine($"{Name} атакует {player.Name} на {AttackPower} урона!");
  }
  public static Enemy GenerateRandomEnemy()
  {
    string[] names = { "Гоблин", "Орк", "Дракон", "Скелет" };
    Random rand = new Random();
    string name = names[rand.Next(names.Length)];
    int health = rand.Next(20, 51); // Случайное здоровье от 20 до 50
    int attackPower = rand.Next(5, 16); // Случайная сила атаки от 5 до 15
    return new Enemy (name, health, attackPower);
  }
}