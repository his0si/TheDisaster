using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        int i = GameManager.Instance.endingNum;
        if (i != 0)
        {
            transform.GetChild(i - 1).gameObject.SetActive(true);
        }
    }
}
