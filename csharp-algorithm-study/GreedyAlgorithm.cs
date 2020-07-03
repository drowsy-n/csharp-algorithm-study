using System;
namespace csharp_algorithm_study
{
    public class GreedyAlgorithm
    {
        public GreedyAlgorithm()
        {
            ChangeProblem();
        }

        // 거스름돈 문제 (잔돈에는 500, 100, 50, 10, 5, 1엔이 있음) 
        public void ChangeProblem()
        {
            int result = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            n = 1000 - n;
            result += n / 500;
            n = n % 500;
            result += n / 100;
            n = n % 100;
            result += n / 50;
            n = n % 50;
            result += n / 10;
            n = n % 10;
            result += n / 5;
            n = n % 5;
            result += n;

            Console.WriteLine(result);

        }
    }
}
