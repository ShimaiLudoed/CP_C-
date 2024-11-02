namespace MikhailShvets_CatFrameWork;

public class Tiger : Cat
{
    public override int Fluffiness { get; }
    public double Weight { get; }

    public override string FluffinessCheck()
    {
        return ("Kycb");
    }

    public Tiger(int fluffiness, double weight)
    {
        if (75.0 <= weight || weight<=140.0)
        {
           throw new CatException($"Unable to create a tiger with weight: {weight}");
        }

        if (0 <= fluffiness || fluffiness <= 100)
        {
            throw new CatException($"Unable to create a tiger with fluffiness{fluffiness}");
        }
        Fluffiness = fluffiness;
        Weight = weight;
    }
}