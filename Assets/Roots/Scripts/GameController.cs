using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] rocksLink;
    [SerializeField]
    private int tapes;

    // Start is called before the first frame update
    void Start()
    {
        tapes = 0;
        foreach (GameObject rocks in rocksLink)
        {
            rocks.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateProgess()
    {
        for(int i = 0; i < tapes; i++)
        {
            rocksLink[i].SetActive(true);
        }
    }

    //GETs
    public int getTapes()
    {
        return this.tapes;
    }


    //SETs
    public void setTapes(int tapesToAdd)
    {
        this.tapes += tapesToAdd;
    }

}
