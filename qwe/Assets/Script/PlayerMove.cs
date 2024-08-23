using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float fireSpeed = 1f;
    public float FireRate = 1.0f;
    private float nextFireTime;
    public GameObject projectile;
    public GameObject PivotObject;
    public Rigidbody Rigidbody;
    public float Speed = 5f;
    public Transform firePoint;
    public float Jump = 50;
    public bool Air = false;
    public Camera viewCamera;
    public float h, v;
    public float X = 0f;
    public float Y = 0f;
    public float Z = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            Y += 2;
        if (Input.GetKey(KeyCode.LeftArrow))
            Y -= 2;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 10;
            
        }
        else
        {
            Speed = 5;
            
        }



        //h = Input.GetAxis("Horizontal") * Speed;
        //v = Input.GetAxis("Vertical") * Speed;
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.Self);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * Time.deltaTime * Speed, Space.Self);
        transform.rotation = Quaternion.Euler(0f, Y, 0f);
        Vector3 dir = new Vector3(h, 0, v);


        // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정
        if (!(h == 0 && v == 0))
        {
            // 이동과 회전을 함께 처리
            transform.position += dir * Speed * Time.deltaTime;
            // 회전하는 부분
            //transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3)
            transform.position = new Vector3(0,3,0);

        if (Time.time > nextFireTime&& Input.GetKeyDown(KeyCode.Z))
        {
            nextFireTime = Time.time + 1f / fireSpeed;
            GameObject temp = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
        if (Input.GetKey(KeyCode.Space)&& Air == false)
        {
            if(!Air)
            {
                Air = true;
                Rigidbody.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("land"))
            Air = false;
        else
            Air = true;
    }
}