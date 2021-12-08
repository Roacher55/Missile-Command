using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    Vector3 worldPosition;
    [SerializeField] GameObject playerMisslePrefab;
    public int ammo = 4;
    [SerializeField] GameObject textOnDestroy;
    [SerializeField] Texture2D cursorPositive;
    [SerializeField] Texture2D cursorNegative;
    float shootPositionY = -2.5f;
    TextInGame textInGame;
    [SerializeField]GameObject spawnPositionObject;
    Transform spawnPositionTransform;
    AudioSource playerGunAudiosource;
    // Start is called before the first frame update
    void Start()
    {
        textInGame = FindObjectOfType<TextInGame>();
        spawnPositionTransform = spawnPositionObject.transform;
        playerGunAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorPosition();
        CursorCanShoot();
    }


    private void OnDestroy()
    {
        textOnDestroy.SetActive(true);
        Cursor.SetCursor(cursorNegative, Vector3.zero, CursorMode.ForceSoftware);
    }
    bool CursorCanShoot()
    {
        if (worldPosition.y > shootPositionY)
        {
            Cursor.SetCursor(cursorPositive, Vector3.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursorNegative, Vector3.zero, CursorMode.ForceSoftware);
        }

        return worldPosition.y > shootPositionY;
    }

    void CursorPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDown()
    {
        if (ammo > 0 && CursorCanShoot())
        {
            var missle = Instantiate(playerMisslePrefab, spawnPositionTransform.position, spawnPositionTransform.rotation);
            PlayerMissle playerMissle = missle.GetComponent<PlayerMissle>();
            playerMissle.target = worldPosition;
            playerMissle.target.z = 0f;
            playerGunAudiosource.Play();
            ammo--;
            textInGame.onStatisticChange.Invoke();
            textInGame.zeroAmmoEvent.Invoke(ammo <= 0);
        }
    }


}
