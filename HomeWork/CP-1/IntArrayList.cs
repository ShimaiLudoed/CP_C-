namespace HomeWork
{
    public class IntArrayList
    {
        private int[] buffer;
        private int count;
        private int realCap;
        private readonly int defaultCap = 2;

        public static void Main(string[] args)
        {
            
        }

    public IntArrayList()
        {
            buffer = new int[defaultCap];
            count = 0;
            realCap = defaultCap;
        }

        public IntArrayList(int initialRealCap)
        {
            buffer = new int[initialRealCap];
            count = 0;
            realCap = initialRealCap;
        }

        public int Count
        {
            get { return count; }
        }

        public int RealCap
        {
            get { return realCap; }
        }

        public int this[int index] // индексатор для доступа к элементам массива без проверки 
        {
            get { return buffer[index]; }
            set { buffer[index] = value; }
        }

        public void PushBack(int value)
        {
            if (count >= realCap)
            {
                int newCapacity = realCap * 2;
                Array.Resize(ref buffer, newCapacity);
                realCap = newCapacity;
            }

            buffer[count] = value;
            count++;
        }

        public void PopBack()
        {
            if (count > 0)
            {
                count--;
            }
        }

        public bool TryInsert(int index, int value)
        {
            if (index < 0 )
            {
                return false;
            }

            if (index == count)
            {
                PushBack(value);
            }
            else
            {
                if (count >= realCap)
                {
                    int newCapacity = realCap * 2;
                    Array.Resize(ref buffer, newCapacity);
                    realCap = newCapacity;
                }

                Array.Copy(buffer, index, buffer, index + 1, count - index);
                buffer[index] = value;
                count++;
            }

            return true;
        }

        public bool TryErase(int index)
        {
            if (index < 0 || index >= count)
            {
                return false;
            }

            Array.Copy(buffer, index + 1, buffer, index, count - index - 1);
            count--;

            return true;
        }

        public bool TryGetAt(int index, out int result)
        {
            if (index < 0 || index >= count)
            {
                result = 0;
                return false;
            }

            result = buffer[index];
            return true;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool TryForceCapacity(int newCapacity)
        {
            if (newCapacity < 0)
            {
                return false;
            }

            if (newCapacity > realCap)
            {
                Array.Resize(ref buffer, newCapacity);
                realCap = newCapacity;
            }

            return true;
        }

        public int Find(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (buffer[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}