using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediManager : MonoBehaviour
{
    private MediRecipe mediRecipe;
    public Medi makedMedi;
    public int[] selectedMaterial = new int[2];
    public Text[] selectedText;


    private void Start()
    {
        ResetMaterials();
        mediRecipe = GetComponent<MediRecipe>();
    }

    //리셋
    public void ResetMaterials()
    {
        // 99를 null 대신 사용
        selectedMaterial[0] = 99;
        selectedMaterial[1] = 99;
        selectedText[0].text = "";
        selectedText[1].text = "";
    }

    //조합
    public void Combination()
    {
        if(selectedMaterial[1] == 99) // 재료 더 필요
        {
            Debug.Log("재료 더 필요");
        }
        makedMedi = mediRecipe.makeMedi(selectedMaterial[0], selectedMaterial[1]);
        Debug.Log(makedMedi.name);
        // 컬렉션 잠금 해제
        // 해당 약 의뢰 스크립트에 넘김
    }
}
