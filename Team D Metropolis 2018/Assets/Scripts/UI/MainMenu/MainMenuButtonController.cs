using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtonController : MonoBehaviour {

    public GameObject UI_PnlSetting;
    public GameObject UI_PnlCredit;
    public GameObject UI_PnlInputName;

    public GameObject UI_PnlHowToPlay;
    public List<Sprite> howToPlaysprite = new List<Sprite>();
    public int howToPlayCurrentIndex=0;
    public Image UI_ImgHowToPlay;
    public void BtnStartGame()
    {
        if(UI_PnlInputName.activeSelf == false)
        {
            UI_PnlInputName.gameObject.SetActive(true);
        }
    }
    public void BtnOkInputName()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void BtnOption()
    {
        UI_PnlSetting.SetActive(true);
    }
    public void BtnOkSetting()
    {
        //Save Setting

        UI_PnlSetting.SetActive(false);
    }
    public void BtnCancelSetting()
    {
        if(UI_PnlSetting.activeSelf == true)
        {
            UI_PnlSetting.SetActive(false);
        }
    }

    public void BtnCredit()
    {
        UI_PnlCredit.SetActive(true);
    }
    public void BtnOkCredit()
    {
        if(UI_PnlCredit.activeSelf == true)
        {
            UI_PnlCredit.SetActive(false);
        }
    }

    public void BtnHowToPlay()
    {
        //Reset
        howToPlayCurrentIndex = 0;
        UI_ImgHowToPlay.sprite = howToPlaysprite[howToPlayCurrentIndex];

        if (UI_PnlHowToPlay.gameObject.activeSelf == false)
        {
            UI_PnlHowToPlay.SetActive(true);
        }
    }
    public void BtnCloseHowToPlay()
    {
        if(UI_PnlHowToPlay.activeSelf == true)
        {
            UI_PnlHowToPlay.SetActive(false);
        }
    }

    public void BtnNextHowToPlay()
    {
        if(howToPlayCurrentIndex<(howToPlaysprite.Count-1))
        {
            howToPlayCurrentIndex++;
            UI_ImgHowToPlay.sprite = howToPlaysprite[howToPlayCurrentIndex];

        }else
        {
            UI_PnlHowToPlay.SetActive(false);
            howToPlayCurrentIndex = 0;
        }
    }

    public void BtnPreviousHowToPlay()
    {
        if (howToPlayCurrentIndex > 0)
        {
            howToPlayCurrentIndex--;
            UI_ImgHowToPlay.sprite = howToPlaysprite[howToPlayCurrentIndex];

        }
        else
        {
            //Do Nothing
        }
    }
}
