using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEquip : MonoBehaviour
{
    public GameObject rocket;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask enemyLayer;
    public float atkCD;
    private float curAtkCD;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        curAtkCD = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = player.position;
        if (curAtkCD <= 0)
        {
            FireRocket();
            
            curAtkCD = atkCD;
        }
        else
        {
            curAtkCD -= Time.deltaTime;
        }


    }
    public void FireRocket()
    {
        GameObject newRocket = Instantiate(rocket, player.position, Quaternion.identity);
    }

    

}
