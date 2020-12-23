using System;
using System.Globalization;


namespace MatrixHomework
{
    enum Options
    {
        Add = 1,
        SortDescending,
        SortAscending,
        Inversion,
        SearchPositive,
        SearchNegative,
        NumberOfNegative,
        NumberOfPositive,
        RequestedExit,
        Clear = 9,
        Exit
    }
    class Program
    {
        private static ulong cols ;
        private static ulong rows;
        private static double[,] matrix;
        private static bool RequestedExit;

        static void Main(string[] args)
        {
            RunApplication();
        }

        static void RunApplication()
        {
            EnterMatrix();

            // While RequestExit = false perform method ApplyCommand

            while (!RequestedExit)
            {
                ShowCommands();
                WaitForCommand();
            }
        }


        // Methode implements basic commands
        static void WaitForCommand()
        {
            ShowAttentionMsg("> ");
            int command;

            while (!int.TryParse(Console.ReadLine(), out command))
            {
                ShowErrorMsg($"Command:{command} doesn't exist\n");
            }

            ApplyCommand(command);
        }

        static void ApplyCommand(int command)
        {
            switch ((Options)command)
            {
               
                case Options.Add:
                    EnterMatrix();
                    break;
                
                case Options.SortDescending:
                    SortDescendingMatrix();
                    break;

                case Options.SortAscending:
                    SortAscendingMatrix();
                    break;

                case Options.Inversion:
                    InversionMatrix();
                    break;

                case Options.SearchPositive:
                    SearchPositiveNumber();
                    break;

                case Options.SearchNegative:
                    SearchNegativeNumber();
                    break;

                case Options.NumberOfNegative:
                    NumberOfNegativeNumbers();
                    break;

                case Options.NumberOfPositive:
                    NumberOfPositiveNumbers();
                    break;

                case Options.Clear:
                    ClearDisplay();
                    break;

                case Options.Exit:
                    RequestedExit = true;
                    break;

                default:
                    ShowErrorMsg($"Command:{command} doesn't exist\n");
                    break;
            }
        }

        static void ClearDisplay()
        {
            Console.Clear();
        }

        //The number of posotive numbers in the matrix

