using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBtn : MonoBehaviour
{
   public void ClickBtn()
    {
        GameManager.Instance.LoadScene("Main");
    }
}
