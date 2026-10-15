using Environment.Tasks;
using NUnit.Framework;
using UnityEngine;
using Utils;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeReference] public GenericQueue<Task> tasks = new GenericQueue<Task>();
        [SerializeReference] public GenericQueue<Task> lightTask = new GenericQueue<Task>();
        [SerializeReference] public List<GenericQueue<Task>> activeList = new List<GenericQueue<Task>>();

        [SerializeField] LightOnTask lights;
        [SerializeField] bool isActive = false;

        private void Awake()
        {
            activeList.Add(tasks);
            activeList.Add(lightTask);
        }

        public void OnInteract()
        {
            if(activeList.Count > 0 && !isActive)
            {
                isActive = true;
                lightTask.Enqueue(lights);
            }

            else if (activeList.Count == 0 && isActive)
            {
                isActive = false;
                lightTask.Enqueue(lights);
                lightTask.Peek().Execute();
                lightTask.Dequeue();

                Overload();
            }

            foreach(GenericQueue<Task> taskList in activeList)
            {
                if(taskList.queueOfTasks.Count == 0)
                {
                    continue;
                }

                taskList.Peek().Execute();
                taskList.Dequeue();
            }

            activeList.RemoveAll(taskList => taskList.queueOfTasks.Count == 0);
        }

        public void Overload()
        {
            Debug.Log("No more tasks to run. Computer overload! You destroyed the computer");
        }

        public void OnAttack()
        {
            Debug.Log("You destroyed the computer");
        }
    }
}
