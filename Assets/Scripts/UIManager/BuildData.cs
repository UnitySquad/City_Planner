using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BuildData", fileName = "New BuildData")]
public class BuildData : ScriptableObject
{
    public string Inherence;
    public string BuildDataName;
    
    [TextArea(5, 5)]
    public string BuildDataDes;

    public Sprite BuildDataSprite;
}