using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEquip : MonoBehaviour
{
    public GameObject sawPref;
    [SerializeField] private Transform player;
    [SerializeField] private float activeTime;
    [SerializeField] private float resetTime;
    public int sawNumber;
    private List<GameObject> listSaw = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        sawPref.GetComponent<Saw>().damage = 10;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sawNumber = 1;
        SpawnSaw();
        ResetSaw();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            transform.position = player.position;
            transform.Rotate(0, 0, 4, Space.Self);
        }
    }

    private void ResetSaw()
    {
        Invoke(nameof(DeActiveSaw), activeTime);
        foreach(var saw in listSaw)
        {
            saw.SetActive(true);
        }
    }

    private void DeActiveSaw()
    {
        Invoke(nameof(ResetSaw), resetTime - activeTime);
        foreach (var saw in listSaw)
        {
            saw.SetActive(false);
        }
    }

    public void SpawnSaw()
    {
        foreach(var saw in listSaw)
        {
            Destroy(saw);
        }
        listSaw.Clear();

        for (int i = 0; i < sawNumber; i++)
        {
            GameObject newSaw = Instantiate(sawPref, transform);
            newSaw.transform.localPosition = new Vector3(9, 0, 0);
            newSaw.transform.RotateAround(transform.position, Vector3.forward, i * 360 / sawNumber);
            listSaw.Add(newSaw);
        }
    }

}
