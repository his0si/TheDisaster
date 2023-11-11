using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediForCollection : MonoBehaviour
{
    private MediRecipe mediRecipe;
    public Sprite nullSprite;
    private Sprite mediSprite;

    void Start()
    {
        mediRecipe = transform.parent.GetComponent<MediRecipe>();
        mediSprite = mediRecipe.medisList[int.Parse(gameObject.name)].sprite;
    }

    public void Show()
    {
        this.GetComponent<Image>().sprite = mediSprite;
    }
}
