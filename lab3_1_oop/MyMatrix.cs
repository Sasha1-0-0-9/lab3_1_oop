using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_1_oop
{
    class MyMatrix
    {
        private double[,] matrix;

        public MyMatrix(MyMatrix matrix_)
        {
            matrix = (double[,])matrix_.matrix.Clone();
        }

        public MyMatrix(double[,] arr)
        {
            matrix = (double[,])arr.Clone();
        }

        public MyMatrix(double[][] arr)
        {
            bool isRectangular = true;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Length != arr[0].Length)
                {
                    isRectangular = false;
                }
            }

            if (isRectangular)
            {
                matrix = new double[arr.Length, arr[0].Length];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = arr[i][j];
                    }
                }
            }
        }

        public MyMatrix(string[] arr)
        {
            char[] separator = { '\t', ' ' };
            string[] tmp = arr[0].Trim().Split(separator);
            int rowCount = arr.GetLength(0);
            int columnCount = tmp.Length;
            matrix = new double[rowCount, columnCount];
            for (int i = 0; i < Height; i++)
            {
                tmp = arr[i].Trim().Split(separator);
                if (columnCount == tmp.Length)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        matrix[i, j] = Int32.Parse(tmp[j]);
                    }
                }
            }
        }

        public MyMatrix(string matrixInString) : this(matrixInString.Trim().Split('\n'))
        { }

        public static MyMatrix operator +(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            MyMatrix sumOfMatrix;
            if (matrix_1.Height == matrix_2.Height && matrix_1.Width == matrix_2.Width)
            {
                sumOfMatrix = new MyMatrix(matrix_1);
                for (int i = 0; i < sumOfMatrix.Height; i++)
                {
                    for (int j = 0; j < sumOfMatrix.Width; j++)
                    {
                        sumOfMatrix.matrix[i, j] += matrix_2.matrix[i, j];
                    }
                }
            }
            else
            {
                throw new ArgumentException("These matrix are not same size!!!");
            }
            return sumOfMatrix;
        }

        public static MyMatrix operator *(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            MyMatrix mulMatrix;
            if (matrix_1.Width == matrix_2.Height)
            {
                mulMatrix = new MyMatrix(new double[matrix_1.Height, matrix_2.Width]);
                for (int i = 0; i < matrix_1.Height; i++)
                {
                    for (int j = 0; j < matrix_2.Width; j++)
                    {
                        for (int k = 0; k < matrix_2.Height; k++)
                        {
                            mulMatrix.matrix[i, j] += matrix_1.matrix[i, k] * matrix_2.matrix[k, j];
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Column count first matrix isn't equal to row count second matrix.");
            }
            return mulMatrix;
        }

        public int Height
        {
            get
            {
                return matrix.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        public int GetWidth()
        {
            return matrix.GetLength(1);
        }

        public int GetHeight()
        {
            return matrix.GetLength(0);
        }

        public double this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                if (i < Height && j < Width && i >= 0 && j >= 0)
                {
                    matrix[i, j] = value;
                }
            }
        }

        public double GetElement(int i, int j)
        {
            return matrix[i, j];
        }

        public void SetElement(int i, int j, double val)
        {
            if (i < Height && j < Width && i >= 0 && j >= 0)
            {
                matrix[i, j] = val;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    str.Append(matrix[i, j] + "\t");
                }
                if (i != matrix.GetLength(0) - 1)
                {
                    str.Append("\n");
                }
            }
            return str.ToString();
        }

        private double[,] GetTransponedArray()
        {
            double[,] transponedMatrix = new double[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    transponedMatrix[j, i] = matrix[i, j];
                }
            }
            return transponedMatrix;
        }

        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }

        public void TransponedMe()
        {
            matrix = GetTransponedArray();
        }
    }
}
