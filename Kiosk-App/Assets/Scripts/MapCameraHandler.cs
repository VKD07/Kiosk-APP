using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraHandler : MonoBehaviour
{
    [SerializeField] Transform mapCamera;
    [SerializeField] Transform[] levelPositions;
    [SerializeField] Navigator navigatorManager;
  
    void Update()
    {
        TransferCameras();
    }

    private void TransferCameras()
    {
        if (navigatorManager.StairsReached)
        {
            mapCamera.position = new Vector3(mapCamera.position.x, mapCamera.position.y, levelPositions[1].position.z);
        }
        else
        {
            mapCamera.position = new Vector3(mapCamera.position.x, mapCamera.position.y, levelPositions[0].position.z);
        }
    }
}
