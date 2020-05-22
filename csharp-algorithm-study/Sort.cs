using System;

namespace csharp_algorithm_study
{
    public class Sort
    {
        // 선택, 버블, 삽입, 퀵 정렬
        static int[] quickArr = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };

        // 병합 정렬
        static int number = 8;
        static int[] sorted = new int[8]; // 정렬 배열은 반드시 전역 변수로 선언
        static int[] mergeArr = { 7, 6, 5, 8, 3, 5, 9, 1 };

        // 힙 정렬
        static int[] heapArr = { 7, 6, 5, 8, 3, 5, 9, 1, 6 };

        static void Main(string[] args)
        {
            //SelectionSort();
            //BubbleSort();
            //InsertionSort();
            //QuickSort(0, number - 1);

            //Sort1(); // 기초 정렬문제 1
            //Sort2(); // 기초 정렬문제 2

            //MergeSort(mergeArr, 0, number - 1);
            //Show(mergeArr);

            //HeapSort();
            //Show(heapArr);

            //CountingSort();

            //new StackQueue().Queue();

            new Search();

        }
       
        static void Show(int[] array)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        // 크기를 기준으로 갯수만 세주면 됨
        static void CountingSort()
        {
            int[] count = new int[6]; // +1
            int[] array = {1, 3, 2, 4, 3, 2, 5, 3, 1, 2,
                           3, 4, 4, 3, 5, 1, 2, 3, 5, 2,
                           3, 1, 4, 3, 5, 1, 2, 1, 1, 1};

            for (int i = 1; i <= 5; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }
            for (int i = 1; i <= 5; i++)
            {
                if (count[i] != 0)
                {
                    for (int j = 0; j < count[i]; j++)
                    {
                        Console.Write(i + " ");
                    }
                }
                
            }


        }


        // 하나의 노드를 제외하고 최대 힙이 구성되어 있다고 가정했을 때,
        // 그 하나의 노드에 대해서 힙 생성 알고리즘(Heapify Algorithm)을 사용해서 힙구조를 만들어줌        // n 힙구조 전체갯수에서 1/2번만큼만 히피파이 수행
        // 상향식, 하향식 아무거나
        // 이제 정렬 시작
        // 제일 위 노드와 가장 아래 노드를 바꿔주고 이제 가장아래 노드가 젤큰값이니까
        // 그거 제외하고 나머지 노드들에 대해서 다시 힙구조를 만들어줌(히피파이 수행) 반복
        static void HeapSort()
        {
            int number = 9;

            // 처음 힙 구성
            for (int i = 0; i < number; i++)
            {
                int child = i;
                do
                {
                    int root = (child - 1) / 2; // root 구하는 방식
                    if (heapArr[root] < heapArr[child])
                    {
                        int temp = heapArr[root];
                        heapArr[root] = heapArr[child];
                        heapArr[child] = temp;
                    }
                    child = root;
                } while (child != 0);
            }

            // 크기를 줄여가며 반복적으로 힙을 구성
            for (int i = number - 1; i >= 0; i--) // 상향식
            {
                int temp = heapArr[0]; // 젤 큰값인 맨 위 노드를 제일 아래 노드와 바꿈
                heapArr[0] = heapArr[i];
                heapArr[i] = temp;
                int root = 0;
                int child = 1;
                do
                {
                    child = 2 * root + 1;
                    // 자식 중에 더 큰 값을 찾기
                    if (child < i - 1 && heapArr[child] < heapArr[child + 1])
                    {
                        child++; // 오른쪽이 더크다 하면 차일드를 오른쪽으로 옮김
                    }
                    // 루트보다 자식이 크다면 교환
                    if (child < i && heapArr[root] < heapArr[child])
                    {
                        temp = heapArr[root];
                        heapArr[root] = heapArr[child];
                        heapArr[child] = temp;
                    }
                    root = child;
                } while (child < i);
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
                while (i <= end && quickArr[i] <= quickArr[key]) // 키 값보다 큰 값을 만날 때까지
                {
                    i++;
                }
                while (j > start && quickArr[j] >= quickArr[key]) // 키 값보다 작은 값을 만날 때까지
                {
                    j--;
                }

                if (i > j) // 현재 엇갈린 상태면 키 값과 교체
                {
                    temp = quickArr[j];
                    quickArr[j] = quickArr[key];
                    quickArr[key] = temp;
                }
                else // 엇갈리지 않았다면 i와 j를 교체
                {
                    temp = quickArr[i];
                    quickArr[i] = quickArr[j];
                    quickArr[j] = temp;
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
                while (j >= 0 && quickArr[j] > quickArr[j + 1]) // 여기서 왼쪽 정렬된 것들 걸러냄
                {
                    temp = quickArr[j];
                    quickArr[j] = quickArr[j + 1];
                    quickArr[j + 1] = temp;    // 크면 바꾸고
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
                    if (quickArr[j] > quickArr[j + 1])
                    {
                        temp = quickArr[j];
                        quickArr[j] = quickArr[j + 1];
                        quickArr[j + 1] = temp;
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
                    if (min > quickArr[j])
                    {
                        min = quickArr[j];
                        index = j;
                    }
                }
                temp = quickArr[i];
                quickArr[i] = quickArr[index];
                quickArr[index] = temp;
            }
        }

    }
}
