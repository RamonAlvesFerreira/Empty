using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeHammerBehaviour : EquipBase
{


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    protected override void Consequence()
    {
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 positionToRaycast = startPosition;

        Ray rayshot = new Ray(positionToRaycast, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayshot, out hitInfo, 10))
        {
            if (hitInfo.transform.tag == "Rocks")
            {
                hitInfo.transform.GetComponent<PilarsBehaviour>().DestroyPilar();
            }
        }
    }
}
