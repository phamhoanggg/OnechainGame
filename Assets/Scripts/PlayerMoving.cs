using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public Animator anim;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (joystick.Direction == Vector2.zero)
        {
            anim.SetTrigger("idle");
        }
        else
        {
            anim.SetTrigger("move");
            direction = joystick.Direction;
        }

        if (direction.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector2.up);
            GetComponentInChildren<Canvas>().gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector2.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector2.up);
            GetComponentInChildren<Canvas>().gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector2.up);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystick.Direction != Vector2.zero)
            transform.position += new Vector3(direction.x, direction.y, 0).normalized * speed; 
    }
}
