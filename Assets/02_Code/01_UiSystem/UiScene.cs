using System.Collections.Generic;
using UnityEngine;

public class UiScene : MonoBehaviour
{
    public enum UIStatus
    {
        start,play,end
    }

    public UIStatus uista;

    public List<GameObject> pane;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (uista)
        {
            case UIStatus.start:
                break;
            case UIStatus.play:
        }
    }
}
