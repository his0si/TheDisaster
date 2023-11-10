using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Medi", menuName = "Medi/Create New Medi")]
public class Medi : ScriptableObject
{
    public int mediCode;
    public string mediName;
    public string shortDescription;
    public string longDescription;
    public Sprite sprite;
}
