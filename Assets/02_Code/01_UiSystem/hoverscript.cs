using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hoverscript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform button;
    public Text text;
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        button.sizeDelta = new Vector2(294, 76);
        text.fontSize = 36;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        button.sizeDelta = new Vector2(196, 51);
        text.fontSize = 24;
    }
}
