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
    public Text web;
    public List<GameObject> pane;
    public Text playername;
    public InputField playerNameInput;
    public string player;
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
                
                    InputName();
                
                break;
            case UIStatus.play:
                pane[0].SetActive(false);
                pane[1].SetActive(true);
                playername.text = player;
                
                web.text = Random.Range(1, 100).ToString();
                break;
            case UIStatus.end:
                SceneManager.LoadScene("03_EndingScene");
            break;
        }
    }

    public void starttoplay()
    {
        print("2ws");
        uista = UIStatus.play;
        playername.text = player;
    }

    public void InputName()
    {
        player = playerNameInput.text;
    }
}
