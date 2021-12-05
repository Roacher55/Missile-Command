using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyMissleNewLevel : MonoBehaviour
{
    [SerializeField] Text textHowManyMissleDestroy;
    [SerializeField] Text textCurrentLevel;
    [SerializeField] Text textNextLevel;
    [SerializeField] Text ammoText;
    [SerializeField] Text textZeroAmmo;
    [SerializeField] Text textPoints;
    [SerializeField]int startMissle = 5;
    [SerializeField] int additionalMissle = 5;
    [SerializeField] float additionalSpeed = 0.1f;

    SpawnEnemyMissle spawnEnemyMissle;
    float timerNextLevel = 0f;
    int points = 0;
    public int missleToDestroy;
    int level = 1;
    EndGame endGame;
    PlayerGun playerGun;
    // Start is called before the first frame update
    void Start()
    {
        playerGun = FindObjectOfType<PlayerGun>();
        endGame = FindObjectOfType<EndGame>();
        spawnEnemyMissle = FindObjectOfType<SpawnEnemyMissle>();
        missleToDestroy = startMissle;
        playerGun.ammo = startMissle * 2;
        spawnEnemyMissle.howMuchMissle = missleToDestroy;
        
    }

    // Update is called once per frame
    void Update()
    {
        TextsSettings();
        NextLevel();
    }

    void NextLevel()
    {
        if(missleToDestroy <= 0)
        {
            points += (playerGun.ammo * 100) + endGame.targets.Count * 500;
            startMissle = startMissle + additionalMissle;
            missleToDestroy = startMissle;
            playerGun.ammo = startMissle * 2;
            Missle.speed += additionalSpeed;
            level++;
            spawnEnemyMissle.howMuchMissle = missleToDestroy;

            TimerAndColourText();
        }


    }

    void TimerAndColourText()
    {
        timerNextLevel = 3f;
        textNextLevel.color = Random.ColorHSV();
    }

    void TextsSettings()
    {
        textHowManyMissleDestroy.text = "Zniszcz: " + missleToDestroy + " rakiet!";
        textCurrentLevel.text = "Obecnje level: " + level + " !";
        ammoText.text = "Amunicja: " + playerGun.ammo + " !";
        textPoints.text = "Punkty: " + points + "!";


        if (timerNextLevel > 0)
        {
            textNextLevel.gameObject.SetActive(true);
            timerNextLevel -= Time.deltaTime;
        }
        else
        {
            textNextLevel.gameObject.SetActive(false);
        }

        if (playerGun.ammo > 0)
        {
            textZeroAmmo.gameObject.SetActive(false);
        }
        else
        {
            textZeroAmmo.gameObject.SetActive(true);
        }
    }

    
}
