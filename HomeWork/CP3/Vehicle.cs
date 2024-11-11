namespace Nalog;

public class Vehicle : Property
{
  protected string VehicleType;
  protected int Litr;
  public Vehicle(string vehicleType, float worth, int litr) : base(worth)
  {
    VehicleType = vehicleType;
    Litr=litr;
  }

  public override void Calculation()
  {
    Worth += Worth * Litr / 3000;
  }
  
  public override string ToString()
  {
    return $"{VehicleType}, стоиомсть {Worth}, объём {Litr}";
  }
}