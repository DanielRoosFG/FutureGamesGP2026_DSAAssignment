using Environment.Tasks;
using System;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] LightOnTask lightTask;
    [SerializeField] GameObject lights;

    private void Start()
    {
        lightTask.lightIsOn = false;
    }

    void Update()
    {
        lights.SetActive(lightTask.lightIsOn);
    }
}
