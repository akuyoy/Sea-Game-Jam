using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDisable : MonoBehaviour {

    public float duration;

    private void OnEnable()
    {
        Invoke("DisableThisOject", duration);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void DisableThisOject()
    {
        gameObject.SetActive(false);
    }
}
