using System;

namespace OperatorsApp
{
    public class Matrix
    {
        private double[,] data;
        public int Rows { get; }
        public int Cols { get; }

        public double this[int i, int j]
        {
            get => data[i, j];
            set => data[i, j] = value;
        }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            data = new double[rows, cols];
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці мають бути однакового розміру!");

            Matrix result = new Matrix(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Cols; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці мають бути однакового розміру!");

            Matrix result = new Matrix(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Cols; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Cols != m2.Rows)
                throw new ArgumentException("Неможливо перемножити: кількість стовпців першої != кількості рядків другої!");

            Matrix result = new Matrix(m1.Rows, m2.Cols);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m2.Cols; j++)
                    for (int k = 0; k < m1.Cols; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
            return result;
        }

        public static Matrix operator *(Matrix m, double scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Cols);
            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                    result[i, j] = m[i, j] * scalar;
            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                return false;

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Cols; j++)
                    if (m1[i, j] != m2[i, j])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix m1, Matrix m2) => !(m1 == m2);

        public override bool Equals(object obj)
        {
            if (obj is Matrix m) return this == m;
            return false;
        }

        public override int GetHashCode() => data.GetHashCode();

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write($"{data[i, j],6}");
                Console.WriteLine();
            }
        }
    }
}
