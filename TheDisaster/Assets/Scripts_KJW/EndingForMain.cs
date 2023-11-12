using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingForMain : MonoBehaviour
{
    public string endingNumStr;
    public Sprite endingSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(endingNumStr))
        {
            CollectionReset();
        }
        else ShowEndingCollection();
    }

    private void CollectionReset()
    {
        PlayerPrefs.SetInt(endingNumStr, 0);
    }

    private void ShowEndingCollection()
    {
        if (PlayerPrefs.GetInt(endingNumStr) == 1) // ผ๖มýตส
        {
            this.GetComponent<Image>().sprite = endingSprite;
            this.GetComponent<Image>().SetNativeSize();
        }
    }
}
