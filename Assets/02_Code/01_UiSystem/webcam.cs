using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
       public RawImage webcamDisplay;
       public bool IsHit = false;
       private int i = 0;
    void Awake()
    {
        
        WebCamDevice[] devices = WebCamTexture.devices;
                if (devices.Length == 0)
                {
                    Debug.Log("카메라가 감지되지않았습니다.");
                    return;
                }
                else if(devices.Length>=1)
                {
                    
                }
        
                WebCamTexture webcamTexture = new WebCamTexture(devices[0].name);

                webcamDisplay.texture = webcamTexture;

                webcamTexture.Play();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
    }


   



    
    
}
