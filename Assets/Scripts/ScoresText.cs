using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresText : MonoBehaviour
{
    [SerializeField] List<Text> scores;
    [SerializeField] Text lastGameScore;
    [SerializeField]SaveScores saveScores;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("LastScore"))
        {
            saveScores.lastGamesScore = PlayerPrefs.GetInt("LastScore");
        }
        else
        {
            saveScores.lastGamesScore = 0;  
        }
        for (int i = 0; i < saveScores.scores.Length; i++)
        {
            string label = "Score" + i;
            if (PlayerPrefs.HasKey(label))
            {
                saveScores.scores[i] = PlayerPrefs.GetInt(label);
            }
            else
            {
                saveScores.scores[i] = 0;
            }
        }

    }

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
