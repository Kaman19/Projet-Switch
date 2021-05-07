using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject cvsVitoire,cvsDefaite;

    //public bool isFinish = false;
    MovementPlayer m_player;

    Light2D gbLight;



    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindObjectOfType<MovementPlayer>();
        gbLight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();
    }



	public void FinishV()
	{
        m_player.enabled = false;
        cvsVitoire.SetActive(true);
        gbLight.intensity = 1f;
	}

    public void FinishD()
	{
        m_player.enabled = false;
        cvsDefaite.SetActive(true);

        gbLight.intensity = 1f;
    }
}
