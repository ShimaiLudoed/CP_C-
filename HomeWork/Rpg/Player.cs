using EnemyGame;
using System.Net.Mime;
using System.Threading.Channels;

namespace PlayerGame
{
  public class Player
  {
    public string Name { get; private set; }
    public PlayerStats Stats { get; private set; }
    public PlayerClass Class { get; private set; }
    public int HealUsage { get; private set; } 
    public int MaxHeals { get; private set; }
    
    public Player(string name, PlayerClass playerClass)
    {
      Name = name;
      Class = playerClass;
      Stats = SetStats(playerClass);
      MaxHeals = 4;
      HealUsage = 0;
    }

    private PlayerStats SetStats(PlayerClass playerClass)
    {
      switch (playerClass)
      {
        case PlayerClass.Warrior:
          return new PlayerStats(150, 50, 20);
        case PlayerClass.Archer:
          return new PlayerStats(75, 100, 25);
        case PlayerClass.Mage:
          return new PlayerStats(100, 75, 70);
        default:
          throw new ArgumentException("unknown");
      }
    }
    public void Heal()
    {
      if (HealUsage < MaxHeals)
      {
        if (Stats.CurHealth + 50 > Stats._health)
        {
          int heal = Stats._health - Stats.CurHealth;
          Stats.CurHealth += heal;
        }
        else
        {
          Stats.CurHealth += 50; 
        }
        HealUsage++;
        Console.WriteLine($"{Name} восстановил здоровьe. Текущее здоровье: {Stats.CurHealth}");
      }
      else
      {
        Console.WriteLine("Вы исцелились максимальное количество раз.");
      }
    }
    public void Attack(Enemy enemy)
    {
      Random random = new Random();
      int criticalHitChance = random.Next(100);
      
      if (criticalHitChance < Stats.Crit)
      {
        Stats.Power *= 2;
        Console.WriteLine("Критический удар!");
      }

      enemy.Health -= Stats.Power;
      Console.WriteLine($"{Name} атакует и наносит {Stats.Power} урона. Здоровье монстра: {enemy.Health}");
    }
    
    public void AddLevel()
    {
        Stats.Level++;
        Console.WriteLine("Повышение!");
        Stats.Experience = 0;
    }

    public void Upgrade()
    {
      Console.WriteLine("выберите улучшение!");
      Console.WriteLine("1. +25 к здоровью");
      Console.WriteLine("2. +15 к урону");
      Console.WriteLine("3. +15% к криту");
      int choice = int.Parse(Console.ReadLine());
      switch (choice)
      {
       case 1:
          Stats._health += 25;
          break;
       case 2:
         Stats.Power += 15;
         break;
       case 3:
         Stats.Crit += 15;
         break;
      }
    }

    public void Died()
    {
      Environment.Exit(0);
    }
  }
}