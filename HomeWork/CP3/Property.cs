namespace Nalog;

public abstract class Property
{
  protected float Worth;

  protected  Property(float worth)
  {
    Worth = worth;
  }

  public virtual void Calculation()
  {
    
  }
}