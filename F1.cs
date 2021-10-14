using System;
using System.Threading;
//1.16 d = ((A + B)* (C*(MA* ME)))
namespace Lab3PP
{
    public class F1
    {
        private Data data;

        public F1(Data data)
        {
            this.data = data;

        }
        public void Run()
        {
            Console.WriteLine("F1 started");

            int[] A = data.GetVectorFilledWithValue(1);
            int[] B = data.GetVectorFilledWithValue(1);
            int[,] MA = data.GetMatrixFilledWithValue(1);
            int[,] ME = data.GetMatrixFilledWithValue(1);
            int[] C = data.GetVectorFilledWithValue(1);

            int result = data.F1(A,B,C,MA,ME);

            Thread.Sleep(1000);

            Console.WriteLine($"Result of F1: " + "{0}", string.Join(", ", result));
            Console.WriteLine("F1 has finished\n");
        }
    }
}
