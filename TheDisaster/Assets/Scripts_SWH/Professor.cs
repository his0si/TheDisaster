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

    //처음에 말풍선 생성
    IEnumerator ShowDemandText()
    {
        yield return new WaitForSeconds(2.0f);
        demand.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        answer1.SetActive(true);
        answer2.SetActive(true);
    }

    //요구 수락 했을 시 말풍선 제거
    public void InactiveDemandUI()
    {
        //demand.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
    }

    public void CompareMedi()
    {
        Debug.Log("버튼");
        MediManager mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
        Demands demandMedi = GameObject.Find("Demand").GetComponent<Demands>();

        if(mediManager.makedMedi.name == demandMedi.mediNum.ToString())
        {
            Debug.Log("조합 성공!");
        }
        else
        {
            Debug.Log("조합 실패!");
        }
    }

}
