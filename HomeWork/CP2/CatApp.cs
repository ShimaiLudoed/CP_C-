using MikhailShvets_CatFrameWork;

namespace MikhailShvets_CatApp
{
    public static class CatApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество кошек");
            string catCount = Console.ReadLine();

            uint count = 0;
            bool start = false;
            while (!start)
            {
                count = uint.Parse(catCount!);
                if (count > 0)
                {
                    start = true;
                }
                else
                {
                    Console.WriteLine("Напишите число больше 0!");
                    catCount = Console.ReadLine();
                }
            }
            
            Cat[] cats = CatFactory.GenerateRandomCats(count); 
            
            Console.Write("Введите путь к файлу для сохранения информации: ");
            string filePath = Console.ReadLine();

            DisplayCatInfo(cats, filePath);
        }

        public static void DisplayCatInfo(Cat[] catsArr, string path)
        {
            foreach (var cat in catsArr)
            {
                string fluf = (cat.FluffinessCheck());
                string toString = (cat.ToString());

                Console.WriteLine(fluf);
                Console.WriteLine(toString);
            }
        }
    }
}