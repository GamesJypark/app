using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end_scene : MonoBehaviour
{

    public Text able;

    public Text time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        
    }

    void Start()
    {
        able.text = "처리한 악플 : " + GameSystem.gameSystem.Score.ToString() + "개";
        time.text = "방송 시간 : "+MathF.Round(GameSystem.gameSystem.Timer).ToString() + "초";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goback()
    {
        SceneManager.LoadScene("01_StartScene");
    }

    public void outback()
    {
        Application.Quit();
    }
}
