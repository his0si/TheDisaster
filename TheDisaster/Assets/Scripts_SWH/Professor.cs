using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Professor : MonoBehaviour
{
    public GameObject demand;
    public GameObject answer1;
    public GameObject answer2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowDemandText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShowDemandText()
    {
        yield return new WaitForSeconds(2.0f);
        demand.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        answer1.SetActive(true);
        answer2.SetActive(true);
    }
}
