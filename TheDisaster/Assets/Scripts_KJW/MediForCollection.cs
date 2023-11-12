using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediForCollection : MonoBehaviour
{
    public CollectionInfo collectionInfo;
    private MediRecipe mediRecipe;
    private Medi thisMedi;
    public Sprite nullSprite;
    private Sprite mediSprite;
    public GameObject blackPanel;

    void Start()
    {
        mediRecipe = transform.parent.GetComponent<MediRecipe>();
        thisMedi = mediRecipe.medisList[int.Parse(gameObject.name)];
        mediSprite = thisMedi.sprite;
    }

    public void Show()
    {
        this.GetComponent<Image>().sprite = mediSprite;
        this.GetComponent<Image>().SetNativeSize();

        if(!(PlayerPrefs.GetInt(mediRecipe.medisList[int.Parse(gameObject.name)].name) == 1))
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void ClickMedi()
    {
        if(PlayerPrefs.GetInt(mediRecipe.medisList[int.Parse(gameObject.name)].name) == 1) 
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
