using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour {

    public GameObject UI_PnlLeft;
    public static UIAnimationController instance;

    private void Awake()
    {
        instance = this;
    }

    public void BtnBuilding()
    {
        Animator animator = UI_PnlLeft.GetComponent<Animator>();
        if(animator.GetBool("isIdle"))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isSlideUp", false);
            animator.SetBool("isSlide", true);
            ObjManager.instance._currentMode = CurrentMode.Buy;
            
            AudioController.instance.PlaySFXAudioClip(1);
        }
        else if(animator.GetBool("isSlide"))
        {
            animator.SetBool("isSlideUp", true);
            animator.SetBool("isIdle", true);
            animator.SetBool("isSlide", false);
            ObjManager.instance._currentMode = CurrentMode.Default;
            ObjManager.instance.typeSelected = -1;
            ObjManager.instance.closeAllPanel();

            AudioController.instance.PlaySFXAudioClip(2);
        }

        ObjManager.instance.upgradeMode.isOn = false;
        ObjManager.instance.deleteMode.isOn = false;
    }

    public void BtnNoConfirmationAudio()
    {
        AudioController.instance.PlaySFXAudioClip(1);
    }
}
