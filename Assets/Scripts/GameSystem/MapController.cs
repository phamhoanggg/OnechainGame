using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : FastSingleton<MapController>
{
    public GameObject MapParent;

    private void Start()
    {
        MapParent.transform.position = new Vector3(0, 0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direct = Player.instance.transform.position - MapParent.transform.position;
        MapParent.transform.position += new Vector3((int)(direct.x / 30) * 60, (int)(direct.y / 30) * 60, 0);
    }
}
