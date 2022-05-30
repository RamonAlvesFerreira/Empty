using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private float timeOfQuits;
    private float currentTimeOfQuits;
    private bool quotActive;
    [SerializeField]
    private GameObject[] quots;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject currentQuot in quots)
        {
            currentQuot.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (quotActive)
        {
            currentTimeOfQuits += Time.deltaTime;
            if (currentTimeOfQuits >= timeOfQuits)
            {
                foreach (GameObject currentQuot in quots)
                {
                    currentQuot.SetActive(false);
                }
                currentTimeOfQuits = 0;
            }
        }
    }
    public void PlayQuot (int currentQuotToPlay){
        foreach (GameObject currentQuot in quots)
        {
            currentQuot.SetActive(false);
        }
        quots[currentQuotToPlay].SetActive(true);
        quotActive = true;
        currentTimeOfQuits = 0;
    }
}
