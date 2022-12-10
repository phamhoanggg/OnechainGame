using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float destroyTime;
    public float damage;

    private void Start()
    {
        StartCoroutine(DestroyAfter(destroyTime));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(direction.x, direction.y) * speed;
        transform.Rotate(0, 0, 20, Space.Self);
    }

    IEnumerator DestroyAfter(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().decreaseHP(damage);
        }
    }
}

