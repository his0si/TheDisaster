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
    public bool isSecond;
    //public List<int> mediNumList;
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
        demandCount = 0;
        isSecond = false;

        //의뢰 약 번호
        for(int i=0; i<medi.Length; i++)
        {
            mediNum = Random.Range(0, medi.Length);
            int index = GameManager.Instance.demandsList.FindLastIndex(x => x == mediNum);

            //새로운 의뢰인 경우
            if (index == -1)
            {
                break;
            }
            //동일 의뢰 중 실패 의뢰인 경우
            else if (index != -1)
            {
                if (GameManager.Instance.isSucess[index] == false)
                {
                    isSecond = true;
                    break;
                }
            }
        }

        //동일 의뢰
        if (isSecond)
        {
            GameManager.Instance.demandsList.Add(mediNum);
            demandText.text = "이번엔 할 수 있겠지?";
        }
        //동일 의뢰 아님
        else
        {
            GameManager.Instance.demandsList.Add(mediNum);

            //의뢰 텍스트
            int i = Random.Range(0, demandMsg.Length);
            demandText.text = demandMsg[i];
        }
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
