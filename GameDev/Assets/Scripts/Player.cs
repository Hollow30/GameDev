using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidibodyC;
    private bool jumpKey;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidibodyC = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;        
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        rigidibodyC.velocity = new Vector3(horizontalInput * 4, rigidibodyC.velocity.y, rigidibodyC.velocity.z);
        rigidibodyC.velocity = new Vector3(rigidibodyC.velocity.x, rigidibodyC.velocity.y, verticalInput * 4);


        if (jumpKey)
        {
            rigidibodyC.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKey = false;
        }


    }

}
