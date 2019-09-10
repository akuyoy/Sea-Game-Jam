using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    public AudioSource BGMAudioSource;
    public AudioSource SFXAudioSource;
    public AudioSource AmbientAudioSource;
    public AudioSource Ambient1AudioSource;

    public List<AudioClip> SFXAudioClips = new List<AudioClip>();
    public List<AudioClip> BGMAudioClips = new List<AudioClip>();
    public List<AudioClip> AmbientClips = new List<AudioClip>();

    public static AudioController instance = null;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
        {            //if not, set it to this.
            instance = this;
            PlayBGM(0);
        }

        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        SceneManager.activeSceneChanged += SceneManager_ActiveSceneChanged;
    }

    void SceneManager_ActiveSceneChanged(Scene arg0, Scene arg1)     {         if (arg1.buildIndex == 0)         {             if(BGMAudioSource.isPlaying)
            {
                PlayBGM(0);
            }
         }         else if (arg1.buildIndex == 1)         {             if(BGMAudioSource.isPlaying == true)
            {

                PlayAmbient(0);
                PlayAmbient1(1);
            }         }      }
    public void PlaySFXAudioClip(int audioClipID)
    {
        if(SFXAudioSource.enabled)
        {
            SFXAudioSource.clip = SFXAudioClips[audioClipID];
            SFXAudioSource.Play();
        }
    }
    public void PlayBGM(int audioClipID)
    {
        if(BGMAudioSource.enabled)
        {
            BGMAudioSource.clip = BGMAudioClips[audioClipID];
            BGMAudioSource.Play();
        }
    }

    public void DisableBGM()
    {
        BGMAudioSource.Pause();
        //BGMAudioSource.enabled = false;
    }

    public void DisableSFX()
    {
        SFXAudioSource.Stop();
        SFXAudioSource.enabled = false;
    }

    public void EnableBGM()
    {
        //BGMAudioSource.enabled = true;
        BGMAudioSource.UnPause();
    }

    public void EnableSFX()
    {
        SFXAudioSource.enabled = true;
        //SFXAudioSource.Play();
    }

    public void PlayAmbient(int audioClipID)
    {
        if (AmbientAudioSource.enabled)
        {
            AmbientAudioSource.clip = AmbientClips[audioClipID];
            AmbientAudioSource.Play();
        }
    }


    public void PlayAmbient1(int audioClipID)
    {
        if (Ambient1AudioSource.enabled)
        {
            Ambient1AudioSource.clip = AmbientClips[audioClipID];
            Ambient1AudioSource.Play();
        }
    }
}
