using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private EquipBase[] equipments;

    private bool haveEquipment;
    private bool equipedWithHammer, equipedWithGun, haveRadio;
    [SerializeField]
    private EquipBase equiped;
    private HUDController HUDControllerOnPlayer;
    private GameController gameControllerOnPlayer;

    [SerializeField]
    private GameObject[] drops;

    // Start is called before the first frame update
    void Start()
    {
        disableEquipments();
        HUDControllerOnPlayer = FindObjectOfType(typeof(HUDController)) as HUDController;
        gameControllerOnPlayer = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    private void PlayerInput()
    {
        if (Input.GetButtonDown("Fire1") && haveEquipment)
        {
            Action();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interaction();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }
    private void Interaction()
    {
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 positionToRaycast = startPosition;

        Ray rayshot = new Ray(positionToRaycast, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayshot, out hitInfo, 10))
        {
            Debug.Log(hitInfo.transform.name);
            Debug.DrawRay(startPosition, transform.forward);
            if (hitInfo.transform.tag == "Lantern")
            {
                hitInfo.transform.GetComponent<LanternBehaviour>().Light();
            }
            if (hitInfo.transform.tag == "Door")
            {
                hitInfo.transform.GetComponent<DoorBehaviour>().Door();
            }
            if (hitInfo.transform.tag == "SledgeHamer_Drop")
            {
                haveEquipment = true;
                equipedWithHammer = true;
                equiped = equipments[0];
                equiped.gameObject.SetActive(true);
                Destroy(hitInfo.transform.gameObject);
            }
            if (hitInfo.transform.tag == "Fita")
            {
                gameControllerOnPlayer.setTapes(1);
                gameControllerOnPlayer.updateProgess();
                Destroy(hitInfo.transform.gameObject);
            }
            if (hitInfo.transform.tag == "Radio")
            {
                haveRadio = true;
                Destroy(hitInfo.transform.gameObject);
            }
            if (hitInfo.transform.tag == "PositionRadio")
            {
                if (haveRadio)
                {
                    hitInfo.transform.GetComponent<RadioPosition>().RadioPositioned();
                    haveRadio = false;
                }
            }
            if (hitInfo.transform.tag == "PositionedRadio")
            {
                if (gameControllerOnPlayer.getTapes() == 12)
                {

                }
                else
                {
                    HUDControllerOnPlayer.PlayQuot(1);
                }
            }

        }
    }
    private void Action()
    {
        equiped.Action();
    }
    private void Drop()
    {
        haveEquipment = false;

        if (equipedWithHammer)
        {
            Instantiate(drops[0].gameObject, transform.position, transform.rotation);
            equipedWithHammer = false;
        }
        disableEquipments();
    }
    private void disableEquipments()
    {
        equiped = null;
        foreach (EquipBase currentEquip in equipments)
        {
            currentEquip.gameObject.SetActive(false);
        }
    }
}
    
