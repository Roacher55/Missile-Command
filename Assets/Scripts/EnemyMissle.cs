using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissle : Missle
{
    // Start is called before the first frame update
    List<GameObject> targets =  new List<GameObject>();
    DestroyMissleNewLevel destroyMissleNewLevel;
    int index;
    void Start()
    {
        foreach(var a in GameObject.FindGameObjectsWithTag("Target"))
        { 
            targets.Add(a);
        }
        index = Random.Range(0, targets.Count);
        target = targets[index].transform.position;
        destroyMissleNewLevel = FindObjectOfType<DestroyMissleNewLevel>();
    }

    // Update is called once per frame

    private void Update()
    {
        Move();
        Rotate();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private new void OnDestroy()
    {
        base.OnDestroy();
        destroyMissleNewLevel.missleToDestroy--;
    }
}
