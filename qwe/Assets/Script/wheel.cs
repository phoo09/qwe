using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Speed += 0.5f;
            transform.Rotate(new Vector3(0, Speed, 0));
            if (Speed == 360)
                Speed = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Speed -= 0.5f;
            transform.Rotate(new Vector3(0, Speed, 0));
            if (Speed == -360)
                Speed = 0;
        }
    }
}
