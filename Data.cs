using System;


namespace Lab3PP
{
    public class Data
    {
        private int N { get; }

        public Data(int n)
        {
            this.N = n;
        }

        public int[] InputVectorManually()
        {
            int[] vector = new int[N];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }

            return vector;
        }

        public int[] GetVectorUsingRandom(int upperBound)
        {
            int[] vector = new int[N];
            Random random = new Random();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = random.Next(upperBound);
            }

            return vector;
        }


        public int[] GetVectorFilledWithValue(int value)
        {
            int[] vector = new int[N];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = value;
            }

            return vector;
        }

        public int[,] InputMatrixManually()
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                }
            }

            return matrix;
        }

        public int[,] GetMatrixUsingRandom()
        {
            int[,] matrix = new int[N, N];
            Random random = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i, j] = random.Next(60);
                }
            }

            return matrix;
        }

        public int[,] GetMatrixFilledWithValue(int value)
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = value;
                }
            }
            return matrix;
        }


        private int[,] MultiplyMatrices(int[,] firstMatrix, int[,] secondMatrix)
        {
            //For matrix multiplication, the number of columns in the first matrix must be equal to the number of rows in the second matrix.
            int[,] result = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            return result;
        }

        //For multiplication, the number of columns in the first matrix must be equal to the number of rows in the second matrix
        private int[] VectorMultiplyByMatrix(int[] vector, int[,] matrix)
        {
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i] += vector[j] * matrix[i, j];
                }
            }

            return result;
        }

        private int[] AddVectors(int[] firstVector, int[] secondVector)
        {
            //For addition, length of vectors must be equals
            if (firstVector.Length != N || secondVector.Length != N)
            {
                return null;
            }

            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                result[i] = firstVector[i] + secondVector[i];
            }

            return result;
        }

        private int[,] TransposeMatrix(int[,] matrix)
        {

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
                }
            }

            return matrix;
        }
        static int scalar(int[] v1, int[] v2)
        {
            var s = 0;
            for (int i = 0; i < v1.Length; i++)
                s += v1[i] * v2[i];
            return s;
        }

        

    




    private int[,] MatrixSum(int[,] ma, int[,] mb)
        {
            if (ma.Length != this.N || mb.Length != this.N) return null;

            int[,] mc = new int[this.N,0];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.N; j++)
                {
                    mc[i,j] = ma[i,j] + mb[i,j];
                }
            }

            return mc;
        }



        //1.16 d = ((A + B)* (C*(MA* ME)))
        //2.27 MF = (MG*MH)*TRANS(MK)
        //3.24 s = MIN(MO*MP+MS)
        public int F1(int[] a, int[] b, int[] c, int[,] ma, int[,] me)
        {
            return scalar(AddVectors(a, b), VectorMultiplyByMatrix(c, MultiplyMatrices(ma, me)));
        }

        public int[,] F2(int[,] mk, int[,] mh, int[,] mg)
        {
            return MultiplyMatrices(TransposeMatrix(mk), MultiplyMatrices(mh, mg));
        }

        public int F3(int[,] mo, int[,] mp, int[,] ms)
        {
            int l = 0;
            int z = 0;
            int[,] ML1 = MatrixSum(ms, MultiplyMatrices(mo, mp));
            int big = ML1[l,z];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (big < ML1[i, j])
                    {
                        big = ML1[i, j];
                    }
                }
            }

         
            return big;
        }


    }
}
