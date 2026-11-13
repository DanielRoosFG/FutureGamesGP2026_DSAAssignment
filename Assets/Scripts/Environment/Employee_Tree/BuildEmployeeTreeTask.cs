using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Build Employee Tree Task", menuName = "Build Employee Tree Task")]
    public class BuildEmployeeTreeTask : Task
    {
        public override void Execute()
        {
            Employee[] employees = EmployeesHandler.instance.employeeUser;

            EmployeesHandler.instance.employeeBST = new EmployeeBST(employees[0]);

            int count = 1;

            for(int i = 1; i < employees.Length; i++)
            {
                EmployeesHandler.instance.employeeBST.Insert(employees[i]);
                count++;
            }

            Debug.Log("Employee BST created with " + count + " employees!");
        }
    }
}
