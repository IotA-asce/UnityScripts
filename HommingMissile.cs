using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HommingMissile : MonoBehaviour
{

    public float speed = 50f;
    public int countFrames = 0;
    // public float force = 0.01f;
    public float rotateSpeed = 2200f;
    // public float rotateForce = 200f;
    public Transform target;


    private Rigidbody2D rb2d;
    private Vector2 pos;
    private int x, y, z;
    //private Tra

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-50, 50);
        y = Random.Range(-45, 45);
        pos = new Vector2(x, y);
        
        transform.position = pos;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb2d.position;

        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb2d.angularVelocity = -rotateAmount * rotateSpeed;
        rb2d.velocity = transform.up * speed;

        /*
        int factor = countFrames % 300;
        if (countFrames == 1000000)
        {
            countFrames = 0;
        }
        if (factor == 0)
        {
            speed += force;
            rotateSpeed += rotateForce;
            rotateForce += 200;
        }
        countFrames++;
        Debug.Log(countFrames);
        */
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Collision!");
            Destroy(gameObject);
        }
    }
    
    /*void OnTriggerEnter(collider : Collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);   
        }
    }*/
}
