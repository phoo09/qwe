using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody Rigidbody;
    public float Speed = 5f;
    public float speed;
    public float Jump = 50;
    public bool Air = false;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Speed;
        if (Input.GetKeyDown(KeyCode.R)) transform.position = new Vector3(0, 0.5f, 0);
        //if (Input.GetKey(KeyCode.W)) Rigidbody.velocity += Vector3.forward * Speed;
        //if (Input.GetKey(KeyCode.S)) Rigidbody.velocity += Vector3.back * Speed;
        //if (Input.GetKey(KeyCode.D)) Rigidbody.velocity += Vector3.right * Speed;
        //if (Input.GetKey(KeyCode.A)) Rigidbody.velocity += Vector3.left * Speed;
        speed = Rigidbody.velocity.magnitude;
        if (Input.GetKeyDown(KeyCode.Escape)) Rigidbody.velocity = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.velocity += Vector3.up*Jump*Jump;
        }
        if (Air == true)
        {
            Rigidbody.velocity += Vector3.down * 5;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("land"))
        {
            if (collision.collider.gameObject.CompareTag("land"))
            {
                Air = false;
            }
            else
            {
                Air = true;
            }
        }
    }
}