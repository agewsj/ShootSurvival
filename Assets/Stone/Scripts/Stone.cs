using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    //이동 속도
    public float moveSpeed = 0;

    //
    float limitHeight = 0f;
    public float height = 0f;

    bool isJump = false;

    public float jumpRange = 0f;
    public float fallDownRange = 0f;

    public float upSpeed = 2f;
    public float downSpeed = 2f;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        isJump = true;
        limitHeight = transform.position.y + height;
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
                limitHeight = transform.position.y + height;
            }
            
        }

        JumpUp();
        JumpDown();
    }

    void Move()
    {
        transform.position += new Vector3(moveSpeed, 0f, 0f);
    }

    void JumpUp()
    {
        if(isJump == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + jumpRange, transform.position.z), Time.deltaTime * upSpeed);

            if (transform.position.y >= limitHeight)
            {
                isJump = false;
            }
        }        
    }

    void JumpDown()
    {
        if (isJump == false)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - fallDownRange, transform.position.z), Time.deltaTime * downSpeed);
        }            
    }
}
