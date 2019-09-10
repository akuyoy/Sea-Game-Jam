using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//public class SlotData
//{
//    BuildingType type;
//    int tier;
//}

public class ObjManager : MonoBehaviour {

    public List<GameObject> placementSlot;
    //public List<SlotData> slot;
    public List<GameObject> building;
    public int typeSelected = -1;
    public static ObjManager instance;
    //public bool buying = false;
    //public int workValue = 0;
    public int playerLevel = 1;
    public int houseAmount = 0;
    //public int farmAmount = 0;
    public CurrentMode _currentMode = CurrentMode.Default;
    public int slotSelected = -1;
    public GameObject confirmationPanel;
    public TextMeshProUGUI confirmationText;

    public Toggle upgradeMode;
    public Toggle deleteMode;

    public List<Sprite> townHallSprite;
    public SpriteRenderer townhallBuilding;

    public List<GameObject> panelSelection;
	void Awake () {
        instance = this;
        //slot = new List<SlotData>();
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(spawnAll());
        }
        
    }
    IEnumerator spawnAll()
    {
        int counter = 0;
        while (counter < 220)
        {
            foreach(var slot in placementSlot)
            {
                if (slot.transform.childCount != 0)
                    Destroy(slot);

                counter++;
                GameObject obj = Instantiate(building[Random.Range(0,3)], slot.transform);
                obj.GetComponent<SpriteRenderer>().sortingOrder = slot.GetComponent<SpriteRenderer>().sortingOrder;
                slot.GetComponent<SpriteRenderer>().enabled = false;
                obj.transform.localPosition = Vector3.zero;
                obj.GetComponent<BuildingWidget>().currentTier = Random.Range(0, 3);
                obj.GetComponent<BuildingWidget>().UpdateSprite();
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    public void closeAllPanel()
    {
        panelSelection[0].SetActive(false);
        panelSelection[1].SetActive(false);
        panelSelection[2].SetActive(false);
        panelSelection[3].SetActive(false);
    }

    public void SelectBuildingType(int _type)
    {
        //_currentMode = CurrentMode.Buy;
        typeSelected = _type;

        closeAllPanel();

        panelSelection[typeSelected].SetActive(true);


        //buying = true;
        //print("Select building " + _type);

        AudioController.instance.PlaySFXAudioClip(1);
    }

    public void PlaceBuilding()
    {

        AudioController.instance.PlaySFXAudioClip(5);
        //print("place building " + _slot +  "   "  + buying);

        //if (!buying)
        //return;


        if (typeSelected == 0)
        {
            houseAmount++;
            PopulationManager.instance.addPopulation(10);
        }

        GameObject obj = Instantiate(building[typeSelected], placementSlot[slotSelected].transform);
        obj.transform.localPosition = Vector3.zero;
        obj.GetComponent<SpriteRenderer>().sortingOrder = placementSlot[slotSelected].GetComponent<SpriteRenderer>().sortingOrder;
        placementSlot[slotSelected].GetComponent<SpriteRenderer>().enabled = false;
        obj.GetComponent<BuildingWidget>().currentTier = 0;
    }

    public void ConfirmButtonPanel()
    {


        if (_currentMode == CurrentMode.Default)
        {
            AudioController.instance.PlaySFXAudioClip(1);
        }
        else if (_currentMode == CurrentMode.Buy)
        {
            int cost = 1000;

            if (ObjManager.instance.typeSelected == 0)
            {
                cost = 1000 + (ObjManager.instance.houseAmount * 100);
            }
            if (ResourcesManager.instance.currency >= cost)
            {
                ResourcesManager.instance.minusCurrency(cost);
                PlaceBuilding();
            }
        }
        else if (_currentMode == CurrentMode.Upgrade)
        {
            if (ResourcesManager.instance.currency >= 2000)
            {
                placementSlot[slotSelected].transform.GetChild(0).GetComponent<BuildingWidget>().UpgradeBuilding();
                ResourcesManager.instance.minusCurrency(2000);

                AudioController.instance.PlaySFXAudioClip(8);
            }
        }
        else if (_currentMode == CurrentMode.Delete)
        {
            placementSlot[slotSelected].GetComponent<SpriteRenderer>().enabled = true;
            placementSlot[slotSelected].transform.GetChild(0).GetComponent<BuildingWidget>().DeleteBuilding();

            AudioController.instance.PlaySFXAudioClip(7);

        }

        confirmationPanel.SetActive(false);
    }
    
    public void CheckToggle()
    {
        if (_currentMode == CurrentMode.Buy)
            UIAnimationController.instance.BtnBuilding();

        if (upgradeMode.isOn)
            _currentMode = CurrentMode.Upgrade;
        else if (deleteMode.isOn)
            _currentMode = CurrentMode.Delete;
        else
            _currentMode = CurrentMode.Default;
    }
}
