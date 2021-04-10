using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDollyTrack : MonoBehaviour
{
    [SerializeField] GameObject nextPath;
    CinemachineVirtualCamera cam;
    CinemachineTrackedDolly cinemachineTrackedDolly;
    void Start()
    {
      cinemachineTrackedDolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
