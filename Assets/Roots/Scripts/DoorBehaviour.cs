using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    private Rigidbody doorBody;
    // Start is called before the first frame update
    void Start()
    {
        doorBody = GetComponent<Rigidbody>();
        doorBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Door()
    {
        doorBody.isKinematic = false;
    }
}
