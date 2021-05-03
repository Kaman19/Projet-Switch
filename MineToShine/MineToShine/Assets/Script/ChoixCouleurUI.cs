using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoixCouleurUI : MonoBehaviour
{

    MovementPlayer m_player;
    [SerializeField]
    GameObject fonfR, fondV, fondB;


    // Start is called before the first frame update
    void Start()
    {
        m_player = FindObjectOfType<MovementPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((int)m_player.typeLum==0)
		{
            fonfR.GetComponent<Image>().color = Color.white;

            fondV.GetComponent<Image>().color = Color.black;

            fondB.GetComponent<Image>().color = Color.black;

        }

        if((int)m_player.typeLum==1)
		{
            fonfR.GetComponent<Image>().color = Color.black;

            fondV.GetComponent<Image>().color = Color.white;

            fondB.GetComponent<Image>().color = Color.black;
        }

        if ((int)m_player.typeLum == 2)
        {
            fonfR.GetComponent<Image>().color = Color.black;

            fondV.GetComponent<Image>().color = Color.black;

            fondB.GetComponent<Image>().color = Color.white;
        }
    }
}
