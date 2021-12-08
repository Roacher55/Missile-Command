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
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void TargetPointVisual()
    {
        poinReference = Instantiate(point, target, transform.rotation);
        
    }

    protected override void Move()
    {
        base.Move();
        if (target == transform.position)
        {
            Destroy(poinReference);
        }
    }
}
