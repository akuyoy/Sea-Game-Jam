using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimatorWithDelay : MonoBehaviour {

    public bool isStartFalling;

    public float defaultY;
    public float speed;

    public float fallingDelay;

    public Sprite sprite;
    private void Awake()
    {
        fallingDelay = Random.Range(0.1f, 1f);
        defaultY = gameObject.transform.position.y;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9.3f, gameObject.transform.position.z);

    }
    private void Start()
    {
        Invoke("StartFalling",fallingDelay);
    }

    public void StartFalling()
    {
        isStartFalling = true;
        if(gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

    }

    // Update is called once per frame
    void Update () {
        if(isStartFalling)
        {
            if(gameObject.transform.position.y <= defaultY)
            {
                isStartFalling = false;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, defaultY, gameObject.transform.position.z);
                Invoke("ChangeSprite", 1f);
            }
            else
            {
                gameObject.transform.position -= new Vector3(0f, speed * Time.deltaTime,0f);
            }

        }
	}

    void ChangeSprite()
    {
        if(gameObject.GetComponent<SpriteRenderer>().sprite == sprite)
        {

        }else
        {
            AudioController.instance.PlaySFXAudioClip(3);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            Invoke("HideChild", 0.5f);
        }

    }

    void HideChild()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
