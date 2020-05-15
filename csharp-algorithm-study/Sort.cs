using System;

namespace csharp_algorithm_study
{
    public class Sort
    {
        // 선택, 버블, 삽입, 퀵 정렬
        static int[] array = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };

        // 병합 정렬
        static int number = 8;
        static int[] sorted = new int[8]; // 정렬 배열은 반드시 전역 변수로 선언

        static void Main(string[] args)
        {
            //SelectionSort();
            //BubbleSort();
            //InsertionSort();
            //QuickSort(0, number - 1);
            //Show();

            //Sort1(); // 기초 정렬문제 1
            //Sort2(); // 기초 정렬문제 2

            int[] array = { 7, 6, 5, 8, 3, 5, 9, 1 };
            MergeSort(array, 0, number - 1);
            for (int i = 0; i < number; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
       
        static void Show()
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        // 너비 N, 높이 logN 으로 속도 NlogN 보장
        // 두 개의 정렬된 부분 배열을 이용해 새롭게 정렬된 배열을 만듬
        // 일단 정확히 반으로 나누고 나중에 정렬
        static void Merge(int[] a, int m, int middle, int n)
        {
            int i = m;
            int j = middle + 1;
            int k = m;

            // 작은 순서대로 배열에 삽입
            while(i <= middle && j <= n)
            {
                if(a[i] <= a[j])
                {
                    sorted[k] = a[i];
                    i++;
                }
                else
                {
                    sorted[k] = a[j];
                    j++;
                }
                k++;
            }

            // 남은 데이터도 삽입
            if (i > middle)
            {
                for (int t = j; t <= n; t++)
                {
                    sorted[k] = a[t];
                    k++;
                }
            }
            else
            {
                for (int t = i; t <= middle; t++)
                {
                    sorted[k] = a[t];
                    k++;
                }
            }

            // 정렬된 배열을 삽입
            for(int t = m; t <= n; t++)
            {
                a[t] = sorted[t];
            }

        }

        static void MergeSort(int[] a, int m, int n)
        {
            if(m < n)
            {
                int middle = (m + n) / 2;
                MergeSort(a, m, middle); // 왼쪽 정
                MergeSort(a, middle + 1, n); // 오른쪽 정렬
                Merge(a, m, middle, n); // 합친다
            }
        }


        // 일반적인 온라인 채점 시스템의 경우 대략 일초에 일억번정도 연산을 할 수 있다고 가정 하고 푼다.
        // 시간제한 1초 - 1000제곱은 백만 - 백만정도면 정말작은 숫자 큰문제 x - 세가지 정렬중 아무거나
        // https://www.acmicpc.net/problem/2750
        static void Sort1()
        {
            int[] array = new int[1001]; // +1 심신안정
            int number, i, j, min, index = 0, temp;
            number = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < number; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < number; i++)
            {
                min = 1001;
                for (j = i; j < number; j++)
                {
                    if(min > array[j])
                    {
                        min = array[j];
                        index = j;
                    }
                }

                temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }

            for (i = 0; i < number; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        // https://www.acmicpc.net/problem/2752
        static void Sort2()
        {
            int[] array = new int[3];
            int i, j, min, index = 0, temp;

            string[] input = Console.ReadLine().Split(' ');

            for (i = 0; i < 3; i++)
            {
                array[i] = Convert.ToInt32(input[i]);
            }
            for (i = 0; i < 3; i++)
            {
                min = 1000001;
                for (j = i; j < 3; j++)
                {
                    if (min > array[j])
                    {
                        min = array[j];
                        index = j;
                    }
                }

                temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }

            for (i = 0; i < 3; i++)
            {
                Console.Write(array[i] + " ");
            }
        }



        // 특정한 값을 기준으로 큰 숫자와 작은 숫자를 나눔
        static void QuickSort(int start, int end)
        {
            if (start >= end) // 원소가 1개인 경우 그대로 두기
            {
                return;
            }

            int key = start; // 키는 첫 번째 원소
            int i = start + 1, j = end, temp;

            while (i <= j) // 엇갈릴 때까지 반복
            {
                while (i <= end && array[i] <= array[key]) // 키 값보다 큰 값을 만날 때까지
                {
                    i++;
                }
                while (j > start && array[j] >= array[key]) // 키 값보다 작은 값을 만날 때까지
                {
                    j--;
                }

                if (i > j) // 현재 엇갈린 상태면 키 값과 교체
                {
                    temp = array[j];
                    array[j] = array[key];
                    array[key] = temp;
                }
                else // 엇갈리지 않았다면 i와 j를 교체
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            QuickSort(start, j - 1); // 재귀함수 활용
            QuickSort(j + 1, end);

        }

        // 앞의 정렬들 무조건 위치를 바꾸는 방식이었다면 삽입정렬은 필요할 때만 위치를 바꿈
        static void InsertionSort()
        {
            int i, j, temp;
            for (i = 0; i < 9; i++)
            {
                j = i; // 왼쪽은 정렬되었으니 안된 것 부터 오른쪽으로 체크
                while (j >= 0 && array[j] > array[j + 1]) // 여기서 왼쪽 정렬된 것들 걸러냄
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;    // 크면 바꾸고
                    j--;                    // 오른쪽으로 가면서 체크
                }
            }
        }

        // 옆에 있는 값과 비교해서 더 작은 값을 앞으로 보냄
        static void BubbleSort()
        {
            int i, j, temp;
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
        }

        // 가장 작은 값을 선택해서 앞으로 보냄
        static void SelectionSort()
        {
            int i, j, min, index = 0, temp;
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
        }

    }
}
