using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public Transform pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos.Translate(new Vector3(0.01f,0,0));
        if (pos.position.x>=22.9)
        {
            Debug.Log("ggood");
            pos.position = new Vector2(-12.8f,pos.position.y);
        }
    }
}
