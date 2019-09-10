using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class addTextPoolingManager : MonoBehaviour {

    public List<GameObject> addText;

    int counter = 0;
    public static addTextPoolingManager instance;
    void Awake()
    {
        instance = this;
    }
    
    public void TurnOnObj(int amount)
    {
        if (!addText[counter].activeSelf)
        {
            addText[counter].GetComponent<TextMeshProUGUI>().text = "+" + amount;
            addText[counter].SetActive(true);
            counter++;
            if (counter == 5) counter = 0;

        }
    }
}
