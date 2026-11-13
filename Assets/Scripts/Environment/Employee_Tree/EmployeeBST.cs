using Environment.Tasks;
using System;
using UnityEngine;
using System.Collections.Generic;


namespace Environment
{
    public class EmployeeNode
    {
        private Employee employee;
        public EmployeeNode leftChild = null;
        public EmployeeNode rightChild = null;

        public Employee GetData()
        {
            return employee;
        }

        public EmployeeNode(Employee inEmployeeData)
        {
            this.employee = inEmployeeData;
        }
    }
    [Serializable]
    public class EmployeeBST
    {
        private EmployeeNode root;
        private List<Employee> employeeList = new List<Employee>();

        public EmployeeBST(Employee rootEmployeeData)
        {
            root = new EmployeeNode(rootEmployeeData);
        }

        public void Insert(Employee inEmployeeData)
        {
            EmployeeNode newEmployeeNode = new EmployeeNode(inEmployeeData);
            EmployeeNode currentEmployeeNode = root;
            EmployeeNode lastParent = null;

            while(currentEmployeeNode != null)
            {
                if(inEmployeeData.lastEntranceInEngineRoom < currentEmployeeNode.GetData().lastEntranceInEngineRoom)
                {
                    lastParent = currentEmployeeNode;
                    currentEmployeeNode = currentEmployeeNode.leftChild;
                }
                else
                {
                    lastParent = currentEmployeeNode;
                    currentEmployeeNode = currentEmployeeNode.rightChild;
                }
            }

            if (inEmployeeData.lastEntranceInEngineRoom < lastParent.GetData().lastEntranceInEngineRoom)
            {
                lastParent.leftChild = newEmployeeNode;
            }
            else
            {
                lastParent.rightChild = newEmployeeNode;
            }
        }

        public void Search(DateTime startDate, DateTime endDate)
        {
            employeeList.Clear();

            SearchNode(root, startDate, endDate);
        }

        private void SearchNode(EmployeeNode currentNode, DateTime startDate, DateTime endDate)
        {
            if(currentNode == null)
            {
                return;
            }

            Employee employee = currentNode.GetData();
            DateTime employeeDate = employee.lastEntranceInEngineRoom;

            if(employeeDate >= startDate && employeeDate <= endDate)
            {
                employeeList.Add(employee);
            }

            if(employeeDate > startDate)
            {
                SearchNode(currentNode.leftChild, startDate, endDate);
            }

            if(employeeDate < endDate)
            {
                SearchNode(currentNode.rightChild, startDate, endDate);
            }
        }

        public List<Employee> GetResults()
        {
            return employeeList;
        }
    }
}

