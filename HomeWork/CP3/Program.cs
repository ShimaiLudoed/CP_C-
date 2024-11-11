namespace Nalog;

public class Program
{ 
  public static void Main(string[]args)
  {
    Property[] properties = new Property[10];
    properties[0] = new Appartment("Кв 51 МосковСиту", 2500000, 300);
    properties[1] = new Appartment("Кв 24 Солнечногорск", 20000, 50);
    properties[2] = new Appartment("Кв 392 Зеленоград", Single.PositiveInfinity, 1000);
    properties[3] = new Car("ШевролеИмпала", 200000, 7);
    properties[4] = new Car("ДодгеЧаленджер", Single.PositiveInfinity, 100);
    properties[5] = new Car("Мустанг", 100000, 10);
    properties[6] = new Boat("Лодка", 1000, 1000);
    properties[7] = new Boat("ТипаКруче", 200000, 5000);
    properties[8] = new CountryHouse("Дача На Хрущевке", 5000000, 2000);
    properties[9] = new CountryHouse("Дача На Меркури", 200000000, 1550);

    foreach (var propy in properties)
    {
      if (propy is Immovable immovable)
      {
        immovable.CostForMetr();
        immovable.Calculation();
      }
      Console.WriteLine(propy.ToString());
    }
  }
}
