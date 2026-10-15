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
        [SerializeReference] public GenericQueue<Task> tasks = new GenericQueue<Task>(); // Put your stack/queue here :)
        [SerializeReference] public GenericQueue<Task> secondaryTasks = new GenericQueue<Task>();

        [SerializeReference] public List<GenericQueue<Task>> activeList = new List<GenericQueue<Task>>();

        private void Awake()
        {
            activeList.Add(tasks);
            activeList.Add(secondaryTasks);
        }

        public void OnInteract()
        {
            // if list in lists are 0, remove list
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

            if (activeList.Count == 0)
            {
                OnAttack();
            }
        }

        public void OnAttack()
        {
            Debug.Log("You destroyed the computer");
        }
    }
}
