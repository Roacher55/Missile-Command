using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestroyMissleNewLevel : MonoBehaviour
{

    [SerializeField]int startMissle = 5;
    [SerializeField] int additionalMissle = 5;
    [SerializeField] float additionalSpeed = 0.1f;
    [SerializeField] AudioSource nextLevelSound;
    [SerializeField]TextInGame textInGame;
    [SerializeField] SpawnEnemyMissle spawnEnemyMissle;
    public int points = 0;
    public int missleToDestroy;
    public int level = 1;
    [SerializeField] EndGame endGame;
    [SerializeField] PlayerGun playerGun;
    private void OnEnable()
    {
        textInGame.nextLevelEvent.AddListener(NextLevel);
    }

    private void OnDisable()
    {
        textInGame.nextLevelEvent.RemoveListener(NextLevel);
    }


    // Start is called before the first frame update
    void Start()
    {
        missleToDestroy = startMissle;
        playerGun.ammo = startMissle * 2;
        spawnEnemyMissle.howMuchMissle = missleToDestroy;
    }

   

    void NextLevel()
    {
            points += (playerGun.ammo * 100) + endGame.targets.Count * 500;
            startMissle = startMissle + additionalMissle;
            missleToDestroy = startMissle;
            playerGun.ammo = startMissle * 2;
            Missle.speed += additionalSpeed;
            level++;
            spawnEnemyMissle.howMuchMissle = missleToDestroy;
            textInGame.onStatisticChange.Invoke();
            textInGame.zeroAmmoEvent.Invoke(playerGun.ammo <= 0);
            nextLevelSound.Play();
        }


    


    
}
