using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresText : MonoBehaviour
{
    [SerializeField] List<Text> scores;
    [SerializeField] Text lastGameScore;
    [SerializeField]SaveScores saveScores;

    private void Start()
    {

        int i = 0;
        foreach(var x in scores)
        {
           x.text = (i + 1) + ". Miejsce: " + saveScores.scores[i] + "!";
            i++;
        }
        lastGameScore.text = "Ostatnia Gra: " + saveScores.lastGamesScore + "!";

    }
}
