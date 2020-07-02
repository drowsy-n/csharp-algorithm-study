using System;
namespace csharp_algorithm_study
{
    public class DynamicProgramming
    {
        int[] memo = new int[100];

        public int Fibonacci(int x)
        {
            if (x == 1) return 1;
            if (x == 2) return 1;
            if (memo[x] != 0) return memo[x];
            return memo[x] = Fibonacci(x - 1) + Fibonacci(x - 2);
        }

        public DynamicProgramming()
        {
            Console.WriteLine(Fibonacci(33));

        }
    }
}
