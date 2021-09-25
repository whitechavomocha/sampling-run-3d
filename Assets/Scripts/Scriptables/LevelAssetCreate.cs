using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelAsset", menuName = "ScriptableObjects/LevelAssetCreate", order = 1)]
public class LevelAssetCreate : ScriptableObject
{
    public GameObject[] levelPrefabs;
    public GameObject[] particles;

    public GameObject confetti;

    public GameObject[] emojis;
}
