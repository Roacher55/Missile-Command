using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target" || collision.tag == "Missle")
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject,0.2f);
        }
    }
}
