using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPref : MonoBehaviour
{
    
    public void resetBtn()
    {
        PlayerPrefs.DeleteAll();
    }

}
