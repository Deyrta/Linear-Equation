using System;

namespace Lab2
{
    class Program
    {
        public static void Main(string[] args)
        {
            double[,] matrix = new double[4, 5] { { 8.3, 3.92, 3.77, 2.21, 9.55 }, { 2.82, 8.45, 7.41, 3.45, -12.21 }, { 4.1, 7.58, 8.04, 1.69, -14.45 }, { 1.9, 2.46, 2.28, 6.99, 8.35 } };
            matrix = LinearEquationSolver.Solve(matrix);
            Console.WriteLine($"x1={matrix[0, 4]}\nx2={matrix[1, 4]}\nx3={matrix[2, 4]}\nx4={matrix[3, 4]}");
            Console.ReadKey(true);
        }
    }


    public static class LinearEquationSolver
    {
        public static double[,] Solve(double[,] M)
        {
            int rowCount = M.GetUpperBound(0) + 1;

            for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
            {
                for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
                {
                    double df = M[sourceRow, sourceRow];
                    double sf = M[destRow, sourceRow];
                    for (int i = 0; i < rowCount + 1; i++)
                        M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
                }
            }

            for (int row = rowCount - 1; row >= 0; row--)
            {
                double f = M[row, row];

                for (int i = 0; i < rowCount + 1; i++)
                    M[row, i] /= f;
                for (int destRow = 0; destRow < row; destRow++)
                {
                    M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0;
                }
            }
            return M;
        }
    }
}
