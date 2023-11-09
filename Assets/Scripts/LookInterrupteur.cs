using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInterrupteur : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject interrupteur;
    [SerializeField] GameObject ActivateUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
        {
            if (hit.collider.gameObject == interrupteur)
            {
                ActivateUI.SetActive(true);
            }
            else
            {
                ActivateUI.SetActive(false);
            }
        }
        else
        {
            ActivateUI.SetActive(false);
        }
    }
}
