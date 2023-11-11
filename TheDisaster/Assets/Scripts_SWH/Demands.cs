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

    public string[] demandMsg;
    public string[] successMsg;
    public string[] fail1Msg;
    public string[] fail2Msg;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewDemand()
    {
        int i = Random.Range(0, demandMsg.Length);
        demandText.text = demandMsg[i];
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
    }
}

[System.Serializable]
public class DemandsText
{   
    public string[] demands;
}
