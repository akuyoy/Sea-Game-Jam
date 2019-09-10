using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BuildingWidget : MonoBehaviour {

    public BuildingType buildingType;

    public int resourceAvailable = 0;
    int resourceLimit = 3;
    public int currentTier = -1;

    public List<Sprite> buildingSprite;
    public List<Sprite> farmHarvestSprite;
    float timer = 0;
    float[] farmMult = { 1.5f, 2, 3 };
    public GameObject VFX;

    public GameObject coin;

    void Update()
    {
        if (buildingType == BuildingType.Farm)
        {
            if (resourceAvailable < resourceLimit)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    resourceAvailable++;
                    //GetComponent<Animator>().SetBool("Ready", true);
                    timer = 0;
                }
            }
            if (resourceAvailable > 0)
                GetComponent<SpriteRenderer>().sprite = farmHarvestSprite[currentTier];
        }
    }

    public void CollectResources()
    {
        if(buildingType == BuildingType.Farm)
        {
            if (resourceAvailable == 0)
                return;

            AudioController.instance.PlaySFXAudioClip(6);

            int amount = (int)(resourceAvailable * PopulationManager.instance.population * farmMult[currentTier]);
            //ResourcesManager.instance.addedText.GetComponent<TextMeshProUGUI>().text = "+" + amount;
            //ResourcesManager.instance.addedText.SetActive(true);
            //ResourcesManager.instance.timer = 2f;
            addTextPoolingManager.instance.TurnOnObj(amount);
            ResourcesManager.instance.addCurrency(amount);

            GetComponent<Animator>().SetBool("Ready", false);
            resourceAvailable = 0;
            Instantiate(coin, transform);
            UpdateSprite();
        }
    }

    public void UpgradeBuilding()
    {
        // need to check gold to upgrade
        if (currentTier == 2)
            return;

        VFX.SetActive(true);
        currentTier++;
        UpdateSprite();
        if (buildingType == BuildingType.House)
        {
            PopulationManager.instance.addPopulation(10);
        }
    }

    public void DeleteBuilding()
    {
        Destroy(gameObject);
    }

    public void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = buildingSprite[currentTier];
    }
}
