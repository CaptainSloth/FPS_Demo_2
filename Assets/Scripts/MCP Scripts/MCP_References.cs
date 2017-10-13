using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP_References : MonoBehaviour {

    public string playerTag;
    public static string _playerTag;

    public string enemyTag;
    public static string _enemyTag;

    public static GameObject _player;

    private void OnEnable()
    {
        if(playerTag == "")
        {
            Debug.LogWarning("HEY DINGUS THE PLAYERTAG ISN'T SETUP IN THE MCP_REFS YO... DUMMY.");
        }

        if (enemyTag == "")
        {
            Debug.LogWarning("HEY DINGUS THE PLAYERTAG ISN'T SETUP IN THE MCP_REFS YO... DUMMY.");
        }

        _playerTag = playerTag;
        _enemyTag = enemyTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    private void OnDisable()
    {

    }

    private void Update()
    {

    }
}
