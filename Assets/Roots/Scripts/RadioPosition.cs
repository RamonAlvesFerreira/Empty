using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPosition : MonoBehaviour
{

    [SerializeField]
    private GameObject radioMesh;
    private bool radioIsPositioned;

    // Start is called before the first frame update
    void Start()
    {
        radioMesh.SetActive(false);
        radioIsPositioned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RadioPositioned()
    {
        if (!radioIsPositioned)
        {
            radioMesh.SetActive(true);
            radioIsPositioned = true;
        }
        else
        {

        }
        
    }
}
