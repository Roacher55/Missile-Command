using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
     EndGame endGame;
    void Start()
    {
        endGame = FindObjectOfType<EndGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        endGame.targets.Remove(gameObject);
    }


}
