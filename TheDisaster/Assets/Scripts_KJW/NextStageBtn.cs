using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageBtn : MonoBehaviour
{
    
    public void ClickBtn()
    {
        if (GameManager.Instance.demandNum >= 3)
        {
            GameManager.Instance.LoadScene("NextDay1");
            GameManager.Instance.dayNum++;
        }
            
        if (GameManager.Instance.demandNum >= 6)
        {
            GameManager.Instance.LoadScene("NextDay2");
            GameManager.Instance.dayNum++;
        }
        if (GameManager.Instance.demandNum >= 9)
        {
            GameManager.Instance.LoadScene("NextDay3");
            GameManager.Instance.dayNum++;
        }
    }
}
