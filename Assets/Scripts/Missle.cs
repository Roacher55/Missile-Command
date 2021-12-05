using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public Vector3 target;
    public static float speed = 1f;
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    

    protected private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (target == transform.position)
        {
            Destroy(gameObject);
        }
        
    }

    protected void Rotate()
    {
        Vector3 targetPos = target;
        Vector3 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }

    protected void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
