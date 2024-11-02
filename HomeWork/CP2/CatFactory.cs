namespace MikhailShvets_CatFrameWork;

public class CatFactory
{
    private static Random rnd = new Random();
    public static  Cat[] GenerateRandomCats(uint count)
    {
        Cat[] cats = new Cat[count];
        int index;
        bool created = false;

        while (!created)
        {
            try
            {
                for (uint i = 0; i < count; i++)
                {
                    index = rnd.Next(1, 2);
                    if (index == 1)
                    {
                        double weight = rnd.Next(50, 160);
                        int fluffiness = rnd.Next(-20, 120);
                        cats[i] = new Tiger(fluffiness, weight);
                    }

                    if (index == 2)
                    {
                        int fluffiness = rnd.Next(-20, 120);
                        cats[i] = new CuteCat(fluffiness);
                    }
                }
                created = true;
            }
            catch (CatException e)
            {
                Console.WriteLine(e);
                throw;
            }   
        }
        return cats;
    }
}