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
    public GameObject makingAni;

    private Image makedMediImg;
    private Text makedMediName;
    private Text makedMediDiscription;

    public AudioSource selectAudioSource;

    private void Start()
    {
        ResetMaterials();
        mediRecipe = GetComponent<MediRecipe>();
        makedMediImg = makingAni.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
        makedMediName = makingAni.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        makedMediDiscription = makingAni.transform.GetChild(3).GetChild(2).GetComponent<Text>();
        selectAudioSource = GetComponent<AudioSource>();
    }

    //����
    public void ResetMaterials()
    {
        // 99�� null ��� ���
        selectedMaterial[0] = 99;
        selectedMaterial[1] = 99;
        selectedText[0].text = "";
        selectedText[1].text = "";
    }

    //����
    public void Combination()
    {
        if(selectedMaterial[1] == 99) // ��� �� �ʿ�
        {
            Debug.Log("��� �� �ʿ�");
        }
        else
        {
            makedMedi = mediRecipe.makeMedi(selectedMaterial[0], selectedMaterial[1]);
            //Debug.Log(makedMedi.name);
            ResetMaterials();
            //// �÷��� ��� ���� 
            //PlayerPrefs.SetInt(makedMedi.name, 1);
            //// for debug
            //for(int i = 0; i < mediRecipe.medisList.Length; i++)
            //{
            //    Debug.Log(PlayerPrefs.GetInt(mediRecipe.medisList[i].name));
            //}
            selectAudioSource.Play();

            // ����� �ִϸ��̼� Start
            makingAni.SetActive(true);
            makedMediImg.sprite = makedMedi.sprite;
            makedMediImg.SetNativeSize();
            makedMediName.text = makedMedi.mediName;
            makedMediDiscription.text = makedMedi.shortDescription;
        }
    }
}
