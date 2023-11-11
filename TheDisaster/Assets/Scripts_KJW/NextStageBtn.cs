using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageBtn : MonoBehaviour
{
    
    public void ClickBtn()
    {
        if (GameManager.Instance.dayNum == 0)
        {
            GameManager.Instance.LoadScene("NextDay1");
            GameManager.Instance.dayNum++;
        }
            
        else if (GameManager.Instance.dayNum == 1)
        {
            GameManager.Instance.LoadScene("NextDay2");
            GameManager.Instance.dayNum++;
        }
        else if (GameManager.Instance.dayNum == 2)
        {
            GameManager.Instance.LoadScene("NextDay3");
            GameManager.Instance.dayNum++;
        }
    }
}
