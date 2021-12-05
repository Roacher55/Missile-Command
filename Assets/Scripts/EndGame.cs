using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets = new List<GameObject>();
    DestroyMissleNewLevel destroyMissleNewLevel;
    [SerializeField] public SaveScores saveScores;

    void Start()
    {
        
        destroyMissleNewLevel = FindObjectOfType<DestroyMissleNewLevel>();
        foreach (var x in GameObject.FindGameObjectsWithTag("Target"))
        {
            targets.Add(x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LoseAllBuildings();
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
        Debug.Log("Points:" + destroyMissleNewLevel.points);
        var tempScore = destroyMissleNewLevel.points;
        saveScores.lastGamesScore = destroyMissleNewLevel.points;
        for (int i = 0; i < saveScores.scores.Length; i++)
        {
            if (tempScore > saveScores.scores[i])
            {
                int temp = saveScores.scores[i];
                saveScores.scores[i] = tempScore;
                tempScore = temp;
            }
        }
        EditorUtility.SetDirty(saveScores);

        Debug.Log("abc" + saveScores.lastGamesScore);
        Debug.Log("abcdcf" + destroyMissleNewLevel.points);

    }
}
