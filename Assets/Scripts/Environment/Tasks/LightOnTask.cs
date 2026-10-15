using System.Threading.Tasks;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "LightOn", menuName = "LightOnTask")]
    public class LightOnTask : Task
    {
        [SerializeField] public bool lightIsOn;

        public override void Execute()
        {
            lightIsOn = !lightIsOn;
        }
    }
}

