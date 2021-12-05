using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets = new List<GameObject>();
    
    void Start()
    {
        foreach(var x in GameObject.FindGameObjectsWithTag("Target"))
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
            SceneManager.LoadScene("Main");
        }
    }
}
