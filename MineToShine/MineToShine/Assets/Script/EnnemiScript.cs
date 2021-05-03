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

   

    SpriteRenderer spR;

    // Start is called before the first frame update
    void Start()
    {

        m_player = FindObjectOfType<MovementPlayer>();

        spR = GetComponent<SpriteRenderer>();

        if(lumiereType==Lumiere.eLumiereType.rouge)
		{
            spR.color = Color.red;
        }

        if (lumiereType == Lumiere.eLumiereType.vert)
        {
            spR.color = Color.green;
        }

        if (lumiereType == Lumiere.eLumiereType.bleu)
        {
            spR.color = Color.blue;
        }

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

            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        }
       

    }

    public void ToucherLumiere(string name)
    {
        rangeLight = GameObject.Find(name).GetComponent<Lumiere>().radiusLight;
        tLumiere = GameObject.Find(name).transform;
    }

}
