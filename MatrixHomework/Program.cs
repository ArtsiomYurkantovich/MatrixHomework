using System;
using System.Globalization;


namespace MatrixHomework
{
    class Program
    {
        private static ulong cols ;
        private static ulong rows;
        private static double[,] matrix;

        private const string Clear = "clear";
        private const string Exit = "exit";
        private const string Info = "info";
        private const string Add = "add";
        private const string SortDescending = "desc";
        private const string SortAscending = "ascen";
        private const string Inversion = "invers";
        private const string SearchPositive = "pos";
        private const string SearchNegative = "neg";
        private const string NumberOfNegative = "numneg";
        private const string NumberOfPositive = "numpos";
        private static bool RequestedExit;


        // Method that prints out the commands list
        static void ShowCommands()
        {
            Console.WriteLine("**** List of commands: ****");
            Console.WriteLine($"{Clear} - Clear console content.");
            Console.WriteLine($"{Exit} - Exit the application.");
            Console.WriteLine($"{Info} - Show list of commands.");
            Console.WriteLine($"{Add} - Add a matrix.");
            Console.WriteLine($"{SortDescending} - Sort matrix in descending order.");
            Console.WriteLine($"{SortAscending} - Sort matrix in ascending order.");
            Console.WriteLine($"{Inversion} - Matrix inversion.");
            Console.WriteLine($"{SearchPositive} - Finding the maximum positive number.");
            Console.WriteLine($"{SearchNegative} - Finding the maximum negative number.");
            Console.WriteLine($"{NumberOfNegative} - The number of negative numbers in the matrix.");
            Console.WriteLine($"{ NumberOfPositive} - The number of posotive numbers in the matrix.");
        }
        static void ClearDisplay()
        {
            Console.Clear();
            ShowCommands();
        }
        static void EnterMatrix()
        {
            try
            {
                Console.Write("Enter please number of matrix columns: ");
                while (!ulong.TryParse(Console.ReadLine(), out cols))
                {
                    Console.Write("Enter please correct number of matrix columns: ");
                }

                Console.Write("Enter please number of matrix rows: ");
                while (!ulong.TryParse(Console.ReadLine(), out rows))
                {
                    Console.Write("Enter please correct number of matrix rows: ");
                }

                matrix = new double[rows, cols];
                Console.WriteLine("Enter fill int the matrix: ");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = i * j;

                        // Сhecking if matrix elements are entered correctly

                        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out matrix[i, j]))
                        {
                            Console.WriteLine("Enter please correct numbers of matrix: ");
                        }
                    }
                }

                // Matrix output

                Console.WriteLine();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j]}\t");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Think before entering the dimension!");

                EnterMatrix();
            }
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
           
            Console.WriteLine("Matrix after sorting descending order:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine(); ;
            }
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
          
            Console.WriteLine("Matrix after sorting ascending order:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine(); ;
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

            Console.WriteLine("Matrix after inversion: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
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
                Console.WriteLine();
                Console.WriteLine($"Maximum positive number in the matrix= {maxPositive}");
            }
           
            else
            {
                Console.WriteLine("There aren't posotive numbers in the matrix.");
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
                    if (matrix[i, j] < maxNegative )
                    {
                        maxNegative = matrix[i, j];
                    }
                }
            }
           
            if (maxNegative < 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Minimum negative number in the matrix = {maxNegative}");
            }
            
            else
            {
                Console.WriteLine("There aren't negative numbers in the matrix.");
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
                Console.WriteLine();
                Console.WriteLine($"The number of positive numbers in the matrix = {negativeNumber}");
            }
           
            else
            {
                Console.WriteLine("There aren't posotive numbers in the matrix.");
            }
        }

        //The number of posotive numbers in the matrix

        static void NumberOfPositiveNumbers()
        {
            double positiveNumber = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   
                    if (matrix[i,j] > 0)
                    {
                        positiveNumber++;
                    }
                }
            }
           
            if (positiveNumber > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"The number of positive numbers in the matrix = {positiveNumber}");
            }
           
            else
            {
                Console.WriteLine("There aren't posotive numbers in the matrix.");
            }
        }

        // Methode implements basic commands

        static void ApplyCommand()
        {
            Console.WriteLine();
            Console.Write("> ");
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case Info:
                    ShowCommands();
                    break;
               
                case Add:
                    EnterMatrix();
                    break;
                case Exit:
                    RequestedExit = true;
                    break;
                case SortDescending:
                    SortDescendingMatrix();
                    break;
                case SortAscending:
                    SortAscendingMatrix();
                    break;
                case Inversion:
                    InversionMatrix();
                    break;
                case SearchPositive:
                    SearchPositiveNumber();
                    break;
                case SearchNegative:
                    SearchNegativeNumber();
                    break;
                case NumberOfNegative:
                    NumberOfNegativeNumbers();
                    break;
                case NumberOfPositive:
                    NumberOfPositiveNumbers();
                    break;
                case Clear:
                    ClearDisplay();
                    break;
                default:
                    Console.WriteLine("Error! Please enter command at list information");
                    Console.WriteLine();
                    ShowCommands();
                    break;
            }
        }
        
        static void RunApplication()
        {
            ShowCommands();
            Console.WriteLine();

            EnterMatrix();
            Console.WriteLine();
            Console.WriteLine("SELECT ONE OF THE COMMANDS!!!");

            // While RequestExit = false perform method ApplyCommand

            while (!RequestedExit)
            {
                ApplyCommand();
            }
        }
        static void Main(string[] args)
        {
            RunApplication();
        }
    }
}

