using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Tree Search Task", menuName = "Tree Search Task")]
    public class TreeSearchTask : Task
    {
        public override void Execute()
        {
            EmployeeBST tree = EmployeesHandler.instance.employeeBST;

            DateTime startDate = new DateTime(2234, 8, 4);
            DateTime endDate = new DateTime(2234, 8, 7, 23, 59, 59);

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            tree.Search(startDate, endDate);

            List<Employee> results = tree.GetResults();

            stopwatch.Stop();

            Debug.Log("BST Search time: " + stopwatch.ElapsedTicks + " ticks");
            Debug.Log("Employees found: " + results.Count);
        }
    }
}
