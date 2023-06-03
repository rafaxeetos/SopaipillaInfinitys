using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex = 0;
    
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCameraIndex)
                cameras[i].Priority = 10;
            else
                cameras[i].Priority = 1;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cameras[currentCameraIndex].Priority = 1;

            currentCameraIndex++;

            if (currentCameraIndex >= cameras.Length)
                currentCameraIndex = 0;

            cameras[currentCameraIndex].Priority = 10;
        }
    }
}
