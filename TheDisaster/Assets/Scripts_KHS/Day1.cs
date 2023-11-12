using UnityEngine;

public class Day1 : MonoBehaviour
{
    public void SkipToDay1Scene()
    {
        GameManager.Instance.LoadScene("Day1");
        GameManager.Instance.dayNum = 0;
        GameManager.Instance.demandNum = 0;
        GameManager.Instance.totalScore = 0;

        GameManager.Instance.demandsList.Clear();
        GameManager.Instance.isSucess.Clear();
        
/*            public int dayNum;
    public int demandNum;
    public float totalScore;
    public float likeability;

    public List<int> demandsList;
    public List<bool> isSucess;*/
    }
}
