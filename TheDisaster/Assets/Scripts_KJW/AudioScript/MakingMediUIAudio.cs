using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingMediUIAudio : MonoBehaviour
{
    public AudioSource[] audioSource;
    
    void Start()
    {
        Invoke("PlayNext1", 1.5f);
        StartCoroutine(AudioPlayClip(0));
        
    }

    IEnumerator AudioPlayClip(int i)
    {
        audioSource[i].Play();
        float volume = 1;
        while(audioSource[i].volume > 0) 
        {
            volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            audioSource[i].volume = volume;
        }
    }

    void PlayNext1()
    {
        Invoke("PlayNext2", 1.5f);
        StartCoroutine(AudioPlayClip(1));
        
    }

    void PlayNext2()
    {
        StartCoroutine(AudioPlayClip(2));
    }
}
