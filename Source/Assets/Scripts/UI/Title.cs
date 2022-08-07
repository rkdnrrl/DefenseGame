using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Title : MonoBehaviour
{
    GameNetworkManager networkManager;
    public Text ipText;

    public Button createButton;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        //networkManager 
        networkManager = GameNetworkManager.singleton;


        createButton.onClick.AddListener(delegate
        {
            CreateGame();
        });

        startButton.onClick.AddListener(delegate
        {
            StartClient();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //NetworkManager.startho
    }

    public void CreateGame()
    {
        networkManager.StartHost();

    }

    public void StartClient()
    {
        networkManager.networkAddress = ipText.text;//GUILayout.TextField(manager.networkAddress);
        networkManager.StartClient();
    }
}
