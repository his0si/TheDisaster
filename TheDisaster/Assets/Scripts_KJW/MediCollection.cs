using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediCollection : MonoBehaviour
{
    public MediRecipe mediRecipe;

    private void Start()
    {
        mediRecipe = GetComponent<MediRecipe>();
        if (!PlayerPrefs.HasKey(mediRecipe.medisList[0].name))
        {
            CollectionReset();
        }
    }

    // 0이면 컬렉션 잠금, 1이면 컬렉션 오픈
    private void CollectionReset()
    {
        for(int i = 0; i<mediRecipe.medisList.Length; i++) 
        {
            PlayerPrefs.SetInt(mediRecipe.medisList[i].name, 0);
        }
    }
}
