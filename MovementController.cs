using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float force = 50f;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rb2d;
    public CharacterController controller;

    public Joystick joystick;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float factorX = joystick.Horizontal * force;
        float factorY = joystick.Vertical * force;

//if (Input.GetKey(KeyCode.W))
        if (Input.GetMouseButton(0))
        {
            rb2d.AddForce(new Vector2(0f, factorY));
        }
        //if (Input.GetKey(KeyCode.A))
        if (Input.GetMouseButton(0))
        {
            rb2d.AddForce(new Vector2(factorX, 0f));
        }
        /*else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(factorX, 0f));
        }*/

    }
}
