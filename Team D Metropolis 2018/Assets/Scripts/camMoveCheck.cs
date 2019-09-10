using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveCheck : MonoBehaviour {

	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Top")
        {
            TouchInputManager.instance.top = true;
        }
        else if (other.tag == "Left")
        {
            TouchInputManager.instance.left = true;
        }
        else if (other.tag == "Right")
        {
            TouchInputManager.instance.right = true;
        }
        else if (other.tag == "Bottom")
        {
            TouchInputManager.instance.bottom = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Top")
        {
            TouchInputManager.instance.top = false;
        }
        else if (other.tag == "Left")
        {
            TouchInputManager.instance.left = false;
        }
        else if (other.tag == "Right")
        {
            TouchInputManager.instance.right = false;
        }
        else if (other.tag == "Bottom")
        {
            TouchInputManager.instance.bottom = false;
        }
    }
}
