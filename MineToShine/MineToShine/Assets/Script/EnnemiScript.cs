using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiScript : MonoBehaviour
{
    public float moveSpeed;


    public Lumiere.eLumiereType lumiereType;

    MovementPlayer m_player;

    public bool canMove = true;

    Transform tLumiere;

    float rangeLight = 5f;


    bool lookRight = false;


    SpriteRenderer spR;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        m_player = FindObjectOfType<MovementPlayer>();

        spR = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

  //      if (lumiereType==Lumiere.eLumiereType.rouge)
		//{
  //          spR.color = Color.red;
  //      }

  //      if (lumiereType == Lumiere.eLumiereType.vert)
  //      {
  //          spR.color = Color.green;
  //      }

  //      if (lumiereType == Lumiere.eLumiereType.bleu)
  //      {
  //          spR.color = Color.blue;
  //      }

    }

    // Update is called once per frame
    void Update()
    {

        var nbLumiere = FindObjectsOfType<Lumiere>();


        if(!canMove && tLumiere==null)
		{
            canMove = true;

		}


        if((m_player.isAlight || nbLumiere.Length>0) && canMove)
		{
            Vector3 dir = m_player.transform.position - transform.position;
            Debug.Log(dir);



            transform.position += dir.normalized * moveSpeed * Time.deltaTime;


            if (dir.x > 0 && !lookRight)
            {
                Flip();

            }
            else if (dir.x < 0 && lookRight)
            {
                Flip();
            }
        }



        anim.SetBool("Move", canMove);

    }

    public void ToucherLumiere(string name)
    {
        rangeLight = GameObject.Find(name).GetComponent<Lumiere>().radiusLight;
        tLumiere = GameObject.Find(name).transform;
    }

    void Flip()
    {
        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
