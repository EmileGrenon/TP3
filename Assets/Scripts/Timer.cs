using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    WaitForSeconds waitTime = new WaitForSeconds(1f);
    TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        int i = 0;
        while(true)
        {

            tmp.text = "Time : " + i++;
            yield return waitTime;
        }
    }
}
