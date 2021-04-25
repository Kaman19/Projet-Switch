using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MovementPlayer : MonoBehaviour
{

    Light2D lt;

    public float moveSpeed, jumpForce;


    bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public LayerMask collisionLayer;
    public float groundCkeckRadius;

    public float radiusLight;
    public LayerMask collisionLightLayer;

    float horizontalMovement;

    bool lookRight = true;

    Rigidbody2D rb;
    Animator anim;

    bool isAlight = true;
   

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponentInChildren<Light2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // lt.color = Color.blue;

        lt.pointLightOuterRadius = radiusLight;
        lt.pointLightInnerRadius = radiusLight / 2;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            isAlight = !isAlight;

        }


        if (isAlight)
		{

            lt.enabled = true;
            float move = Input.GetAxis("Horizontal");


            horizontalMovement = move * moveSpeed * Time.fixedDeltaTime;


            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCkeckRadius, collisionLayer);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isJumping = true;
            }


            if (move > 0 && !lookRight)
            {
                Flip();

            }
            else if (move < 0 && lookRight)
            {
                Flip();
            }


           

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radiusLight,collisionLightLayer);
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log(hit[i].name);
                hit[i].GetComponent<TraverserObject>().isTurnning = true;
            }
        }

        if(!isAlight)
		{
            lt.enabled = false;
		}
       
    }

	private void FixedUpdate()
	{
        MovePlayer(horizontalMovement);
	}


	void MovePlayer(float _horizontalMovement)
	{
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping==true)
		{
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
		}
	}


    void Flip()
	{
        lookRight = !lookRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCkeckRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radiusLight);
	}


}
