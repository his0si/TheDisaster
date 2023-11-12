using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Professor_Ham : MonoBehaviour
{
    public GameObject demand;
    public Text demandTxt;
    public RectTransform rect;

    public GameObject professor;


    public int hamDemandNum;
    public string[] hamDemand;
    public List<List<string>> correctList;
    public string[] correctMsg;
    public string[] failMsg;

    // Start is called before the first frame update
    void Start()
    {
        correctList = new List<List<string>>();
        correctList.Add(new List<string> {"11"});
        correctList.Add(new List<string> { "4", "9", "13", "16", "18"});
        correctList.Add(new List<string> { "16" });
        correctList.Add(new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "17", "18", "19", "20" });

        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = false;
        }
        StartCoroutine("Enter");
        //StartCoroutine("StartContest");
    }

    //입장
    IEnumerator Enter()
    {
        float pos = rect.anchoredPosition.x;
        while (pos < -550)
        {
            yield return new WaitForSeconds(0.01f);
            pos += 5;
            rect.anchoredPosition = new Vector3(pos, rect.anchoredPosition.y);
        }
        rect.anchoredPosition = new Vector3(-550, rect.anchoredPosition.y);
        StartCoroutine("StartContest");
    }

    //처음에 의뢰 말풍선 생성
    IEnumerator StartContest()
    {
        StopCoroutine("Enter");
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);
        HamDemand();
    }
    public void HamDemand()
    {
        hamDemandNum = Random.Range(0, hamDemand.Length);
        demandTxt.text = hamDemand[hamDemandNum];

        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = true;
        }
    }

    public void CompareMedi()
    {
        StartCoroutine("SubmitMedi");
    }

    IEnumerator SubmitMedi()
    {
        bool isCorrect;
        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = false;
        }

        MediManager mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();

        if (correctList[hamDemandNum].Contains(mediManager.makedMedi.name))
        {
            isCorrect = true;
            Debug.Log("정답!");
            StopCoroutine("ShowDemandText");

            mediManager.makingAni.SetActive(false);

            demandTxt.text = correctMsg[hamDemandNum];

            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            isCorrect = false;
            Debug.Log("오답!");
            StopCoroutine("ShowDemandText");

            mediManager.makingAni.SetActive(false);

            demandTxt.text = failMsg[hamDemandNum];

            yield return new WaitForSeconds(2.0f);
        }
        demand.SetActive(false);

        float pos = rect.anchoredPosition.x;
        while(pos > -1300)
        {
            yield return new WaitForSeconds(0.01f);
            pos -= 5;
            rect.anchoredPosition = new Vector3(pos, rect.anchoredPosition.y);

        }

        yield return new WaitForSeconds(2.0f);
        professor.SetActive(true);
        professor.GetComponent<Professor>().AfterContest(isCorrect);
        gameObject.SetActive(false);
    }
}
