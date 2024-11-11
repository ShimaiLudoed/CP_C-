using System.Threading.Channels;

namespace Nalog;

public class Immovable : Property
{
  protected string HouseType;
  protected int Metr;
  protected float ForMetr;
  protected float Tax;
  
  public Immovable(string houseType, float worth, int metr) : base(worth)
  {
    HouseType = houseType;
    Metr = metr;
  }

  public void CostForMetr()
  {
    ForMetr = Worth / Metr;
  }

  public override void Calculation()
  {
    switch (Metr)
    {
      case < 100:
        Tax=Worth/500;
        break;
      case > 100 and <= 300:
        Tax=Worth/350;
        break;
      case > 300:
        Tax=Worth/250;
        break;
    }
  }

  public override string ToString()
  {
    return $"{HouseType}, стоимость {Worth}, налог {Tax}, площадь {Metr}";
  }
}