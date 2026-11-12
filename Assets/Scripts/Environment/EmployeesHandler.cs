using Environment.Tasks;
using System;
using UnityEngine;

namespace Environment
{
    public class EmployeesHandler : MonoBehaviour
    {
        public Employee[] employeeUser;
        public EmployeeBST employeeBST;
        public static EmployeesHandler instance;

        private void Awake()
        {
            instance = this;
        }

    }
}


