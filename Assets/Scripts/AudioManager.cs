using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AUDIO CLIP")]
    public AudioClip BGM;
    public AudioClip Death;
    public AudioClip Collecting;
    public AudioClip Win;
    public AudioClip Fail;

    private void Start() {
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void stopBGM(){
        BGMSource.Stop();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
