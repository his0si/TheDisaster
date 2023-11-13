using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediCollectionSettingInMain : MonoBehaviour
{
    public MediRecipe mediRecipe;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(mediRecipe.medisList[0].mediCode.ToString()))
        {
            Debug.Log("컬렉션 리셋");
            CollectionReset();
        }
    }
    private void CollectionReset()
    {
        for (int i = 0; i < mediRecipe.medisList.Length; i++)
        {
            PlayerPrefs.SetInt(mediRecipe.medisList[i].mediCode.ToString(), 0);
        }
    }
}
