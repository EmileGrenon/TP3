using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject UIText;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        StartCoroutine(UpdateTargetPosition());
    }
    
    IEnumerator UpdateTargetPosition()
    {
        while (true)
        {
            navMeshAgent.destination = targetTransform.position;
            yield return new WaitForSeconds(0.5f);
        }
    }
    void GameLost()
    {
        UIText.GetComponent<TextMeshProUGUI>().text = "Gameover";
        GameObject obj = UIText.transform.GetChild(0).gameObject;
        obj.GetComponent<TextMeshProUGUI>().text = $"temps survécue :\n{Mathf.RoundToInt(Time.time)} secondes";
        UIText.SetActive(true);
            
        Time.timeScale = 0f;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetTransform.gameObject)
            GameLost();
    }
}
