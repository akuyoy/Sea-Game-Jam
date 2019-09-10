using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulationManager : MonoBehaviour {

    public int population;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerLevelText;
    public List<int> populationRequired;

    public int playerLevel = 1;

    public static PopulationManager instance;

    void Awake()
    {
        instance = this;
        UpdateHUD();
    }

    void Start()
    {
        playerNameText.text = GameManager.instance.playerName;
    }

    // testing /////
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerLevel++;
            if (playerLevel > 20)
                playerLevel = 20;

            UpdateHUD();

            ObjManager.instance.townhallBuilding.sprite = ObjManager.instance.townHallSprite[playerLevel / 5];
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResourcesManager.instance.addCurrency(10000);
        }
    }
    ////////
    public void addPopulation(int _amount)
    {
        population += (_amount * 10);
        if (population > populationRequired[playerLevel - 1])
        {
            playerLevel++;

            if (playerLevel > 20)
                playerLevel = 20;

            ObjManager.instance.townhallBuilding.sprite = ObjManager.instance.townHallSprite[playerLevel / 5];
        }

        UpdateHUD();
    }
    public void UpdateHUD()
    { 
        popText.text = population + " / " + populationRequired[playerLevel - 1];
        playerLevelText.text = "Level " + playerLevel;
    }
}
