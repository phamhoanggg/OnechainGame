using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCD;
    float curAtkCD;
    public GameObject shuriken;
    // Start is called before the first frame update
    void Start()
    {
        curAtkCD = 0;
        shuriken.GetComponent<Shuriken>().damage = 10;
        shuriken.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (curAtkCD <= 0)
        {
            Vector2 shurikenDir = GetComponent<PlayerMoving>().direction.normalized;
            if (shurikenDir != Vector2.zero)
            {
                shuriken.GetComponent<Shuriken>().direction = shurikenDir;
            }
            else shuriken.GetComponent<Shuriken>().direction = Vector2.right;

            Instantiate(shuriken, transform.position, Quaternion.identity); 
            curAtkCD = attackCD;
        }else
        {
            curAtkCD -= Time.fixedDeltaTime;
        }
    }


}
