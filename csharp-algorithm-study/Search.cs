using System;
using System.Collections.Generic;

namespace csharp_algorithm_study
{
    public class Search
    {

        bool[] c = new bool[8]; // check
        List<int>[] a = new List<int>[8];

        public Search()
        {
            // 리스트 초기 
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = new List<int>();
            }
            // 1과 2를 연결
            a[1].Add(2);
            a[2].Add(1);
            // 1과 3을 연결
            a[1].Add(3);
            a[3].Add(1);
            // 2와 3을 연결
            a[2].Add(3);
            a[3].Add(2);
            // 2와 4를 연결
            a[2].Add(4);
            a[4].Add(2);
            // 2와 5를 연결
            a[2].Add(5);
            a[5].Add(2);
            // 3과 6을 연결
            a[3].Add(6);
            a[6].Add(3);
            // 3과 7을 연결
            a[3].Add(7);
            a[7].Add(3);
            // 4과 5를 연결
            a[4].Add(5);
            a[5].Add(4);
            // 6과 7을 연결
            a[6].Add(7);
            a[7].Add(6);

            //BFS(1);
            DFS(1);
        }

        // 너비 우선 탐색
        public void BFS(int start)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            c[start] = true;
            while (q.Count != 0)
            {
                int x = q.Peek();
                q.Dequeue();
                Console.Write(x + " ");
                for (int i = 0; i < a[x].Count; i++)
                {
                    int y = a[x][i];
                    if (!c[y])  // 방문하지 않은 노드를 방문하고
                    {
                        q.Enqueue(y); // 큐에 삽입
                        c[y] = true; // 방문 처리  
                    }
                }
            }
        }

        // 깊이 우선 탐색
        public void DFS(int x)
        {
            if (c[x]) return;
            c[x] = true;
            Console.Write(x + " ");
            for (int i = 0; i < a[x].Count; i++)
            {
                int y = a[x][i];
                DFS(y);
            }
        }
    }
}
