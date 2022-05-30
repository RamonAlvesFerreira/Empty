using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBehaviour : MonoBehaviour
{
    [SerializeField]
    private Light lanternLight;

    [SerializeField]
    private Material onLightMaterial, offLightMaterial;

    [SerializeField]
    private List<GameObject> lightsGlass;

    private bool enabled;


    // Start is called before the first frame update
    void Start()
    {
        lanternLight.gameObject.SetActive(false);
        for (int i = 0; i < lightsGlass.Capacity; i++)
        {
            lightsGlass[i].GetComponent<Renderer>().material = offLightMaterial;
        }
        enabled = false;
    }
    public void Light()
    {
        enabled = !enabled;
        if (enabled)
        {
            lanternLight.gameObject.SetActive(true);
            for (int i = 0; i < lightsGlass.Capacity; i++)
            {
                lightsGlass[i].GetComponent<Renderer>().material = onLightMaterial;
            }
        }
        else
        {
            lanternLight.gameObject.SetActive(false);
            for (int i = 0; i < lightsGlass.Capacity; i++)
            {
                lightsGlass[i].GetComponent<Renderer>().material = offLightMaterial;
            }
        }
    }
}
