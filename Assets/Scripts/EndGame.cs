using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Building> targets;
    DestroyMissleNewLevel destroyMissleNewLevel;
    [SerializeField] public SaveScores saveScores;
    public UnityEvent onBuildingDestroy;

    private void OnEnable()
    {
        onBuildingDestroy.AddListener(LoseAllBuildings);
    }

    private void OnDisable()
    {
        onBuildingDestroy.RemoveListener(LoseAllBuildings);
    }
    void Start()
    {
        targets = new List<Building>(FindObjectsOfType<Building>());
        destroyMissleNewLevel = FindObjectOfType<DestroyMissleNewLevel>();
    }

    

    void LoseAllBuildings()
    {
        if(targets.Count ==0)
        {
            Missle.speed = 1f;
            SaveScore();
            SceneManager.LoadScene("Menu");
        }
    }

    void SaveScore()
    {

        var tempScore = destroyMissleNewLevel.points;
        saveScores.lastGamesScore = destroyMissleNewLevel.points;
        PlayerPrefs.SetInt("LastScore", saveScores.lastGamesScore);

        for (int i = 0; i < saveScores.scores.Length; i++)
        {
            if (tempScore > saveScores.scores[i])
            {
                int temp = saveScores.scores[i];
                saveScores.scores[i] = tempScore;
                tempScore = temp;
                string label = "Score" + i;
                PlayerPrefs.SetInt(label, saveScores.scores[i]);
            }
        }
        PlayerPrefs.Save();


    }

    

}
