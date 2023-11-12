using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCollection : MonoBehaviour
{
    public string endingName;
    public string endingDiscription;
    public Sprite endingSprite;
    public CollectionInfo collectionInfo;
    public GameObject blackPanel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(endingName))
        {
            CollectionReset();
        }
        else ShowEndingCollection();
    }

    // 0이면 컬렉션 잠금, 1이면 컬렉션 오픈
    private void CollectionReset()
    {
        PlayerPrefs.SetInt(endingName, 0);
    }

    private void ShowEndingCollection()
    {
        if (PlayerPrefs.GetInt(endingName) == 1) // 수집됨
        {
            this.GetComponent<Image>().sprite = endingSprite;
            this.GetComponent<Image>().SetNativeSize();
        }
        else GetComponent<Button>().interactable = false;
    }

    public void ClickEnding()
    {
        if (PlayerPrefs.GetInt(endingName) == 1)
        {
            blackPanel.SetActive(true);
            collectionInfo.gameObject.SetActive(true);
            collectionInfo.infoImage.sprite = endingSprite;
            collectionInfo.infoImage.GetComponent<Image>().SetNativeSize();
            collectionInfo.mediName.text = endingName;
            collectionInfo.description.text = endingDiscription;
            transform.parent.parent.GetComponent<Canvas>().sortingOrder = 10;
        }
    }

    public void DownSortOrder()
    {
        transform.parent.parent.GetComponent<Canvas>().sortingOrder = 0;
    }
}
