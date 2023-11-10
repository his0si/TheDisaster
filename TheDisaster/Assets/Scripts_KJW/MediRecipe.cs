using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediRecipe : MonoBehaviour
{
    public Medi[] medisList;

    private void Start()
    {
    }

    public Medi makeMedi(int first, int second)
    {
        Medi result = null;

        if(first == 0)
        {
            if(second == 0) { result = medisList[0]; }
            if(second == 1) { result = medisList[0]; } 
            if(second == 2) { result = medisList[0]; }
            if(second == 3) { result = medisList[0]; }
            if(second == 4) { result = medisList[0]; }
            if(second == 5) { result = medisList[0]; }
        }

        return result;
    }
}
