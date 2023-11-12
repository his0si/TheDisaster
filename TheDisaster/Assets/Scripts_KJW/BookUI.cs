using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] GameObject[] pages;
    private int pageNum = 0;
    public AudioSource audioSource;

    void Start()
    {
        leftButton.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        for(int i=0; i<pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
        pages[0].gameObject.SetActive(true);
    }

    public void ClickLeftBtn()
    {
        rightButton.gameObject.SetActive(true);
        pages[pageNum].gameObject.SetActive(false);
        pageNum--;
        if(pageNum == 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        pages[pageNum].gameObject.SetActive(true);
        audioSource.Play();
    }

    public void ClickRightBtn()
    {
        leftButton.gameObject.SetActive(true);
        pages[pageNum].gameObject.SetActive(false);
        pageNum++;
        if(pageNum == pages.Length-1)
        {
            rightButton.gameObject.SetActive(false);
        }
        pages[pageNum].gameObject.SetActive(true);
        audioSource.Play();
    }
}
