using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public void skipToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
