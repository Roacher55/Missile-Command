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

    private void OnDestroy()
    {
        endGame.targets.Remove(this);
        endGame.onBuildingDestroy.Invoke();
    }


}
