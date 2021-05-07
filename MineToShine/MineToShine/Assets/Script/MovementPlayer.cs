using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{

	PlayerController control;


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

    Transform crossPreview;

    public int nbSpot = 3;

    int cptL = 0;



    public Lumiere.eLumiereType typeLum = Lumiere.eLumiereType.rouge;
   

    Vector3 velocity = Vector3.zero;

    Vector2 moveV;
    Vector2 josticPos;

    GameManager gm;


	private void Awake()
	{
		control = new PlayerController();
		////control.Gameplay.Light.performed += ctx => LightM();

		control.Gameplay.Move.performed += ctx => moveV = ctx.ReadValue<Vector2>();
		control.Gameplay.Move.canceled += ctx => moveV = Vector2.zero;

        control.Gameplay.DirectionLum.performed+= ctx => josticPos=ctx.ReadValue<Vector2>();
        control.Gameplay.DirectionLum.canceled += ctx => moveV = Vector2.zero;

        control.Gameplay.PoseLum.performed += ctx => PosserLumiere();

    }

	// Start is called before the first frame update
	void Start()
    {

        lt = GetComponentInChildren<Light2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        crossPreview = transform.GetChild(3).transform;
        gm = GameObject.FindObjectOfType<GameManager>();

        // lt.color = Color.blue;


        lt.pointLightOuterRadius = radiusLight;
        lt.pointLightInnerRadius = radiusLight / 2;

        //Debug.Log(lt.name);

    }

    // Update is called once per frame
    void Update()
    {

		//if (Input.GetKeyDown(KeyCode.E))
		//{
		//	isAlight = !isAlight;

		//}

		if (control.Gameplay.Light.triggered)
		{
			isAlight = !isAlight;

		}

		ChangerLumiere();

        PosePreviewLum();
        //PosserLumiere();

        ReprendreLumiere();

		LumiereIsTurn();

        anim.SetFloat("speed", Mathf.Abs(horizontalMovement));
        anim.SetFloat("speedV", rb.velocity.y);
       
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
            anim.SetTrigger("jump");
            isJumping = false;
		}
	}


    void Flip()
	{
        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

    void PosePreviewLum()
	{
        Vector2 posPL;
        posPL = new Vector2(josticPos.x, josticPos.y) * rangePosLight;

        crossPreview.position = new Vector2(posPL.x + transform.position.x, posPL.y+ transform.position.y);

	}

    void PosserLumiere()
	{


        if (/*Input.GetKeyDown(KeyCode.Mouse0)  control.Gameplay.PoseLum.triggered && */nbSpot > 0)
        {
            Vector3 posM;
            //// posM = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posM = new Vector2(josticPos.x, josticPos.y);
            //Debug.Log(posM);
            posM.z = 0f;

            Vector3 dir;
            //dir = posM - transform.position;
            dir = posM * rangePosLight;
            //Debug.Log(dir);
            Vector3 posL = new Vector3(dir.x + transform.position.x, dir.y + transform.position.y);

            GameObject sp = Instantiate(spotPrefab, posL, Quaternion.identity);
            sp.name = "spot" + cptL;
            sp.GetComponent<Lumiere>().typeLumiere = typeLum;

            cptL++;
            nbSpot--;



        }
    }

    void ChangerLumiere()
	{
        if(/*Input.GetKeyDown(KeyCode.E)*/control.Gameplay.ChangeDroit.triggered)
		{
            typeLum++;

            

            if((int)typeLum>2)
			{
                typeLum = Lumiere.eLumiereType.rouge;
			}
		}

        if(/*Input.GetKeyDown(KeyCode.A)*/control.Gameplay.ChangeGauche.triggered)
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

		if (/*Input.GetKeyDown(KeyCode.Mouse1)*/control.Gameplay.RetireLum.triggered)
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
            // float move = Input.GetAxis("Horizontal");
            float move = moveV.x;


            


            horizontalMovement = move * moveSpeed * Time.fixedDeltaTime;


            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCkeckRadius, collisionLayer);
            anim.SetBool("grounded", isGrounded);
			if (control.Gameplay.Jump.triggered/*Input.GetButtonDown("Jump")*/ && isGrounded)
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

	public void OnEnable()
	{
		control.Enable();
	}

	private void OnDisable()
	{
		control.Disable();
	}

	void LightM()
	{
        isAlight = !isAlight;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.name=="flag")
		{
            gm.FinishV();
        }

        if(collision.tag == "Ennemi" )
		{
            if(collision.GetComponent<EnnemiScript>().canMove)
			{
                gm.FinishD();
            }
            
		}
        
	}
}
