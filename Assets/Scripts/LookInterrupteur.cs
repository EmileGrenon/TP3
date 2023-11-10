using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class LookInterrupteur : MonoBehaviour
{
    [SerializeField] LayerMask interruptorMask;
    [SerializeField] float lookDistance = 2.5f;
    [SerializeField] TextMeshProUGUI textPressUI;
    [SerializeField] Camera cam;
    [SerializeField] GameObject arch;
    [SerializeField] GameObject stickInterrupteur;
    [SerializeField] BakeUpdateMap bakeUpdateMap;

    bool isNotOn = true;
    bool archIsMoving = false;
    private void Awake()
    {
        textPressUI.text = "";
    }
    void Update()
    {
        if (CheckIfLookInterruptor())
        {
            if (!archIsMoving)
            {
                //archNavMeshObstacle.enabled = false;
                textPressUI.text = "Press E to activate";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Clique interrupteur");
                    if (isNotOn)
                    {
                        isNotOn = false;
                        StartCoroutine(BougerAnimationPontLevis(true));
                        stickInterrupteur.transform.Rotate(70, 0, 0);
                    }
                    else
                    {
                        isNotOn = true;
                        StartCoroutine(BougerAnimationPontLevis());
                        stickInterrupteur.transform.Rotate(-70, 0, 0);
                    }
                }     
            }
            else
            {
                //archNavMeshObstacle.enabled = false;
                textPressUI.text = "Bridge is actually moving";
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

    IEnumerator BougerAnimationPontLevis(bool monter = false)
    {
        archIsMoving = true;
        if (monter)
        {
            for (float i = 0; i > -50; i = i - 0.2f)
            {
                yield return new WaitForSeconds(0.12f);
                arch.transform.eulerAngles = new Vector3(0, 0, i);
                bakeUpdateMap.BuildNavMeshUpdate();
            }
        }
        else
        {
            for (float i = -50; i < 0; i = i + 0.2f)
            {
                yield return new WaitForSeconds(0.12f);
                arch.transform.eulerAngles = new Vector3(0, 0, i);
                bakeUpdateMap.BuildNavMeshUpdate();
            }
        }
        archIsMoving = false;
    }
}
