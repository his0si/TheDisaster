using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demands : MonoBehaviour
{
    public Text demandText;
    public Text answer1Text;
    public Text answer2Text;
    public DemandsText[] medi;
    public int mediNum;     //약 번호(0~20)
    public int demandCount; //요구사항 텍스트 인덱스
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewDemand()
    {
        demandText.text = "자네, 나 뭐 하나만 만들어줘";
        answer1Text.text = "네.. 뭐..";
        answer2Text.text = "그건 어려울 것 같습니다 교수님";
        demandCount = 0;
        mediNum = Random.Range(0, medi.Length);
        //demandText.text = medi[mediNum].demands[demandCount];
    }
    public void PrintDemands()
    {
        //Debug.Log(medi[mediNum].demands.Length);
        if(demandCount > medi[mediNum].demands.Length - 1)
        {
            demandText.text = medi[mediNum].demands[^1];
            demandCount--;
        }
        else
        {
            demandText.text = medi[mediNum].demands[demandCount];
        }
        demandCount++;
        answer1Text.text = "예?";
        answer2Text.text = "넵 가능합니다 교수님!";
    }
}

[System.Serializable]
public class DemandsText
{   
    public string[] demands;
}
