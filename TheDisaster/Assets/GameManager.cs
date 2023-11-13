using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayNum;
    public int demandNum;
    public float totalScore;
    public float likeability;

    public List<int> demandsList;
    public List<bool> isSucess;

    public int endingNum;

    private string nextSceneStr;
    private Image fadePanel;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        totalScore = 0.0f;
        demandNum = 0;
        fadePanel = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        if (_instance == null)
        {
            _instance = this;
        }
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void LoadScene(string sceneName) 
    {
        if(fadePanel.color.a <= 0)
        {
            nextSceneStr = sceneName;
            StartCoroutine(FadeOutCoroutine());
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float alpha = 0;
        while(alpha < 1.0f)
        {
            alpha += 0.03f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0,0,0, alpha);
        }
        if(alpha >= 1.0f)
        {
            SceneManager.LoadScene(nextSceneStr);
            StartCoroutine(FadeInCoroutine());
        }
    }

    IEnumerator FadeInCoroutine()
    {
        float alpha = 1;
        while (alpha > 0f)
        {
            alpha -= 0.03f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, alpha);
        }
    }


    //���� ���ϱ�
    public void AddScore(int count)
    {
        if(count == 1)
        {
            likeability = 1.0f;
            totalScore += likeability;
        }
        else if(count == 2)
        {
            likeability = 0.5f;
            totalScore += likeability;
        }
    }

    //���� ����
    public void Ending(bool isCorrect)
    {
        if (totalScore >= 7)
        {
            if (isCorrect)
            {
                endingNum = 1;
            }
            else
            {
                endingNum = 2;
            }
        }
        else if (totalScore >= 4)
        {
            if (isCorrect)
            {
                endingNum = 3;
            }
            else
            {
                endingNum = 4;
            }
        }
        else if (totalScore >= 0)
        {
            if (isCorrect)
            {
                endingNum = 5;
            }
            else
            {
                endingNum = 6;
            }
        }
        PlayerPrefs.SetInt(endingNum.ToString(), 1);
    }
}

