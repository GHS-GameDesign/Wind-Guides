using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float bSpeed;
    public float jumpF = 10.0f;
    public Rigidbody playerRb;
    public bool isOnTerrain;
    private float Speed = 150.0f;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * hAxis * Time.deltaTime * bSpeed);
        transform.Translate(Vector3.forward * vAxis * Time.deltaTime * speed);
        float CMove = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, CMove * Speed * Time.deltaTime);
        if(Input.GetKeyDown("space") && isOnTerrain == true){
            playerRb.AddForce(Vector3.up * jumpF, ForceMode.Impulse);
            isOnTerrain = false;
        }
        if(isOnTerrain == !true){
            bSpeed = 5.0f;
            if(vAxis < 0){
                speed = 5.0f;
            }
            else{
                speed = 10.0f;
            }
        }
        else{
        bSpeed = 10.0f;
        speed = 10.0f;
        }
    }

    void OnCollisionEnter(Collision collision){
       if(collision.gameObject.tag == "ground"){
           isOnTerrain = true;
       }
       else{
           isOnTerrain = false;
       }
    }
}
