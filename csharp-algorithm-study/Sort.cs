using System;

namespace csharp_algorithm_study
{
    public class Sort
    {
        static void Main(string[] args)
        {
            //SelectionSort();
            BubbleSort();
        }

        // 가장 작은 값을 선택해서 앞으로 보냄
        static void SelectionSort()
        {
            int i, j, min, index = 0, temp;
            int[] array = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
            for (i = 0; i < 10; i++)
            {
                min = 9999;
                for (j = i; j < 10; j++)
                {
                    if (min > array[j])
                    {
                        min = array[j];
                        index = j;
                    }
                }
                temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }

            for (i = 0; i < 10; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        // 옆에 있는 값과 비교해서 더 작은 값을 앞으로 보냄
        static void BubbleSort()
        {
            int i, j, temp;
            int[] array = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            for (i = 0; i < 10; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
