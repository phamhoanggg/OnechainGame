using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    [SerializeField] private Joystick jt;

    // Update is called once per frame
    void Update()
    {
        if (jt.Direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(jt.Direction.y, jt.Direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

}