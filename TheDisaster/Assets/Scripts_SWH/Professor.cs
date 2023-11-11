using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Professor : MonoBehaviour
{
    public GameObject demand;
    public Text demandTxt;
    public GameObject startAnswer1;
    public GameObject startAnswer2;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject nextBtn;
    public GameObject endBtn;

    int a=0;
    int todayDemandNum;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = false;
        }

        todayDemandNum =0;
        StartCoroutine("DayStart"); 
    }

    //새로운 의뢰 받기
    public void NewProfessor()
    {
        GameManager.Instance.demandNum++;
        todayDemandNum++;
        if(todayDemandNum > 3)
        {
            Debug.Log("오늘 하루 의뢰 끝!");
            StartCoroutine("DayEnd");
        }
        else
        {
            StartCoroutine("ShowDemandText");
            demand.GetComponent<Demands>().NewDemand();
        }
    }

    //day 시작할때
    IEnumerator DayStart()
    {
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);
        if(GameManager.Instance.dayNum == 0)
        {
            demandTxt.text = "그래, 화연 군. 준비는 되었겠지?";
        }
        else if(GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "흠흠... 오늘도 잘해줄 거라 믿네.";
        }
        else if(GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "벌써 대회가 내일이야. 오늘도 잘 할 수 있겠지?";
        }

        yield return new WaitForSeconds(1.0f);
        startAnswer1.SetActive(true);
        startAnswer2.SetActive(true);
    }

    //day 끝날때
    IEnumerator DayEnd()
    {
        yield return new WaitForSeconds(1.0f);

        demand.SetActive(true);
        if (GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "오늘 푹… 자지 말게! 연습, 또 연습!";
        }
        else
        {
            demandTxt.text = "오늘 수고했네. 내일도 늦지 않게 나오도록!";
        }

        yield return new WaitForSeconds(1.0f);
        endBtn.SetActive(true);
    }

    public void StartAnswer1()
    {
        if(GameManager.Instance.dayNum == 0)
        {
            if (a == 0)
            {
                demandTxt.text = "(무시) 내가 절대 옆 방 교수와 내기를 해서 그런 건 아니라네.";
            }
            else
            {
                demandTxt.text = "…아무튼 그런 일이 있네!";
                StartCoroutine("InActiveStartAnswer");
            }
            a++;
        }
        else if(GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "우는 소리 하지 말게나! 바로 시작하지!";
            StartCoroutine("InActiveStartAnswer");
        }
        else if(GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "허허, 벌써부터 기대하고 있구먼!";
            StartCoroutine("InActiveStartAnswer");
        }
    }

    public void StartAnswer2()
    {
        if (GameManager.Instance.dayNum == 0)
        {
            if (a == 0)
            {
                demandTxt.text = "(흡족) 내가 절대 옆 방 교수와 내기를 해서 그런 건 아니라네.";
            }
            else
            {
                demandTxt.text = "마음에 드는 대답이군!";
                StartCoroutine("InActiveStartAnswer");
            }
            a++;
        }
        else if (GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "든든하구먼! 그렇다면…";
            StartCoroutine("InActiveStartAnswer");
        }
        else if (GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "그래, 꼭 우승을 해보도록 하자고!";
            StartCoroutine("InActiveStartAnswer");
        }

    }
    IEnumerator InActiveStartAnswer()
    {
        startAnswer1.SetActive(false);
        startAnswer2.SetActive(false);

        yield return new WaitForSeconds(2.0f);

        if (GameManager.Instance.dayNum == 0)
        {
            demandTxt.text = "그렇다면 좋은 성과를 기대하겠네.";
            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);
        }
        else
        {
            demand.SetActive(false);
        }
        Invoke("NewProfessor", 2.0f);
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

    //다음(버튼)
    public void NextBtn()
    {
        nextBtn.SetActive(false);
        answer1.SetActive(true);
        answer2.SetActive(true);
        demand.GetComponent<Demands>().PrintDemands();

        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = true;
        }
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
        foreach (Button x in GameObject.Find("Materials").GetComponentsInChildren<Button>())
        {
            x.interactable = false;
        }

        MediManager mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
        Demands demandMedi = GameObject.Find("Demand").GetComponent<Demands>();
        
        if (mediManager.makedMedi.name == demandMedi.mediNum.ToString())
        {
            Debug.Log("조합 성공!");
            GameManager.Instance.AddScore(demandMedi.demandCount);
            GameManager.Instance.isSucess.Add(true);
            StopCoroutine("ShowDemandText");
            
            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);

            //랜덤 성공 메세지
            int i = Random.Range(0, demandMedi.successMsg.Length);
            demandMedi.demandText.text = demandMedi.successMsg[i];

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
        else
        {
            Debug.Log("조합 실패!");
            GameManager.Instance.isSucess.Add(false);
            StopCoroutine("ShowDemandText");

            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);

            if(demandMedi.isSecond == false)
            {
                int i = Random.Range(0, demandMedi.fail1Msg.Length);
                demandMedi.demandText.text = demandMedi.fail1Msg[i];
            }
            else
            {
                int i = Random.Range(0, demandMedi.fail2Msg.Length);
                demandMedi.demandText.text = demandMedi.fail2Msg[i];
            }

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
    }
}
