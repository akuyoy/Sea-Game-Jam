using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour {

    public static ResourcesManager instance;

    [HideInInspector]
    public int currency = 10000;
    //public int resources = 0;

    public TextMeshProUGUI currencyText;
    //public TextMeshProUGUI resourcesText

    public GameObject addedText;
    public float timer = 2f;

    int counter = 0;

    void Awake()
    {
        instance = this;
        UpdateHUD();
    }
    void Update()
    {
        if (addedText.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                addedText.SetActive(false);
                timer = 2f;
            }
        }
    }
    public void addCurrency(int _amount)
    {
        currency += _amount;
        UpdateHUD();
        counter += _amount;
        if (counter >= 500)
        {
            counter = 0;
            PopulationManager.instance.addPopulation(1);
        }
    }

    public void minusCurrency(int _amount)
    {
        currency -= _amount;
        UpdateHUD();
    }

    //public void addResources(int _amount)
    //{
    //    resources += _amount;
    //    UpdateHUD();
    //}

    //public void minusResources(int _amount)
    //{
    //    resources -= _amount;
    //    UpdateHUD();
    //}

    public void UpdateHUD()
    {
        currencyText.text = "" + currency;
        //resourcesText.text = "" + resourcesText;
    }

}
