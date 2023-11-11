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
    private AudioSource audioSource;

    private void Start()
    {
        mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickMaterialButton()
    {
        if (mediManager.selectedMaterial[0] == 99) // 첫번째 비어있음 
        {
            mediManager.selectedMaterial[0] = code;
            selectedText[0].text = materialName;
            audioSource.Play();
        }
        else if(mediManager.selectedMaterial[1] == 99) // 두번째만 비어있음
        {
            mediManager.selectedMaterial[1] = code;
            selectedText[1].text = materialName;
            audioSource.Play();
        }
        else Debug.Log("재료 선택 다 함");

    }


}
