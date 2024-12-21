using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
    public RawImage display;
    WebCamTexture camTexture;
    private int currentIndex = 0;
    public bool isHit = false;
    public float blinkDuration = 2f;
    public float blinkInterval = 1f;
    public GameObject fliter;
    void Awake()
    {
        if (camTexture != null)
        {
            display.texture = null;
            camTexture.Stop();
            camTexture = null;
        }
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name);
        display.texture = camTexture;
        camTexture.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            StartCoroutine(BlinkEffect());
            isHit = false;
        }
        
    }


    private IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f;
  
        while (elapsedTime < blinkDuration)
        {
            fliter.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);

            fliter.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);

            elapsedTime += blinkInterval * 2; 
        }

        fliter.SetActive(false);

    }



    
    
}
