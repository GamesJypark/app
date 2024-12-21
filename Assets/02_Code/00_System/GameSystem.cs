using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    public Chat[] chats; // 0ÔøΩÔøΩ ÔøΩÔøΩÔøΩÔøΩ √§ÔøΩÔøΩ, 1ÔøΩÔøΩ ÔøΩÔøΩÔøΩÔøΩ √§ÔøΩÔøΩ
    public Sprite[] BadChat_images;
    public Sprite[] GoodChat_images;
    public hpbarscript hpbarscript;
    public UiScene UI;
    public int Score = 0;
    private int Hp = 0;
    public float Timer = 0;
    void Awake()
    {
        if(gameSystem == null)
        {
            gameSystem = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameSet()
    {
        Score = 0;
        Hp = 4;
        Timer = 0;
        ChatSpawn();
    }
    public void ScoreUp(int Quantity)
    {
        Score += Quantity;
        Debug.Log("ÔøΩÔøΩÔøΩÔøΩ ÔøΩÔøΩÔøΩÔøΩ : " + Score);
    }
    public void Fault(int Quantity)
    {
        Hp -= Quantity;
        hpbarscript.status = (hpbarscript.hpstatus)Hp-1;
        Debug.Log("ÔøΩÔøΩÔøΩÔøΩ √ºÔøΩÔøΩ : " + Hp);
    }
    public void ChatSpawn()
    {
        int i = Random.Range(0, 101);
        if(i > 90)
        {
            chats[1].Spawn(1, 1, BadChat_images[Random.Range(0, 4)]);
        }
        else
        {
            chats[0].Spawn(1, 1, GoodChat_images[Random.Range(0, 6)]);
        }
    }
    private void Update()
    {
        Timer += Time.deltaTime;
    }
    void OnEnable()
    {
        // æ¿ ∏≈¥œ¿˙¿« sceneLoadedø° √º¿Œ¿ª ∞«¥Ÿ.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // √º¿Œ¿ª ∞…æÓº≠ ¿Ã «‘ºˆ¥¬ ∏≈ æ¿∏∂¥Ÿ »£√‚µ»¥Ÿ.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "02_MainScene")
        {
            GameSet();
            hpbarscript = FindFirstObjectByType<hpbarscript>();
        }

        if (Hp <= 0)
        {
            if(UI != null)UI.uista = UiScene.UIStatus.end;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
