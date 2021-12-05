using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMissle : MonoBehaviour
{
    [SerializeField] GameObject enemyMisslePrefab;
    public int howMuchMissle;
    float timer = 0f;
    float minTimer = 1f;
    float maxTimer = 3f;
    float timweNextLevel = 5f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if(timer <=0f && howMuchMissle > 0)
        {
          float x = Random.Range(-10f, 10f);
          float y = Random.Range(5f, 7f);
          Instantiate(enemyMisslePrefab, new Vector3(x, y, 0), Quaternion.identity);
          howMuchMissle--;

          if(howMuchMissle ==0)
          {
             timer = timweNextLevel;
          }
          else
          { 
             timer = Random.Range(minTimer,maxTimer);
          }
        }
        if(howMuchMissle>0)
            timer -= Time.deltaTime;
    }
}
