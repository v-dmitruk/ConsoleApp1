using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleApp1
{
    public class MatrixEventArgs
    {
        public string Message { get; }
    }

    public class Matrix : ICloneable, IComparable
    {
        public delegate void MatrixStateHandler(object sender, MatrixEventArgs e);

        public int[,] matrix { get; private set; }
        public int m { get; private set; }
        public int n { get; private set; }

        static void SaveMatrixCollectionToTxtFile(Matrix A, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, A);
                Console.WriteLine("Matrix Serialized");
            }
        }
        static void LoadMatrixCollectionFromTxtFile(Matrix A, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                A = (Matrix)formatter.Deserialize(fs);
                Console.WriteLine("Matrix Deserialized");
            }
        }
        
        public Matrix()
        {
//            this = null;
        }
        public Matrix(int[,] matrix)
        {
            if (matrix == null || !(matrix is int[,]))
            {
                throw new ArgumentException("You can't crate matrix from this object");
            }
            else
            {
                this.matrix = (int[,])matrix.Clone();
                this.m = matrix.GetLength(0);
                this.n = matrix.GetLength(1);
            }
        }
        public Matrix(int m, int n)
        {
            if (m == 0 || n == 0)
            {
                throw new ArgumentException("You can't create a zerodimensional matrix");
            }
            else
            {
                this.m = m;
                this.n = n;
                this.matrix = new int[m, n];
            }
        }

        //Indexer
        public int this[int n, int m]
        {
            get
            {
                return this.matrix[n, m];
            }
            set
            {
                this.matrix[n, m] = value;
            }

        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.m != B.m || A.n != B.n)
            {
                throw new ArgumentException($"Matrixes dimensions are {A.m}x{A.n} and {B.m}x{B.n}");
            }
            else
            {
                Matrix result = new Matrix(A.n, A.m);
                for (int m = 0; m < A.m; m++)
                {
                    for (int n = 0; n < A.n; n++)
                    {
                        result.matrix[m, n] = A.matrix[m, n] + B.matrix[m, n];
                    }
                }
                return result;
            }
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.m != B.m || A.n != B.n)
            {
                throw new ArgumentException($"Matrixes dimensions are {A.m}x{A.n} and {B.m}x{B.n}");
            }
            else
            {
                Matrix result = new Matrix(A.n,A.m);
                for (int m = 0; m < A.m; m++)
                {
                    for (int n = 0; n < A.n; n++)
                    {
                        result.matrix[m,n] = A.matrix[m, n] - B.matrix[m, n];
                    }
                }
                return result;
            }
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.n != B.m)
            {
                throw new ArgumentException ($"Matrixes dimensions are {A.m}x{A.n} and {B.m}x{B.n}");
            }
            else
            {
                Matrix result = new Matrix();
                result.m = A.m;
                result.n = B.n;
                result.matrix = new int[result.m, result.n];

                for (int m = 0; m < A.m; m++)
                {
                    for (int n = 0; n < B.n; n++)
                    {
                        int a = 0;
                        for (int i = 0; i < A.n; i++)
                            a += A.matrix[m, i] * B.matrix[i, n];
                        result.matrix[m, n] = a;
                    }
                }
                result.View();
                return result;
            }
        }
        public static Matrix operator *(int A, Matrix B)
        {
            Matrix result = (Matrix)B.Clone();
            for (int m = 0; m < B.m; m++)
                {
                    for (int n = 0; n < B.n; n++)
                    {
                        result.matrix[m, n] = B.matrix[m,n] * A;
                    }
                }
            return result;
        }

        public object Clone()
        {
            if (this != null)
            {
                int[,] matrix1 = new int[this.m, this.n];
                for (int row = 0; row < this.m; row++)
                {
                    for (int col = 0; col < this.n; col++)
                    {
                        matrix1[row, col] = this.matrix[row, col];
                    }
                }
                return new Matrix(matrix1);
            }
            else
            {
                throw new ArgumentException("You can't clone an empty matrix");
            }

        }
        public int CompareTo(object A)
        {
            Matrix A1 = (Matrix)A;
            if (this.Determinant() == A1.Determinant())
            {
                return 0;
            }
            else
            {
                if (this.Determinant() > A1.Determinant())
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public string Dimension()
        {
            return $"{this.m}x{this.n}";
        }
        public void View()
        {
            if (this != null)
                for (int m1 = 0; m1 < this.m; m1++)
                {
                    for (int n1 = 0; n1 < this.n; n1++)
                    {
                        Console.Write(this.matrix[m1, n1] + " | ");
                    }
                    Console.WriteLine();
                }
            else
            {
                throw new ArgumentException("Bad matrix");
            }
            Console.WriteLine("====");
        }
        public void Ramdomize(int a, int b)
        {
            Random rnd = new Random();
            for (int m1 = 0; m1 < this.m; m1++)
            {
                for (int n1 = 0; n1 < this.n; n1++)
                {
                    this.matrix[m1, n1] = (int)rnd.Next(a, b);
                }
            }
        }

        private int Minor(Matrix A, int det)
        {
            if (A.m == A.n && A.m > 1)
            {
                if (A.m == 2)
                {
                    //Console.WriteLine($"Lesser determinant is {A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0]}");
                    return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0]; 
                }
                else
                {
                    Matrix result = new Matrix(n-1,n-1);
                    int resultDeterminant = det;
                    for (int j = 0; j < n; j++)
                    {
                        int[,] lesser = new int[n-1,n-1];
                        for (int i1 = 1, j1 = 0; i1 < n; i1++)
                        {
                            for (int k = 0, u = 0; k < n; k++)
                            {
                                if (k == j)
                                    continue;

                                lesser[j1, u] = A.matrix[i1, k];
                                u++;
                            }
                            j1++;
                        }
                        result = new Matrix(lesser);
                        int minordet = A[0, j] * (result.Minor(result, 0));
                        if (j % 2 == 0)
                        { 
                            resultDeterminant = resultDeterminant + minordet;
                            //result.View();
                            //Console.WriteLine($"Determninant for Minor {j + 1}, {n}x{n} is multiplied *+{A[0, j]}={resultDeterminant}");
                        }
                        else
                        {
                            resultDeterminant = resultDeterminant - minordet;
                            //result.View();
                            //Console.WriteLine($"Determninant for Minor {j + 1}, {n}x{n} is multiplied *-{A[0, j]}={resultDeterminant}");
                        }
                    }
                    return resultDeterminant;
                }
            }
            else
            {
                throw new ArgumentException($"Matrix dimension is {this.m}x{this.n} and it is not acceptable");
            }
        }
        public int Determinant()
        {
            return Minor(this, 0);
        }

        //Deconstructor
        public void Deconstruct(out int[,] dmatrix, out int m, out int n)
        {
            dmatrix = this.matrix;
            m = this.m;
            n = this.n;
        }
    }
}
