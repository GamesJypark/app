using UnityEngine;
using UnityEngine.UI;
public class DeadLine : MonoBehaviour
{
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        image.GetComponent<RectTransform>().SetAsLastSibling();
    }
}
