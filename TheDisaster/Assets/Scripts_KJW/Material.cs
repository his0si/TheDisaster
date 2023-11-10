using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material : MonoBehaviour
{
    public MediManager mediManager;
    public Text[] selectedText;
    [SerializeField] private int code;
    [SerializeField] string materialName;

    private void Start()
    {
        mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
    }

    public void ClickMaterialButton()
    {
        if (mediManager.selectedMaterial[0] == 99) // 첫번째 비어있음 
        {
            mediManager.selectedMaterial[0] = code;
            selectedText[0].text = materialName;
        }
        else if(mediManager.selectedMaterial[1] == 99) // 두번째만 비어있음
        {
            mediManager.selectedMaterial[1] = code;
            selectedText[1].text = materialName;
        }
        else Debug.Log("재료 선택 다 함");

    }


}
