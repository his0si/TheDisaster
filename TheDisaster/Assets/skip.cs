using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void SkipToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
