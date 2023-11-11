using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image[] images;   
    [SerializeField] TextMeshProUGUI text = null;

    void Start()
    {
        foreach (Image image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }

        StartCoroutine(ShowImagesSequentially(1.5f));
    }

    IEnumerator ShowImagesSequentially(float fadeInTime)
    {
        for (int i = 0; i < images.Length; i++)
        {
            StartCoroutine(FadeImageIn(images[i], fadeInTime));
            yield return new WaitForSeconds(fadeInTime);
        }

        StartCoroutine(FadeTextToFullAlpha(1.5f, text));
    }

    IEnumerator FadeImageIn(Image image, float fadeInTime)
    {
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / fadeInTime));
            yield return null;
        }
    }

    IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI j)
    {
        while (j.color.a < 1.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }

        yield return new WaitForSeconds(t);

        while (j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
