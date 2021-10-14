using System;
using System.Threading;

namespace Lab3PP
{
    public class F3
    {
        private Data data;

        public F3(Data data)
        {
            this.data = data;
        }

        public void Run()
        {

            Console.WriteLine("F3 started");

    
            int[,] MO = data.GetMatrixFilledWithValue(1);
            int[,] MP = data.GetMatrixFilledWithValue(1);
            int[,] MS = data.GetMatrixFilledWithValue(1);
            
            
            int result = data.F3(MO,MP,MS);
            Thread.Sleep(1000);

            Console.WriteLine($"Result of F3: " + "{0}", string.Join(", ", result));
            Console.WriteLine("F3 has finished\n");

        }
    }
}
