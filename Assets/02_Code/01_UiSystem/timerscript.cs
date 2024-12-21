using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour
{
    public Text timertext;
    private float timer;
    public UiScene Scene;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            timertext.text =(int)timer + "초";
    }
}
