using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Professor : MonoBehaviour
{
    public GameObject demand;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject nextBtn;


    // Start is called before the first frame update
    void Start()
    {
        NewProfessor();
    }

    //새로운 의뢰 받기
    public void NewProfessor()
    {
        GameManager.Instance.demandNum++;
        if(GameManager.Instance.demandNum > 3)
        {
            Debug.Log("오늘 하루 의뢰 끝!");
        }
        StartCoroutine("ShowDemandText");
        demand.GetComponent<Demands>().NewDemand();
    }

    //처음에 의뢰 말풍선 생성
    IEnumerator ShowDemandText()
    {
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        //answer1.SetActive(true);
        //answer2.SetActive(true);
        nextBtn.SetActive(true);
    }
    public void NextBtn()
    {
        nextBtn.SetActive(false);
        answer1.SetActive(true);
        answer2.SetActive(true);
        demand.GetComponent<Demands>().PrintDemands();
    }

    //요구 수락 했을 시 말풍선 제거(버튼)
    public void InactiveDemandUI()
    {
        //demand.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
    }

    //약 조합 버튼 클릭 시 정답 비교(버튼)
    public void CompareMedi()
    {
        StartCoroutine("SubmitMedi");
    }

    IEnumerator SubmitMedi()
    {
        MediManager mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
        Demands demandMedi = GameObject.Find("Demand").GetComponent<Demands>();
        
        if (mediManager.makedMedi.name == demandMedi.mediNum.ToString())
        {
            Debug.Log("조합 성공!");
            GameManager.Instance.AddScore(demandMedi.demandCount);
            StopCoroutine("ShowDemandText");
            
            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);
            int i = Random.Range(0, demandMedi.successMsg.Length);
            demandMedi.demandText.text = demandMedi.successMsg[i];

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
        else
        {
            Debug.Log("조합 실패!");
            StopCoroutine("ShowDemandText");

            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);
            int i = Random.Range(0, demandMedi.fail1Msg.Length);
            demandMedi.demandText.text = demandMedi.fail1Msg[i];

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
    }
}
