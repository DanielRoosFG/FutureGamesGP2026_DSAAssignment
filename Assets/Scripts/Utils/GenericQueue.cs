using System;
using System.Collections.Generic;

namespace Utils
{
    [Serializable]
    public class GenericQueue<T>
    {
        public List<T> queueOfTasks = new List<T>();

        public void Enqueue(T tasks)
        {
            queueOfTasks.Add(tasks);
        }

        public T Peek()
        {
            if(queueOfTasks.Count == 0)
            {
                throw new Exception("queue is empty, cannot peek");
            }

            return queueOfTasks[0];
        }

        public T Dequeue()
        {
            if(queueOfTasks.Count == 0)
            {
                throw new Exception("queue is empty, cannot peek");
            }

            T topOfQueue = queueOfTasks[0];
            queueOfTasks.RemoveAt(0);

            return topOfQueue;
        }

        public void Clear()
        {
            queueOfTasks.Clear();
        }
    }
}
