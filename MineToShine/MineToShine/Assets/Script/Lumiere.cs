using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lumiere : MonoBehaviour
{

    Light2D lt;


    public float radiusLight;
    public LayerMask collisionLightLayer;

    SpriteRenderer spR;

    bool isAlightSpot = true;

    public enum eLumiereType
    {
        rouge,
        vert,
        bleu
    }

    public eLumiereType typeLumiere;

    // Start is called before the first frame update
    void Start()
    {

        spR = GetComponent<SpriteRenderer>();
        lt = GetComponentInChildren<Light2D>();

        lt.pointLightOuterRadius = radiusLight;
        lt.pointLightInnerRadius = radiusLight / 2;


        if(typeLumiere==eLumiereType.rouge)
		{
            lt.color = new Color(0.89f, 0.10f, 0.10f);
            spR.color = new Color(0.89f, 0.10f, 0.10f);

        }

        if (typeLumiere == eLumiereType.vert)
        {
            lt.color = new Color(0.10f, 0.89f, 0.10f);
            spR.color = new Color(0.10f, 0.89f, 0.10f);
        }

        if (typeLumiere == eLumiereType.bleu)
        {
            lt.color = new Color(0.10f, 0.10f, 0.89f);
            spR.color = new Color(0.10f, 0.10f, 0.89f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radiusLight, collisionLightLayer);
        for (int i = 0; i < hit.Length; i++)
        {
            if(hit[i].tag=="Porte")
			{
                if ((int)hit[i].GetComponent<TraverserObject>().typeCouleur == (int)typeLumiere)
                {
                    hit[i].GetComponent<TraverserObject>().isTurnning = true;
                    hit[i].GetComponent<TraverserObject>().ToucherLumiere(gameObject.name);

                }
            }

            if( hit[i].tag =="Ennemi")
			{
                if((int)hit[i].GetComponent<EnnemiScript>().lumiereType == (int)typeLumiere)
				{
                    hit[i].GetComponent<EnnemiScript>().canMove = false;
                    hit[i].GetComponent<EnnemiScript>().ToucherLumiere(gameObject.name);
                }
                    
			}
                
            
        }
    }

    private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusLight);
    }
}
