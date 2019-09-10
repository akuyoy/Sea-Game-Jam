using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateUp : MonoBehaviour {

    float timer = 0.5f;
    public Vector3 defaultPos;

    void Update () {
        transform.localPosition += Vector3.up * Time.deltaTime * 15f;
        GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 0, timer + 0.5f);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
            timer = 0.5f;
        }
	}
    void OnEnable()
    {
        transform.localPosition = defaultPos;
    }
}
