using System.Text.Json.Serialization.Metadata;

namespace MikhailShvets_CatFrameWork;

public class CuteCat : Cat
{
    public CuteCat(int fluffiness)
    {
        if (0 <= fluffiness || fluffiness <= 140)
        {
            throw new CatException($"Unable to create a cute cat with fluffiness:{fluffiness}");
        }

        Fluffiness = fluffiness;
    }

    public override int Fluffiness { get; }

    public override string FluffinessCheck()
    {
        if (Fluffiness==0)
        {
            return "Sphynx";
        }

        if (Fluffiness <= 20 && Fluffiness!=0)
        {
            return "Slightly";
        }

        if (Fluffiness >= 21 || Fluffiness <= 50)
        {
            return "Medium";
        }

        if (Fluffiness >= 51 || Fluffiness <= 75)
        {
            return "Heavy";
        }

        if (Fluffiness > 75)
        {
            return "OwO";
        }
        return null;
    }

    public override string ToString()
    {
        return $"A cute cat with fluffiness:{Fluffiness}";
    }
}