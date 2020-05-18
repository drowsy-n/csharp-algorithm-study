using System;
using System.Collections.Generic;

namespace csharp_algorithm_study
{
    public class StackQueue
    {
        public StackQueue()
        {
            


        }


        // 출입구가 한쪽밖에 없음, 마지막에 들어간 원소가 삭제됨
        public void Stack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Pop();
            stack.Push(6);
            stack.Pop();
            while(stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");

            }
        }
    }
}
