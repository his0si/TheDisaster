using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediRecipe : MonoBehaviour
{
    public Medi[] medisList = new Medi[21];

    public Medi makeMedi(int first, int second)
    {
        Medi result = null;

        if(first == 0)
        {
            if(second == 0) { result = medisList[0]; }
            else if(second == 1) { result = medisList[1]; }
            else if(second == 2) { result = medisList[2]; }
            else if(second == 3) { result = medisList[3]; }
            else if(second == 4) { result = medisList[4]; }
            else if(second == 5) { result = medisList[5]; }
        }
        else if(first == 1)
        {
            if (second == 0) { result = medisList[1]; }
            else if (second == 1) { result = medisList[6]; }
            else if (second == 2) { result = medisList[7]; }
            else if (second == 3) { result = medisList[8]; }
            else if (second == 4) { result = medisList[9]; }
            else if (second == 5) { result = medisList[10]; }
        }
        else if (first == 2)
        {
            if (second == 0) { result = medisList[2]; }
            else if (second == 1) { result = medisList[7]; }
            else if (second == 2) { result = medisList[11]; }
            else if (second == 3) { result = medisList[12]; }
            else if (second == 4) { result = medisList[13]; }
            else if (second == 5) { result = medisList[14]; }
        }
        else if (first == 3)
        {
            if (second == 0) { result = medisList[3]; }
            else if (second == 1) { result = medisList[8]; }
            else if (second == 2) { result = medisList[12]; }
            else if (second == 3) { result = medisList[15]; }
            else if (second == 4) { result = medisList[16]; }
            else if (second == 5) { result = medisList[17]; }
        }
        else if (first == 4)
        {
            if (second == 0) { result = medisList[4]; }
            else if (second == 1) { result = medisList[9]; }
            else if (second == 2) { result = medisList[13]; }
            else if (second == 3) { result = medisList[16]; }
            else if (second == 4) { result = medisList[18]; }
            else if (second == 5) { result = medisList[19]; }
        }
        else if (first == 5)
        {
            if (second == 0) { result = medisList[5]; }
            else if (second == 1) { result = medisList[10]; }
            else if (second == 2) { result = medisList[14]; }
            else if (second == 3) { result = medisList[17]; }
            else if (second == 4) { result = medisList[19]; }
            else if (second == 5) { result = medisList[20]; }
        }
        return result;
    }
}
