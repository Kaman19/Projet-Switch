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
    public LayerMask collisionPlayerLightLayer;

    float horizontalMovement;

    bool lookRight = true;

    Rigidbody2D rb;
    Animator anim;

    public bool isAlight = true;

    public GameObject spotPrefab;

    public float rangePosLight = 1f;



    public int nbSpot = 3;



    public Lumiere.eLumiereType typeLum = Lumiere.eLumiereType.rouge;
   

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            isAlight = !isAlight;

        }

        ChangerLumiere();

        PosserLumiere();

        ReprendreLumiere();

        LumiereIsTurn();
       
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

    void PosserLumiere()
	{
        if (Input.GetKeyDown(KeyCode.Mouse0) && nbSpot>0)
        {
            Vector3 posM;
            posM = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posM.z = 0f;

            Vector3 dir;
            dir = posM - transform.position;
            dir = dir.normalized * rangePosLight;
            Vector3 posL = new Vector3(dir.x + transform.position.x, dir.y + transform.position.y);

            GameObject sp = Instantiate(spotPrefab, posL, Quaternion.identity);
            sp.name = "spot" + nbSpot;
            sp.GetComponent<Lumiere>().typeLumiere = typeLum;


            nbSpot--;

            



        }
    }

    void ChangerLumiere()
	{
        if(Input.GetKeyDown(KeyCode.E))
		{
            typeLum++;

            

            if((int)typeLum>2)
			{
                typeLum = Lumiere.eLumiereType.rouge;
			}
		}

        if(Input.GetKeyDown(KeyCode.A))
		{
            typeLum--;

            if ((int)typeLum<0)
            {
                typeLum = Lumiere.eLumiereType.bleu;
            }
        }
	}

    void ReprendreLumiere()
	{

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, rangePosLight, collisionPlayerLightLayer);
			for (int i = 0; i < hit.Length; i++)
			{


				Destroy(hit[i].gameObject);
				nbSpot++;
			}
		}

	}

	void LumiereIsTurn()
	{
        if (!isAlight)
        {

            lt.enabled = false;
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

        }

        if (isAlight)
        {
            horizontalMovement = 0;

            lt.enabled = true;
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCkeckRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radiusLight);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangePosLight);
    }


}
