using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScreenSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(AudioPlayClip());
        Invoke("WaitForNextScene", 3f);
    }

    IEnumerator AudioPlayClip()
    {
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        float volume = 1;
        while (audioSource.volume > 0)
        {
            volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            audioSource.volume = volume;
        }
    }

    void WaitForNextScene()
    {
        GameManager.Instance.LoadScene("Intro");
    }
}
