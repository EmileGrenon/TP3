using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int targetFrameRate = 60;

    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
}
