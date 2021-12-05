using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveScores")]
public class SaveScores : ScriptableObject
{
    public int[] scores;
    public int lastGamesScore;
}
