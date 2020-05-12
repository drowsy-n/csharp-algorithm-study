﻿using System;

namespace csharp_algorithm_study
{
    public class Sort
    {
        static void Main(string[] args)
        {
            SelectionSort();
        }

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
    }
}