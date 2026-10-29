using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment.Tasks
{
    [Serializable]
    public class EmployeeJson
    {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
    }

    [Serializable]
    public class Employee
    {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public DateTime lastEntranceInEngineRoom;
        public DateTime lastExitFromEngineRoom;

        public string lastEntranceDisplay;
        public string lastExitDisplay;
    }

    [Serializable]
    public class EmployeeArray
    {
        public EmployeeJson[] employees;
    }

    [CreateAssetMenu(fileName = "Check Employees Task", menuName = "Check Employees Task")]
    public class CheckEmployeeTask : Task
    {
        [SerializeField] TextAsset jsonFile;

        public override void Execute()
        {
            EmployeeJson[] jsonEmployees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text).employees;

            Employee[] employees = new Employee[jsonEmployees.Length];

            for(int i = 0; i < jsonEmployees.Length; i++)
            {
                EmployeeJson jsonEmployee = jsonEmployees[i];
                DateTime entrance = DateTime.Parse(jsonEmployee.lastEntranceInEngineRoom);

                DateTime exit = DateTime.Parse(jsonEmployee.lastExitFromEngineRoom);

                employees[i] = new Employee
                {
                    name = jsonEmployee.name,
                    employeeId = jsonEmployee.employeeId,
                    hasEngineRoomClearance = jsonEmployee.hasEngineRoomClearance,

                    lastEntranceInEngineRoom = entrance,
                    lastExitFromEngineRoom = exit,

                    lastEntranceDisplay = entrance.ToString("yyyy-MM-dd HH:mm:ss"),

                    lastExitDisplay = exit.ToString("yyyy-MM-dd HH:mm:ss")
                };
            }

            EmployeesHandler.instance.employeeUser = employees;
        }
    }
}

