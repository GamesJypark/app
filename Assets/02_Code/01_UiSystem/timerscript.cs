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
        if (Scene.uista == UiScene.UIStatus.play)
        {
            timer += Time.deltaTime;
            timertext.text =(int)timer + "초";
        }
      
    }
}
