using UnityEngine;
using UnityEngine.SceneManagement;

public class Day1 : MonoBehaviour
{
    public void SkipToDay1Scene()
    {
        // "Day1"이라는 씬으로 넘어갑니다.
        GameManager.Instance.FadeOut();
        SceneManager.LoadScene("Day1");
    }
}
