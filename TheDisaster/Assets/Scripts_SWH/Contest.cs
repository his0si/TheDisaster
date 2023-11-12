using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject hamProf;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator button()
    {
        yield return new WaitForSeconds(1.0f);
        nextButton.SetActive(true);
    }

    public void NextButton()
    {
        hamProf.SetActive(true);
        gameObject.SetActive(false);
        nextButton.SetActive(false);
    }
}
