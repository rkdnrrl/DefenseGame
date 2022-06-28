using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public UIManager uiManager;
    public EnvironmentManager environmentManager;
    public SpawnManager spawnManager;
    public ControllerManager controllerManager;

    private void Awake()
    {
        if (instance != null)
            instance = null;

        instance = this;
    }
}
