using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hoverscript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform button;
    public Text text;
    public float x;
    public float y;
    public int size;

    
    private void Start()
    {
        x = button.rect.width;
        y = button.rect.height;
        size = text.fontSize;
   
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       Debug.Log("adad");
        button.sizeDelta = new Vector2(x*1.5f, y*1.5f);
        text.fontSize = (int)(size * 1.5);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        button.sizeDelta = new Vector2(x, y);
        text.fontSize = size;
    }
}
