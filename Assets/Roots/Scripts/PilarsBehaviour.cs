using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarsBehaviour : MonoBehaviour
{

    public GameObject pilarDestroyed;
    public GameObject pilarFull;

    // Start is called before the first frame update
    void Start()
    {
        pilarDestroyed.SetActive(false);
        pilarFull.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyPilar()
    {
        pilarDestroyed.SetActive(true);
        pilarFull.SetActive(false);

    }
    public void ActivePilar()
    {

    }
}
