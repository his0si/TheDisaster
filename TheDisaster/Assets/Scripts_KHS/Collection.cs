using UnityEngine;

public class Collection : MonoBehaviour
{
    public void SkipToCollectionScene()
    {
        GameManager.Instance.LoadScene("Collection");
    }
}
