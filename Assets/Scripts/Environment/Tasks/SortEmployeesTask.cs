using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = ("Sort Employees Task"), menuName =("Sort Employees Task"))]

    public class SortEmployeesTask : Task
    {
        public override void Execute()
        {
            Employee[] employees = EmployeesHandler.instance.employeeUser;

            MergeSort(employees, 0, employees.Length - 1);
        }

        public static void MergeSort(Employee[] array, int left, int right)
        {
            if(left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, left, middle, right);
            }
        }

        public static void Merge(Employee[] array, int left, int middle, int right)
        {
            Employee[] leftArray = new Employee[middle - left + 1];
            Employee[] rightArray = new Employee[right - middle];

            for(int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[left + i];
            }

            for(int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = array[middle + 1 + i];
            }

            int l = 0, r = 0, k = left;

            while(l < leftArray.Length && r < rightArray.Length)
            {
                if(leftArray[l].lastEntranceInEngineRoom >= rightArray[r].lastEntranceInEngineRoom)
                {
                    array[k++] = leftArray[l++];
                }
                else
                {
                    array[k++] = rightArray[r++];
                }
            }

            while(l < leftArray.Length)
            {
                array[k++] = leftArray[l++];
            }


            while(r < rightArray.Length)
            {
                array[k++] = rightArray[r++];
            }
        }
    }
}