        static void NumberOfPositiveNumbers()
        {
            double positiveNumber = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] > 0)
                    {
                        positiveNumber++;
                    }
                }
            }

            if (positiveNumber > 0)
            {
                ShowAttentionMsg($"The number of positive numbers in the matrix = {positiveNumber}\n");
            }
            else
            {
                ShowErrorMsg("There aren't posotive numbers in the matrix.");
            }
        }

        // The number of negative numbers in the matrix

        static void NumberOfNegativeNumbers()
        {
            double negativeNumber = 0;
            double negNumb = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] < negNumb)
                    {
                        negNumb = matrix[i, j];
                        negativeNumber++;
                    }
                }
            }

            if (negNumb < 0)
            {
                ShowAttentionMsg($"The number of negative numbers in the matrix = {negativeNumber}\n");
            }
            else
            {
                ShowErrorMsg("There aren't negative numbers in the matrix.");
            }
        }

        //Finding the maximum negative number

        static void SearchNegativeNumber()
        {
            double maxNegative = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < maxNegative)
                    {
                        maxNegative = matrix[i, j];
                    }
                }
            }

            if (maxNegative < 0)
            {
                ShowAttentionMsg($"Minimum negative number in the matrix = {maxNegative}\n");
            }
            else
            {
                ShowErrorMsg("There aren't negative numbers in the matrix.");
            }
        }


        //Finding the maximum positive number

        static void SearchPositiveNumber()
        {
            double maxPositive = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] > maxPositive)
                    {
                        maxPositive = matrix[i, j];
                    }
                }
            }

            if (maxPositive > 0)
            {
                ShowAttentionMsg($"Maximum positive number in the matrix= {maxPositive}\n");
            }
            else
            {
                ShowErrorMsg("There aren't posotive numbers in the matrix.");
            }
        }

        // Matrix inversion

        static void InversionMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int index1 = i * matrix.GetLength(1) + j;


                    for (int index2 = index1 + 1; index2 < matrix.Length; index2++)
                    {
                        var valueAtIndex2 = GetBySingleIndex(matrix, index2);

                        double temp = matrix[i, j];
                        matrix[i, j] = valueAtIndex2;
                        SetBySingleIndex(matrix, index2, temp);

                    }
                }
            }

            // Output matrix after inversion

            ShowAttentionMsg("Matrix after inversion: ");
            ShowMatrix(matrix);
        }


        //Sort matrix in ascending order

        static void SortAscendingMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int index1 = i * matrix.GetLength(1) + j;


                    for (int index2 = index1 + 1; index2 < matrix.Length; index2++)
                    {
                        var valueAtIndex2 = GetBySingleIndex(matrix, index2);

                        if (matrix[i, j] > valueAtIndex2)
                        {
                            double temp = matrix[i, j];
                            matrix[i, j] = valueAtIndex2;
                            SetBySingleIndex(matrix, index2, temp);
                        }
                    }
                }
            }

            // Output matrix after ascending order sorting

            ShowAttentionMsg("Matrix after sorting ascending order:");
            ShowMatrix(matrix);
        }

        // Sort matrix in descending order

        static void SortDescendingMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int index1 = i * matrix.GetLength(1) + j;


                    for (int index2 = index1 + 1; index2 < matrix.Length; index2++)
                    {
                        var valueAtIndex2 = GetBySingleIndex(matrix, index2);

                        if (matrix[i, j] < valueAtIndex2)
                        {
                            double temp = matrix[i, j];
                            matrix[i, j] = valueAtIndex2;
                            SetBySingleIndex(matrix, index2, temp);
                        }
                    }
                }
            }

            ShowAttentionMsg("Matrix after sorting descending order:");
            ShowMatrix(matrix);
        }
        // The value of the variable by index in a two-dimensional array

        public static double GetBySingleIndex(double[,] matrix, int index)
        {
            var i = index / matrix.GetLength(1);
            var j = index - i * matrix.GetLength(1);

            return matrix[i, j];
        }

        //Pass the value of the array by index to the variable

        public static void SetBySingleIndex(double[,] matrix, int index, double value)
        {
            var i = index / matrix.GetLength(1);
            var j = index - i * matrix.GetLength(1);

            matrix[i, j] = value;
        }

        static void EnterMatrix()
        {
            try
            {
                ShowAttentionMsg("Enter please number of matrix columns: ");
                while (!ulong.TryParse(Console.ReadLine(), out cols))
                {
                    ShowErrorMsg("Enter please correct number of matrix columns: ");
                }

                ShowAttentionMsg("Enter please number of matrix rows: ");
                while (!ulong.TryParse(Console.ReadLine(), out rows))
                {
                    ShowErrorMsg("Enter please correct number of matrix rows: ");
                }

                matrix = new double[rows, cols];
                ShowAttentionMsg("Enter fill int the matrix: ");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = i * j;

                        // Сhecking if matrix elements are entered correctly

                        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out matrix[i, j]))
                        {
                            ShowErrorMsg("Enter please correct numbers of matrix: ");
                        }
                    }
                }

                // Matrix output

                ShowMatrix(matrix);
            }
            catch
            {
                ShowErrorMsg("Think before entering the dimension!");

                EnterMatrix();
            }
        }

        static void ShowCommands()
        {
            ShowAttentionMsg(
                $"1) {Options.Add} - Add a matrix.",
                $"2) {Options.SortDescending} - Sort matrix in descending order.",
                $"3) {Options.SortAscending} - Sort matrix in ascending order.",
                $"4) {Options.Inversion} - Matrix inversion.",
                $"5) {Options.SearchPositive} - Finding the maximum positive number.",
                $"6) {Options.SearchNegative} - Finding the maximum negative number.",
                $"7) {Options.NumberOfNegative} - The number of negative numbers in the matrix.",
                $"8) {Options.NumberOfPositive} - The number of posotive numbers in the matrix.",
                $"9) {Options.Clear} - Clear console content.",
                $"10) {Options.Exit} - Exit the application.");
        }

        static void ShowAttentionMsg(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ShowErrorMsg(params string[] msgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var msg in msgs)
            {
                Console.WriteLine($"Error: {msg}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ShowMatrix(double[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

