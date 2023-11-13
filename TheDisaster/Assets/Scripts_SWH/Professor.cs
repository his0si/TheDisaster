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

    public GameObject contest;

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

    //���ο� �Ƿ� �ޱ�
    public void NewProfessor()
    {
        GameManager.Instance.demandNum++;
        todayDemandNum++;
        if(todayDemandNum > 3)
        {
            Debug.Log("���� �Ϸ� �Ƿ� ��!");
            StartCoroutine("DayEnd");
        }
        else
        {
            StartCoroutine("ShowDemandText");
            demand.GetComponent<Demands>().NewDemand();
        }
    }

    //day �����Ҷ�
    IEnumerator DayStart()
    {
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);
        if(GameManager.Instance.dayNum == 0)
        {
            demandTxt.text = "�׷�, ȭ�� ��. �غ�� �Ǿ�����?";
        }
        else if(GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "����... ���õ� ������ �Ŷ� �ϳ�.";
        }
        else if(GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "���� ��ȸ�� �����̾�. ���õ� ���� �� �ְ���?";
        }
        else if(GameManager.Instance.dayNum == 3)
        {
            demandTxt.text = "��, ���� �س� �� �ְ���?";
        }

        yield return new WaitForSeconds(1.0f);
        startAnswer1.SetActive(true);
        startAnswer2.SetActive(true);
    }

    //day ������
    IEnumerator DayEnd()
    {
        yield return new WaitForSeconds(1.0f);

        demand.SetActive(true);
        if (GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "���� ǫ�� ���� ����! ����, �� ����!";
        }
        else
        {
            demandTxt.text = "���� �����߳�. ���ϵ� ���� �ʰ� ��������!";
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
                demandTxt.text = "(����) ���� ���� �� �� ������ ���⸦ �ؼ� �׷� �� �ƴ϶��.";
            }
            else
            {
                demandTxt.text = "���ƹ�ư �׷� ���� �ֳ�!";
                StartCoroutine("InActiveStartAnswer");
            }
            a++;
        }
        else if(GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "��¼Ҹ� ���� ���Գ�! �ٷ� ��������!";
            StartCoroutine("InActiveStartAnswer");
        }
        else if(GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "����, ������� ����ϰ� �ֱ���!";
            StartCoroutine("InActiveStartAnswer");
        }
        else if (GameManager.Instance.dayNum == 3)
        {
            demandTxt.text = "����!! ����!!";
            StartCoroutine("InActiveStartAnswer");
        }
    }

    public void StartAnswer2()
    {
        if (GameManager.Instance.dayNum == 0)
        {
            if (a == 0)
            {
                demandTxt.text = "(����) ���� ���� �� �� ������ ���⸦ �ؼ� �׷� �� �ƴ϶��.";
            }
            else
            {
                demandTxt.text = "������ ��� ����̱�!";
                StartCoroutine("InActiveStartAnswer");
            }
            a++;
        }
        else if (GameManager.Instance.dayNum == 1)
        {
            demandTxt.text = "����ϱ���! �׷��ٸ顦";
            StartCoroutine("InActiveStartAnswer");
        }
        else if (GameManager.Instance.dayNum == 2)
        {
            demandTxt.text = "�׷�, �� ����� �غ����� ���ڰ�!";
            StartCoroutine("InActiveStartAnswer");
        }
        else if (GameManager.Instance.dayNum == 3)
        {
            demandTxt.text = "�� �⼼�� ��±��� ��������!";
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
            demandTxt.text = "�׷��ٸ� ���� ������ ����ϰڳ�.";
            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);
            Invoke("NewProfessor", 2.0f);
        }
        else if(GameManager.Instance.dayNum == 3)
        {
            contest.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            demand.SetActive(false);
            Invoke("NewProfessor", 2.0f);
        }
        
    }

    //ó���� �Ƿ� ��ǳ�� ����
    IEnumerator ShowDemandText()
    {
        yield return new WaitForSeconds(1.0f);
        demand.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        //answer1.SetActive(true);
        //answer2.SetActive(true);
        nextBtn.SetActive(true);
    }

    //����(��ư)
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

    //�䱸 ���� ���� �� ��ǳ�� ����(��ư)
    public void InactiveDemandUI()
    {
        //demand.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
    }

    //�� ���� ��ư Ŭ�� �� ���� ��(��ư)
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
            Debug.Log("���� ����!");
            GameManager.Instance.AddScore(demandMedi.demandCount);
            GameManager.Instance.isSucess.Add(true);
            StopCoroutine("ShowDemandText");
            PlayerPrefs.SetInt(mediManager.makedMedi.name, 1); // jiwoo add
            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);

            //���� ���� �޼���
            int i = Random.Range(0, demandMedi.successMsg.Length);
            demandMedi.demandText.text = demandMedi.successMsg[i];

            yield return new WaitForSeconds(2.0f);
            demand.SetActive(false);

            Invoke("NewProfessor", 2.0f);
        }
        else
        {
            Debug.Log("���� ����!");
            GameManager.Instance.isSucess.Add(false);
            StopCoroutine("ShowDemandText");

            InactiveDemandUI();
            mediManager.makingAni.SetActive(false);

            if (demandMedi.isSecond == false)
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
    public void AfterContest(bool isCorrect)
    {
        if(isCorrect == true)
        {
            demand.SetActive(true);
            demandTxt.text = "���� �Ǹ���! �ڳ״� �����ϼ�! ���� �ڸ� ���� �����! ���Ϻ��� ��ħ 9�ñ��� �����Ƿ� ����ϵ��� �ϰԳ�!!";
            demandTxt.fontSize = 34;
        }
        else if(isCorrect == false)
        {
            demand.SetActive(true);
            demandTxt.text = "��� ���� ���� �� �������� ���� ��� �Ǿ������� �����ٳ�. ���Ϻ��� ��ħ 9�ñ��� �����Ƿ� ������.";
            demandTxt.fontSize = 34;
        }
        GameManager.Instance.Ending(isCorrect);
        StartCoroutine("Ending");
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(3.0f);
        GameManager.Instance.LoadScene("ending");
    }
}
