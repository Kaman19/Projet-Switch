using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraverserObject : MonoBehaviour
{
    public bool isTurnning = false;


    BoxCollider2D col;
    SpriteRenderer spR;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurnning)
		{
            col.isTrigger = true;
		}
    }

    //comparer la distance de entre l'objet et le joueur, si supérieur au radius le désactiver. Changer la transparence en fonction de la distance entre les deux
}
