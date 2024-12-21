using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiScene : MonoBehaviour
{
    public enum UIStatus
    {
        start,play,end
    }

    public UIStatus uista;

    public List<GameObject> pane;
    public Text playername;
    
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
                pane[0].SetActive(true);
                pane[1].SetActive(false);
                pane[2].SetActive(false);
                break;
            case UIStatus.play:
                pane[0].SetActive(false);
                pane[1].SetActive(true);
                pane[2].SetActive(true);
                break;
            case UIStatus.end:
                SceneManager.LoadScene("03_EndingScene");
            break;
        }
    }
}
