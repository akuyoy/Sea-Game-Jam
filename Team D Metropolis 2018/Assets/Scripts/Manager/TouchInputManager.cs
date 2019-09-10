using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour {

    float orthoZoomSpeed = 0.01f;        // The rate of change of the orthographic size in orthographic mode.
    public bool top = false;
    public bool left = false;
    public bool right = false;
    public bool bottom = false;

    public static TouchInputManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);
            Vector2 changes = touchZero.deltaPosition;
            if (top)
            {
                if (changes.y < 0)
                {
                    changes.y = 0;
                }
            }
            if (right)
            {
                if (changes.x < 0)
                {
                    changes.x = 0;
                }
            }
            if (left)
            {
                if (changes.x > 0)
                {
                    changes.x = 0;
                }
            }
            if (bottom)
            {
                if (changes.y > 0)
                {
                    changes.y = 0;
                }
            }
            transform.Translate(changes * orthoZoomSpeed * -(GetComponent<Camera>().transform.localPosition.z + 8) * 0.15f);
        }
        else if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            float zPos = Mathf.Clamp(GetComponent<Camera>().transform.localPosition.z - (deltaMagnitudeDiff * orthoZoomSpeed),-8f,-2f);

            if (deltaMagnitudeDiff > 0)
            {
                float x = GetComponent<Camera>().transform.localPosition.x;
                x /= 1.05f;

                float y = GetComponent<Camera>().transform.localPosition.y;
                y /= 1.05f;

                GetComponent<Camera>().transform.localPosition = new Vector3(x, -0.5f, zPos);
            }
            else
            {
                GetComponent<Camera>().transform.localPosition = new Vector3(GetComponent<Camera>().transform.localPosition.x, GetComponent<Camera>().transform.localPosition.y, zPos);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (top)
                return;
            transform.Translate(Vector3.up * 0.1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (bottom)
                return;
            transform.Translate(Vector3.up * -0.1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (left)
                return;
            transform.Translate(Vector3.left * 0.1f);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (right)
                return;
            transform.Translate(Vector3.left * -0.1f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (GetComponent<Camera>().transform.localPosition.z < -2)
                GetComponent<Camera>().transform.localPosition += Vector3.forward * Time.deltaTime * 3;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            float x = GetComponent<Camera>().transform.localPosition.x;
            x /= 1.05f;

            float y = GetComponent<Camera>().transform.localPosition.y;
            y /= 1.05f;

            if (GetComponent<Camera>().transform.localPosition.z > -8)
                GetComponent<Camera>().transform.localPosition = new Vector3(x,y, GetComponent<Camera>().transform.localPosition.z - (Time.deltaTime * 3));
        }
    }

    public void ResetCamera()
    {
        transform.localPosition = new Vector3(0,-0.5f,-8f);

        AudioController.instance.PlaySFXAudioClip(1);
    }
}
