using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    private float moveInput;

    public Rigidbody2D rb;
    public GameObject body;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    

    private bool isFlipped = false;


    public float shootForce = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;

    Vector2 force;
    Vector3 startPosition;
    Vector3 endPosition;

    private TrajectoryLine trajectoryLine;

    public CameraShake cameraShake;
    private float currTime = 0.0f;
    private float shakeTime = 0.8f;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        trajectoryLine = GetComponent<TrajectoryLine>();

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            Debug.Log("Pressed");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            Debug.Log("Pressed");
            rb.velocity = Vector2.up * jumpForce;
        }

        
        if(Input.GetMouseButton(0))
        {
            Vector3 currPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currPosition.z = -10f;
            trajectoryLine.RenderLine(startPosition, currPosition);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = -10f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(cameraShake.Shake(.15f, .4f));


            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPosition.z = -10f;

            force = new Vector2(Mathf.Clamp(startPosition.x - endPosition.x, minPower.x, maxPower.x), Mathf.Clamp(startPosition.y - endPosition.y, minPower.y, maxPower.y));
            rb.AddForce(force * shootForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Freeze");
        }
    }


    private void FixedUpdate()
    {
        
         //moveInput = Input.GetAxis("Horizontal");
        
         //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 && isFlipped == true)
        {
            flip();
        }
        if (moveInput < 0 && isFlipped == false)
        {
            flip();
        }
        

    }

    private void flip()
    {
        isFlipped = !isFlipped;

        Vector3 scaler = body.transform.localScale;
        scaler.x *= -1;
        body.transform.localScale = scaler;
    }



}
