using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Rigidbody rigidbody = null;
    public float moveSpeed = 0;
    public int jumpPower = 0;
    public bool isJump = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(isJump == false)
            {
                isJump = true;
                Jump();
            }            
        }
    }

    void Move()
    {
        transform.position += new Vector3(moveSpeed, 0f, 0f);
    }

    void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Jump"))
        {         
            isJump = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {            
            isJump = true;
        }
    }
}
