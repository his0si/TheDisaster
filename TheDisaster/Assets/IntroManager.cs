using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text[] texts; // TextMeshProUGUI 대신 Text로 변경

    void Start()
    {
        foreach (Text text in texts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }

        StartCoroutine(ShowTextsSequentially(3.0f));
    }

    IEnumerator ShowTextsSequentially(float textInterval)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            StartCoroutine(FadeTextIn(texts[i], 1.5f));
            yield return new WaitForSeconds(textInterval);
        }
    }

    IEnumerator FadeTextIn(Text text, float fadeInTime)
    {
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeInTime));
            yield return null;
        }

        yield return new WaitForSeconds(fadeInTime);

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / fadeInTime));
            yield return null;
        }
    }
}
