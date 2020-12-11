using System;

namespace lab3_1_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m =  ");
            int m = int.Parse(Console.ReadLine());
            double[,] arrayMatrix = FillingMatrix(n, m);
            double[,] arrayMatrix2 = FillingMatrix(n, m);
            MyMatrix m1 = new MyMatrix(arrayMatrix);
            MyMatrix m2 = new MyMatrix(arrayMatrix2);    
            string[] stringArray = {"1 2 3 4",
                                    "5 3 15 0",
                                    "9 1 5 -1"};

            //// створення примірника класу MyMatrix за допомогою двовимірного масиву масива
            MyMatrix matrixFrom2DArray = new MyMatrix(arrayMatrix);
            Console.WriteLine("Матриця з двовимiрного масиву:\n");
            Console.WriteLine(matrixFrom2DArray);

            //// створення примірника класу MyMatrix за допомогою уже створеного примірника цього ж класу
            MyMatrix matrixFromMyMatrix = new MyMatrix(matrixFrom2DArray);
            Console.WriteLine("\nМатриця з примiрника класу MyMatrix:\n");
            Console.WriteLine(matrixFromMyMatrix);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// створення нового примірника класу MyMatrix за допомогою масиву рядків
            MyMatrix matrixFromStringArray = new MyMatrix(stringArray);
            Console.WriteLine("\nМатриця з масиву рядкiв:\n");
            Console.WriteLine(matrixFromStringArray);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();


            //// створення нового примірника з рядка
            MyMatrix matrixFromString = new MyMatrix(matrixFrom2DArray.ToString());
            Console.WriteLine("\nМатриця з рядка (який утворений з двовимiрного масиву):\n");
            Console.WriteLine(matrixFromString);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// створення нового примірника класу MyMatrix за допомогою зубчатого масива
            double[][] juggedArray = FillingJuggedArray(m, n);
            MyMatrix matrixFromJuggedArray = new MyMatrix(juggedArray);
            Console.WriteLine("\nМатриця з зубчатого масиву (заповненого випадковими числами):\n");
            Console.WriteLine(matrixFromJuggedArray);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// сума матриць
            Console.WriteLine("\nСума матриць:\n");
            Console.WriteLine("Перша матриця: \n" + matrixFrom2DArray + "\n");
            Console.WriteLine("Друга матриця: \n" + matrixFromMyMatrix + "\n");
            MyMatrix sumMatrix = matrixFrom2DArray + matrixFromMyMatrix;
            Console.WriteLine("\nРезультат:\n" + sumMatrix);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// множення матриць
            Console.WriteLine("\nМноження матриць:\n");
            Console.WriteLine("Перша матриця: \n" + matrixFrom2DArray + "\n");
            Console.WriteLine("Друга матриця: \n" + matrixFromJuggedArray + "\n");
            MyMatrix mulMatrix = matrixFrom2DArray * matrixFromJuggedArray;
            Console.WriteLine("\nРезультат:\n" + mulMatrix);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// індексатори
            Console.WriteLine("\nIндексатор:\n");
            Console.WriteLine("\nМатриця до змiн:\n");
            Console.WriteLine(matrixFrom2DArray);
            matrixFrom2DArray[0, 0] = 777;
            Console.WriteLine("Змiнено arr[0, 0] = " + matrixFrom2DArray[0, 0]);
            Console.WriteLine("\nМатриця пiсля змiн:\n");
            Console.WriteLine(matrixFrom2DArray);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// доступ і зміна елемента за допомогою методів Java-style
            Console.WriteLine("\nJava-style доступ i замiна елемента:\n");
            Console.WriteLine("\nМатриця до змiн:\n");
            Console.WriteLine(matrixFrom2DArray);
            matrixFrom2DArray.SetElement(0, 0, 666);
            Console.WriteLine("Змiнено arr[0, 0] = " + matrixFrom2DArray.GetElement(0, 0));
            Console.WriteLine("\nМатриця пiсля змiн:\n");
            Console.WriteLine(matrixFrom2DArray);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// транспонування матриці зі створенням копії
            Console.WriteLine("\nМатриця до транспонування:\n");
            Console.WriteLine(matrixFromStringArray);
            MyMatrix transponeMatrix = matrixFromStringArray.GetTransponedCopy();
            Console.WriteLine("\nНова транспонована матриця:\n");
            Console.WriteLine(transponeMatrix);
            Console.WriteLine("\nМатриця пiсля транспонування:\n");
            Console.WriteLine(matrixFromStringArray);
            Console.Write("\nPress any key to continue ...\n");
            Console.ReadKey();

            //// транспонування матриці для якої викликається метод
            Console.WriteLine("\nМатриця до транспонування:\n");
            Console.WriteLine(matrixFromMyMatrix);
            matrixFromMyMatrix.TransponedMe();
            Console.WriteLine("\nМатриця пiсля транспонування:\n");
            Console.WriteLine(matrixFromMyMatrix);
            Console.Write("\nPress any key to continue ...\n");

            Console.ReadKey();
        }

        static double[,] FillingMatrix(int n, int m)
        {
            double[,] matrix = new double[n, m];
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(0, 15);
                }
            }
            return matrix;
        }

        static double[][] FillingJuggedArray(int n, int m)
        {
            double[][] arr = new double[n][];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new double[m];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rand.Next(0, 15);
                }
            }
            return arr;
        }
    }
}
