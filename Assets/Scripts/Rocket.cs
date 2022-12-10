using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float explodeRadius;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Animator anim;
    public float damage;
    public Transform target;
    public 
    // Start is called before the first frame update
    void Start()
    {
        FindNearestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        speed *= 1.01f;
        if (target)
        {
            if (Vector2.Distance(transform.position, target.position) < 0.2f)
            {
                Explode();
            }

            Vector3 direction = target.position - transform.position;
            transform.position += direction.normalized * speed;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
        else
        {
            FindNearestTarget();
        }

        
        
    }

    private void Explode()
    {
        speed = 0;
        anim.SetTrigger("explode");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explodeRadius, enemyLayer);
        foreach(var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().decreaseHP(damage);
        }
        Invoke(nameof(DestroyRocket), 0.5f);
    }

    private void DestroyRocket()
    {
        Destroy(gameObject);
    }

    private void FindNearestTarget()
    {
        float minDis = 100000;
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, 100, enemyLayer);
        foreach (var target in targets)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < minDis)
            {
                minDis = Vector2.Distance(transform.position, target.transform.position);
                this.target = target.transform;
            }
        }
    }
}
