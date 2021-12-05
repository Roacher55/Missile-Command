using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissle : Missle
{
    // Start is called before the first frame update
    [SerializeField] GameObject point;
    GameObject poinReference;
    void Start()
    {
        TargetPointVisual();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Debug.Log(target);
    }

    void TargetPointVisual()
    {
        poinReference = Instantiate(point, target, transform.rotation);
        
    }

    private new void Move()
    {
        base.Move();
        if (target == transform.position)
        {
            Destroy(poinReference);
        }
    }
}
