using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public float atkCD;
    float curAtkCD;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        curAtkCD = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.gameState == GameController.GameState.GamePlay)
        {
            Vector3 direct = target.position - transform.position;
            if (direct.magnitude > 0.5f)
                transform.position += direct.normalized * moveSpeed;

            if (curAtkCD > 0)
            {
                curAtkCD -= Time.fixedDeltaTime;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (curAtkCD <= 0)
            {
                Player.instance.decreaseHP(damage);
                curAtkCD = atkCD;
            }
        }
    }

}
