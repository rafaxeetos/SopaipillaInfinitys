using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex = 0;
    private MovimientoPlayer player1;
    private MovimientoPlayer2 player2;
    
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<MovimientoPlayer>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<MovimientoPlayer2>();

        UpdateCameraPriorities();
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

            UpdatePlayerMovement();
        }
    }
    
    private void UpdateCameraPriorities()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = (i == currentCameraIndex) ? 10 : 1;
        }

        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        bool player1CanMove = (currentCameraIndex == 0);
        bool player2CanMove = (currentCameraIndex == 1);

        player1.enabled = player1CanMove;
        player2.enabled = player2CanMove;
    }
    
    
}
