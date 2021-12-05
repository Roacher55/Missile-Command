using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    Vector3 worldPosition;
    [SerializeField] GameObject playerMisslePrefab;
    public int ammo = 4;
    [SerializeField] GameObject textOnDestroy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnAndSerTargetMissle();
    }

    void SpawnAndSerTargetMissle()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if(ammo >0)
            { 
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                var x = Instantiate(playerMisslePrefab, transform.position, transform.rotation);
                x.GetComponent<PlayerMissle>().target = worldPosition;
                x.GetComponent<PlayerMissle>().target.z = 0f;
                ammo--;
            }
        }
    }

    private void OnDestroy()
    {
        textOnDestroy.SetActive(true);
    }
}
