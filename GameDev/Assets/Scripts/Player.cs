using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKey;
    private float horizontalInput;
    private Rigidbody rigidbodComponent;
    [SerializeField] private Transform groundcheck = null;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        rigidbodComponent.velocity = new Vector3(horizontalInput*4, rigidbodComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundcheck.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKey)
        {
            rigidbodComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKey = false;
        }
    }


}
