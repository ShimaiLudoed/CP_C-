using EnemyGame;
using PlayerGame;

namespace RpgGame
{
  public class Programm
  {
    private static Player _player;

    public static void Main(string[] args)
    {
      MakeHero();
      Game();
    }

    public static void Game()
    {
      for (int i = 0; i < 15; i++)
      {
        StartBattle(_player);
      }
    }

    public static void MakeHero()
    {
      Console.WriteLine("Выберите класс для вашего персонажа:");
      Console.WriteLine("1. Воин");
      Console.WriteLine("2. Лучник");
      Console.WriteLine("3. Маг");

      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        Console.Write("Введите имя вашего персонажа: ");
        string name = Console.ReadLine();

        PlayerClass chosenClass;

        switch (choice)
        {
          case 1:
            chosenClass = PlayerClass.Warrior;
            break;
          case 2:
            chosenClass = PlayerClass.Archer;
            break;
          case 3:
            chosenClass = PlayerClass.Mage;
            break;
          default:
            Console.WriteLine("Неверный выбор!");
            return;
        }

        _player = new Player(name, chosenClass);
        Console.WriteLine($"Ваш персонаж: {_player.Name}, класс: {_player.Class}");
        Console.WriteLine(_player.Stats.ToString());
      }
      else
      {
        Console.WriteLine("Некорректный ввод.");
      }
    }

    public static void StartBattle(Player player)
    {
      Enemy enemy = Enemy.GenerateRandomEnemy();
      Console.WriteLine($"Вы встретили {enemy.Name}!");
        while (player.Stats.CurHealth > 0 && enemy.Health > 0)
        {
          Console.WriteLine($"Здоровье героя: {player.Stats.CurHealth}, Здоровье монстра: {enemy.Health}");
          Console.WriteLine("Выберите действие: 1 - Атаковать, 2 - Восстановить здоровье");
          int choice = int.Parse(Console.ReadLine());

          if (choice == 1)
          {
            player.Attack(enemy);
          }
          else if (choice == 2)
          {
            player.Heal();
          }

          if (enemy.Health > 0)
          {
            enemy.Attack(player);
          }
        }

      if (player.Stats.CurHealth <= 0)
      {
        Console.WriteLine("Вы погибли! Игра закончена.");
        player.Died();
      }
      else
      {
        Console.WriteLine($"Вы победили {enemy.Name}!");
        player.Stats.Experience += 25;
        if (player.Stats.Experience >= 100)
        {
          player.AddLevel();
          player.Upgrade();
        }
      }
    }
  }
}

