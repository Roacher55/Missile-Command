using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissle : Missle
{
    // Start is called before the first frame update
    List<GameObject> targets =  new List<GameObject>();
    DestroyMissleNewLevel destroyMissleNewLevel;
    int index;
    TextInGame textInGame;
    [SerializeField] GameObject Smug;
    void Start()
    {
        foreach(var a in GameObject.FindGameObjectsWithTag("Target"))
        { 
            targets.Add(a);
        }
        index = Random.Range(0, targets.Count);
        target = targets[index].transform.position;
        destroyMissleNewLevel = FindObjectOfType<DestroyMissleNewLevel>();

        textInGame = FindObjectOfType<TextInGame>();
        Rotate();
        Smug.SetActive(true);
    }

    // Update is called once per frame

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Target")
        {
            MakeExplosion(); 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        destroyMissleNewLevel.missleToDestroy--;
        textInGame.onStatisticChange.Invoke();
        if(destroyMissleNewLevel.missleToDestroy <= 0)
        { 
            textInGame.nextLevelEvent.Invoke();
        }
    }
}
