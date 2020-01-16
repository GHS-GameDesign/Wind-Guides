using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpF = 10.0f;
    public Rigidbody playerRb;
    public bool isOnTerrain;
    private float Speed = 150.0f;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * hAxis * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * vAxis * Time.deltaTime * speed);
        float CMove = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, CMove * Speed * Time.deltaTime);
        if(Input.GetKeyDown("space") && isOnTerrain == true){
            playerRb.AddForce(Vector3.up * jumpF, ForceMode.Impulse);
            isOnTerrain = false;
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
