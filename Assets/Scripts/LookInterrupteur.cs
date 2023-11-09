using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInterrupteur : MonoBehaviour
{
    [SerializeField] LayerMask interruptorMask;
    [SerializeField] float lookDistance = 2.5f;
    [SerializeField] GameObject interactCanvas;

    void Update()
    {
        if (CheckIfLookInterruptor())
        {
            interactCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Okay");
            }
        }
        else
        {
            interactCanvas.SetActive(false);
        }
    }

    bool CheckIfLookInterruptor()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.forward, out hit, lookDistance, interruptorMask);
    }
}
