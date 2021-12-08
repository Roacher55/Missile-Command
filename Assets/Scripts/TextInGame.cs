using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextInGame : MonoBehaviour
{
    [SerializeField] private Text textHowManyMissleDestroy;
    [SerializeField] private Text textCurrentLevel;
    [SerializeField] private Text ammoText;  
    [SerializeField] private Text textPoints;
    [SerializeField] private GameObject textNextLevel;
    [SerializeField] private GameObject textZeroAmmo;
    [SerializeField] DestroyMissleNewLevel destroyMissleNewLevel;
    [SerializeField] PlayerGun playerGun;
    Text textNextLevelComponentText;
    public UnityEvent onStatisticChange;
    public UnityEvent nextLevelEvent;
    public UnityEvent<bool> zeroAmmoEvent;


    private void OnEnable()
    {
        onStatisticChange.AddListener(RefreshTexts);
        zeroAmmoEvent.AddListener(TextNoneAmmo);
        nextLevelEvent.AddListener(TextNextLevelActive);
    }

    private void OnDisable()
    {
        onStatisticChange.RemoveListener(RefreshTexts);
        zeroAmmoEvent.RemoveListener(TextNoneAmmo);
        nextLevelEvent.RemoveListener(TextNextLevelActive);
    }
    private void Start()
    {
        textNextLevelComponentText = textNextLevel.GetComponent<Text>();
        RefreshTexts();
    }

    public void RefreshTexts()
    {
        textHowManyMissleDestroy.text = "Zniszcz: " + destroyMissleNewLevel.missleToDestroy + " rakiet!";
        textCurrentLevel.text = "Obecnie level: " + destroyMissleNewLevel.level + "!";
        ammoText.text = "Amunicja: " + playerGun.ammo + "!";
        textPoints.text = "Punkty: " + destroyMissleNewLevel.points + "!";
    }


    void TextNoneAmmo(bool active)
    {
        textZeroAmmo.SetActive(active);
    }

    void TextNextLevelActive()
    {
        textNextLevelComponentText.color = Random.ColorHSV();
        textNextLevel.SetActive(true);
        Invoke("TextNextLevelDisActive", 3f);
    }
    void TextNextLevelDisActive()
    {
        textNextLevel.SetActive(false);
    }
}
