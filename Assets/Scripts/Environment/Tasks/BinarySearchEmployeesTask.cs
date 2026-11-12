using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Binary Search Task", menuName = "Binary Search Task")]

    public class BinarySearchTask : Task
    {
        public override void Execute()
        {
            Employee[] employees =
                EmployeesHandler.instance.employeeUser;

            DateTime startDate = new DateTime(2234, 8, 4);
            DateTime endDate = new DateTime(2234, 8, 7, 23, 59, 59);

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            int low = Search(employees, endDate, true);
            int high = Search(employees, startDate, false);

            int count = high - low;

            Employee[] results = new Employee[count];

            for(int i = 0; i < count; i++)
            {
                results[i] = employees[low + i];
            }

            stopwatch.Stop();

            Debug.Log("Binary Search time: " + stopwatch.ElapsedTicks + " ticks");
            Debug.Log("Employees found: " + count);

            //foreach(Employee employee in results)
            //{
            //    Debug.Log(employee.name + " " + employee.lastEntranceInEngineRoom);
            //}
        }

        public static int Search(Employee[] array, DateTime date, bool findStart)
        {
            int low = 0;
            int high = array.Length;

            while(low < high)
            {
                int middle = low + (high - low) / 2;

                if(findStart)
                {
                    if(array[middle].lastEntranceInEngineRoom > date)
                    {
                        low = middle + 1;
                    }

                    else
                    {
                        high = middle;
                    }

                }
                else
                {
                    if(array[middle].lastEntranceInEngineRoom >= date)
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        high = middle;
                    }
                }
            }
            return low;
        }
    }
}
