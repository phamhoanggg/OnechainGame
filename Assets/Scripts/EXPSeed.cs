using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPSeed : MonoBehaviour
{
    public float expAmount;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.IncreaseEXP(expAmount);
            Destroy(gameObject);
        }
    }

    

}
