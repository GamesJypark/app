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
    void Start()
    {
        
        WebCamDevice[] devices = WebCamTexture.devices;
                if (devices.Length == 0)
                {
                    Debug.Log("카메라가 감지되지않았습니다.");
                    return;
                }
        
                WebCamTexture webcamTexture = new WebCamTexture(devices[0].name);

                webcamDisplay.texture = webcamTexture;

                webcamTexture.Play();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (IsHit)
        {
            zerotored();
            IsHit = false;
        }
        
    }

    public void zerotored()
    {
     while (webcamDisplay.color.g > 179 && webcamDisplay.color.b > 179)
     {
         webcamDisplay.color = new Color(webcamDisplay.color.r, webcamDisplay.color.g - 0.002f, webcamDisplay.color.b-0.002f,webcamDisplay.color.a);
     }

     i += 1;
     if (i >= 8)
     {
         i = 0;
       
     }
     else
     {
         Invoke("redtozero",0.1f);
     }

    }

    public void redtozero()
    {
        Debug.Log("red to  zero" +
                  "");
        while (webcamDisplay.color.g < 255 && webcamDisplay.color.b<255)
        {
            webcamDisplay.color = new Color(webcamDisplay.color.r, webcamDisplay.color.g + 0.002f, webcamDisplay.color.b+0.002f,webcamDisplay.color.a);
        }
        i += 1;
        if (i >= 8)
        {
            i = 0;
        }
        else
        {
            Invoke("zerotored",0.1f);
        }
    
    }



    
    
}
