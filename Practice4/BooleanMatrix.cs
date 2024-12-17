namespace Practice4
{
    public class BooleanMatrix
    {
        private int rows;
        private int columns;
        private bool[,] matrix;

        public int Rows
        {
            get => rows;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество строк должно быть больше 0.");
                rows = value;
            }
        }

        public int Columns
        {
            get => columns;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество столбцов должно быть больше 0.");
                columns = value;
            }
        }

        public BooleanMatrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = new bool[rows, columns];
        }

        public BooleanMatrix(bool[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Массив не должен быть null.");

            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
            matrix = (bool[,])array.Clone();
        }

        public bool this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Columns)
                    throw new IndexOutOfRangeException("Индексы выходят за границы матрицы.");
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Columns)
                    throw new IndexOutOfRangeException("Индексы выходят за границы матрицы.");
                matrix[i, j] = value;
            }
        }

        public int CountTrueValues()
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (matrix[i, j])
                        count++;
                }
            }

            return count;
        }

        public int CountFalseValues()
        {
            return Rows * Columns - CountTrueValues();
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(matrix[i, j] ? "1 " : "0 ");
                }

                Console.WriteLine();
            }
        }
    }
}