using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text[] texts;

    void Start()
    {
        foreach (Text text in texts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }

        StartCoroutine(ShowTextsSequentially(4.0f, 1.0f));
    }

    IEnumerator ShowTextsSequentially(float textDisplayTime, float gapTime)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            StartCoroutine(FadeTextIn(texts[i], 1.5f));

            yield return new WaitForSeconds(textDisplayTime);

            // Add a 1-second gap between texts
            yield return new WaitForSeconds(gapTime);
        }

        // After all texts are displayed, skip to the main scene
        skipToMainScene();
    }

    IEnumerator FadeTextIn(Text text, float fadeInTime)
    {
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeInTime));
            yield return null;
        }

        // Wait for the text to be fully visible before starting to fade out
        yield return new WaitForSeconds(fadeInTime);

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / fadeInTime));
            yield return null;
        }
    }

    // 추가된 부분: 모든 텍스트가 표시된 후 메인 씬으로 이동
    public void skipToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
