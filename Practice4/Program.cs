namespace Practice4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task234();
        }

        private static void Task234()
        {
            List<BooleanMatrix> matrices =
            [
                new(new[,]
                {
                    { true, false, true },
                    { false, true, false }
                }),

                new(new[,]
                {
                    { true, false, false },
                    { false, false, false }
                }),

                new(new[,]
                {
                    { true, true, true },
                    { true, false, true }
                }),

                new BooleanMatrix(2, 2)
            ];

            var matrixWithMinTrue = (from matrix in matrices orderby matrix.CountTrueValues() select matrix).FirstOrDefault();
            Console.WriteLine("Матрица с наименьшим количеством true:");
            matrixWithMinTrue?.Print();
            
            var matricesWithEqualFalse = matrices.Where(matrix => Enumerable
                .Range(0, matrix.Rows)
                .Select(i => Enumerable.Range(0, matrix.Columns).Count(j => !matrix[i, j]))
                .Distinct()
                .Count() == 1).ToList();

            Console.WriteLine("\nМатрицы с равным количеством false в каждой строке:");
            foreach (var matrix in matricesWithEqualFalse)
            {
                matrix.Print();
                Console.WriteLine();
            }

            var matrixWithMaxElements =
                matrices.OrderByDescending(matrix => matrix.Rows * matrix.Columns).FirstOrDefault();
            Console.WriteLine("Матрица с максимальным количеством элементов:");
            matrixWithMaxElements?.Print();

            int targetRows = 2, targetColumns = 2;
            int countOfSpecificSize =
                matrices.Count(matrix => matrix.Rows == targetRows && matrix.Columns == targetColumns);
            Console.WriteLine($"\nКоличество матриц размером {targetRows}x{targetColumns}: {countOfSpecificSize}");
            
            var matricesOrderedByTrue = matrices.OrderBy(matrix => matrix.CountTrueValues()).ToList();
            Console.WriteLine("\nУпорядоченный список матриц по количеству true:");
            foreach (var matrix in matricesOrderedByTrue)
            {
                Console.WriteLine($"Количество true: {matrix.CountTrueValues()}");
                matrix.Print();
                Console.WriteLine();
            }
        }

        private static void Task1()
        {
            string[] months =
            {
                "June", "July", "May", "December", "January",
                "February", "March", "April", "August",
                "September", "October", "November"
            };

            var n = 4;
            var monthsWithLengthN = from month in months where month.Length == n select month;

            Console.WriteLine($"Месяца с длиной = {n}:");
            foreach (var month in monthsWithLengthN)
            {
                Console.WriteLine(month);
            }

            var summerAndWinterMonths = from month in months
                where month is "June" or "July" or "August" or "December" or "January" or "February"
                select month;

            Console.WriteLine("\nЛетние и зимнее месяца:");
            foreach (var month in summerAndWinterMonths)
            {
                Console.WriteLine(month);
            }

            var monthsInAlphabeticalOrder = from month in months orderby month select month;

            Console.WriteLine("\nМесяца в алфавитном порядке:");
            foreach (var month in monthsInAlphabeticalOrder)
            {
                Console.WriteLine(month);
            }

            var countMonthsWithU = months.Count(month =>
                month.Contains('u') && month.Length >= 4);

            Console.WriteLine($"\nКоличество месяцев, содержащих 'u' и длиной >= 4: {countMonthsWithU}");
        }
    }
}