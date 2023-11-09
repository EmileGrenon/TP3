using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookInterrupteur : MonoBehaviour
{
    [SerializeField] LayerMask interruptorMask;
    [SerializeField] float lookDistance = 2.5f;
    [SerializeField] TextMeshProUGUI textPressUI;
    [SerializeField] Camera cam;
    [SerializeField] GameObject arch;
    [SerializeField] GameObject stickInterrupteur;

    private void Awake()
    {
        textPressUI.text = "";
    }
    void Update()
    {
        if (CheckIfLookInterruptor())
        {
            textPressUI.text = "Press E to activate";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Clique interrupteur");
                stickInterrupteur.transform.rotation = new Quaternion(35, 0, 0, 0);

            }
        }
        else
        {
            textPressUI.text = "";
        }
    }

    bool CheckIfLookInterruptor()
    {
        RaycastHit hit;
        return Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, lookDistance, interruptorMask);
    }
}
