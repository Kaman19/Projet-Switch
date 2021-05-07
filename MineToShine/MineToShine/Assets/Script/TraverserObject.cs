using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    ShadowCaster2D shC;


    BoxCollider2D col;
    SpriteRenderer spR;
    

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spR = GetComponent<SpriteRenderer>();
        shC = GetComponent<ShadowCaster2D>();

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


        Debug.Log(spR.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        if(lightOn && tLumiere!=null)
		{
            dis = ((transform.position.x - tLumiere.position.x)-spR.bounds.size.x/2);
            Debug.Log(Mathf.Abs(dis));

            if (Mathf.Abs(dis) > rangeLight)
            {
                isTurnning = false;
                lightOn = false;
                shC.castsShadows = true;
            }
        }
        else
		{
            isTurnning = false;
            lightOn = false;
            col.isTrigger = false;
            shC.castsShadows = true;
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

    
}
