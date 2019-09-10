using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlotDetect : MonoBehaviour {

    public int slot = -1;

    public void OnMouseUp()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        //AudioController.instance.PlaySFXAudioClip(1);

        ObjManager.instance.confirmationPanel.transform.GetChild(0).GetComponent<Button>().interactable = true;

        if (ObjManager.instance.confirmationPanel.activeSelf)
            return;

        ObjManager.instance.slotSelected = slot;

        if (ObjManager.instance._currentMode == CurrentMode.Default)
        {
            if (ObjManager.instance.placementSlot[slot].transform.childCount == 1)
            {
                if (ObjManager.instance.placementSlot[slot].transform.GetChild(0).GetComponent<BuildingWidget>().buildingType == BuildingType.Farm)
                {
                    ObjManager.instance.placementSlot[slot].transform.GetChild(0).GetComponent<BuildingWidget>().CollectResources();
                }
            }
        }
        else if (ObjManager.instance._currentMode == CurrentMode.Buy)
        {
            if (ObjManager.instance.typeSelected == -1 || gameObject.transform.childCount > 0)
                return;

            ObjManager.instance.confirmationPanel.SetActive(true);
            //if (gameObject.transform.childCount == 0)
            //ObjManager.instance.PlaceBuilding();
            int cost = 1000;
            if (ObjManager.instance.typeSelected == 0)
            {
                cost = 1000 + (ObjManager.instance.houseAmount * 100);
            }
            ObjManager.instance.confirmationText.text = cost + " Coins";
            if (ResourcesManager.instance.currency < cost)
            {
                ObjManager.instance.confirmationPanel.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
            else
            {
                ObjManager.instance.confirmationPanel.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
        else if (ObjManager.instance._currentMode == CurrentMode.Upgrade)
        {
            if (gameObject.transform.childCount == 0)
                return;

            if (ObjManager.instance.placementSlot[slot].transform.GetChild(0).GetComponent<BuildingWidget>().currentTier == 2)
                return;

            ObjManager.instance.confirmationPanel.SetActive(true);
            ObjManager.instance.confirmationText.text = "Upgrade cost :\n2000 Coins";
            if (ResourcesManager.instance.currency < 2000)
            {
                ObjManager.instance.confirmationPanel.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
            else
            {
                ObjManager.instance.confirmationPanel.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
        else if (ObjManager.instance._currentMode == CurrentMode.Delete)
        {
            ObjManager.instance.confirmationPanel.SetActive(true);
            ObjManager.instance.confirmationText.text = "Are you sure you want to DESTROY this building?";
        }
    }
}
