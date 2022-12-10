using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float HP;
    public float curHP;
    public float damage;
    public Transform target;
    public List<GameObject> listEXP;
    void Start()
    {
        curHP = HP;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 dir = target.position - transform.position;
        if (dir.x >= 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector2.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector2.up);
        }

        if (curHP <= 0)
        {
            GameController.instance.kills++;
            Instantiate(listEXP[Random.Range(0, listEXP.Count)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void decreaseHP(float dmg)
    {
        curHP -= dmg;
    }
}
