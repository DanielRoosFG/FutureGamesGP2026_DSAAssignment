using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task
    {
        [SerializeField] string textToPrint;

        public override void Execute()
        {
            Debug.Log(textToPrint);
        }
    }
}
