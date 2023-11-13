using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediCollection : MonoBehaviour
{
    public MediRecipe mediRecipe;
    private GameObject[] medis = new GameObject[21];

    private void Start()
    {
        mediRecipe = GetComponent<MediRecipe>();
        if (!PlayerPrefs.HasKey(mediRecipe.medisList[0].mediCode.ToString()))
        {
            Debug.Log("컬렉션 리셋");
            CollectionReset();
        }
        else ShowMediCollection();
    }

    // 0이면 컬렉션 잠금, 1이면 컬렉션 오픈
    private void CollectionReset()
    {
        for(int i = 0; i<mediRecipe.medisList.Length; i++) 
        {
            PlayerPrefs.SetInt(mediRecipe.medisList[0].mediCode.ToString(), 0);
        }
    }

    private void ShowMediCollection()
    {
        Debug.Log("컬렉션 보여줌");
        // 자식 오브젝트 모두 저장
        for (int i = 0; i<mediRecipe.medisList.Length; i++)
        {
            medis[i] = transform.GetChild(i).gameObject;
        }
        // sprite 변경
        for(int i=0; i<mediRecipe.medisList.Length; i++)
        {
            //if (PlayerPrefs.GetInt(mediRecipe.medisList[i].mediCode.ToString()) == 1) // 수집됨
                medis[i].GetComponent<MediForCollection>().Show();
        }

    }
}
