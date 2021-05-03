using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.Universal;

public class TraverserObject : MonoBehaviour
{
    public enum eCouleurType
    {
        rouge,
        vert,
        bleu
	}

    public eCouleurType typeCouleur;

    public bool isTurnning = false;

    float rangeLight = 5f;

    bool lightOn = false;

    float dis;

    Transform tLumiere;




    BoxCollider2D col;
    SpriteRenderer spR;
    

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spR = GetComponent<SpriteRenderer>();

        //rangeLight = FindObjectOfType<Lumiere>().radiusLight;


        if(typeCouleur == eCouleurType.rouge)
		{
            spR.color = Color.red;
		}

        if(typeCouleur == eCouleurType.vert)
		{
            spR.color = Color.green;
		}

        if(typeCouleur == eCouleurType.bleu)
		{
            spR.color = Color.blue;
		}

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lightOn && tLumiere!=null)
		{
            dis = (transform.position.x + spR.bounds.size.x / 2) - tLumiere.position.x;

            //Debug.Log(Mathf.Abs(dis));

            if (Mathf.Abs(dis) > rangeLight)
            {
                isTurnning = false;
                lightOn = false;
            }
        }
        else
		{
            isTurnning = false;
            lightOn = false;
            col.isTrigger = false;
        }


        

        if(isTurnning)
		{
            col.isTrigger = true;

			spR.color = new Color(spR.color.r,spR.color.g,spR.color.b,(Mathf.Abs(dis) * 20)/100);

            //Debug.Log(dis);
        }
    }



    public void ToucherLumiere( string name)
	{
        rangeLight = GameObject.Find(name).GetComponent<Lumiere>().radiusLight;
        lightOn = true;
        tLumiere = GameObject.Find(name).transform;
    }

    //comparer la distance de entre l'objet et le joueur, si supérieur au radius le désactiver. Changer la transparence en fonction de la distance entre les deux
}
