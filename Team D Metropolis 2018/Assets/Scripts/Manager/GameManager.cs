using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public string playerName;
    public TextMeshProUGUI inputName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void AssignName()
    {
        playerName = inputName.text;
        if (playerName == "")
            playerName = "Level UP";
    }
}
