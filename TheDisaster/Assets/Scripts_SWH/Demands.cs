using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demands : MonoBehaviour
{
    public Text demandText;
    public DemandsText[] medi;
    public int mediNum;
    public int demandCount;
    
    // Start is called before the first frame update
    void Start()
    {
        demandCount = 0;
        mediNum = Random.Range(0, medi.Length);
        demandText.text = medi[mediNum].demands[demandCount];
    }

    public void PrintDemands()
    {
        demandCount++;
        Debug.Log(medi[mediNum].demands.Length);
        if(demandCount > medi[mediNum].demands.Length - 1)
        {
            demandText.text = medi[mediNum].demands[^1];
            demandCount--;
        }
        else
        {
            demandText.text = medi[mediNum].demands[demandCount];
        }
    }
}

[System.Serializable]
public class DemandsText
{   
    public string[] demands;
}
