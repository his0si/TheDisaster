using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediForCollection : MonoBehaviour
{
    public CollectionInfo collectionInfo;
    private MediRecipe mediRecipe;
    private Medi thisMedi;
    public Sprite thisMediSprite;
    public GameObject blackPanel;

    void Start()
    {
        mediRecipe = transform.parent.GetComponent<MediRecipe>();
        thisMedi = mediRecipe.medisList[int.Parse(gameObject.name)];
    }

    public void Show()
    {
        if (PlayerPrefs.GetInt(name) == 0)
        {
            Debug.Log(gameObject.name + "¾øÀ½");
            GetComponent<Button>().interactable = false;
            // GetComponent<Button>().enabled = false;
            GetComponent<Image>().SetNativeSize();
        }
        else
        {
            GetComponent<Image>().sprite = thisMediSprite;
            GetComponent<Image>().SetNativeSize();
        }
    }

    public void ClickMedi()
    {
        if(PlayerPrefs.GetInt(thisMedi.mediCode.ToString()) == 1) 
        {
            blackPanel.SetActive(true);
            UpdateInfo();
        }
    }

    private void UpdateInfo()
    {
        collectionInfo.gameObject.SetActive(true);
        collectionInfo.infoImage.sprite = thisMedi.sprite;
        collectionInfo.infoImage.GetComponent<Image>().SetNativeSize();
        collectionInfo.mediName.text = thisMedi.mediName;
        collectionInfo.description.text = thisMedi.longDescription;
        transform.parent.parent.GetComponent<Canvas>().sortingOrder = 10;
    }

    public void DownSortOrder()
    {
        transform.parent.parent.GetComponent<Canvas>().sortingOrder = 0;
    }
}
