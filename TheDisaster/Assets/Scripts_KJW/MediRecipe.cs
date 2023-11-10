using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediRecipe : MonoBehaviour
{
    private MediManager mediManager;

    private void Start()
    {
        mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
    }


    // 첫번째 재료 -> 두번째 재료 존재 여부로 묻는 이차원 배열


    // 재료가 배열에 있는지 확인
}
