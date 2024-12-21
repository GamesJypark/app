using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
       public RawImage webcamDisplay;
 
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
    }
}
