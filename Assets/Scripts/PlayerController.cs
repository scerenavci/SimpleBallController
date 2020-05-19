using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 direction;
    private float editorSpeed = 50.0f;
    private float speed = 5.0f;
    private Rigidbody rb;

    public Vector2 lastPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    lastPos = new Vector2(touch.position.x, touch.position.y);
                    break;
                
                case TouchPhase.Moved:
                    
                    direction = touch.position - lastPos;
                    
                    float h = direction.x;
                    float v = direction.y;
                    
                    Vector3 movement = new Vector3(h, 0 , v);
                    rb.AddForce(movement * speed);

                    lastPos = touch.position;
                    break;
            }
        }
#if UNITY_EDITOR
        
        if (Input.GetMouseButton(0))
        {
            float h= Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            Vector3 movement = new Vector3(h, 0 , v);
            rb.AddForce(movement * editorSpeed);
        }
#endif 
    }
}
