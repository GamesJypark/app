using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    public Chat[] chats; // 0ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ Ã¤ï¿½ï¿½, 1ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ Ã¤ï¿½ï¿½
    public Sprite[] BadChat_images;
    public Sprite[] GoodChat_images;
    public hpbarscript hpbarscript;
    public UiScene UI;
    public int Score = 0;
    private int Hp = 0;
    public float Timer = 0;
    private bool GameStart = false;
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
        GameStart = true;
        
        ChatSpawn();
    }
    public void ScoreUp(int Quantity)
    {
        Score += Quantity;
        Debug.Log("ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ : " + Score);
    }
    public void Fault(int Quantity)
    {
        Hp -= Quantity;
        hpbarscript.status = (hpbarscript.hpstatus)Hp-1;
        Debug.Log("ï¿½ï¿½ï¿½ï¿½ Ã¼ï¿½ï¿½ : " + Hp);
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
        if (GameStart)
        {
            hpbarscript = FindFirstObjectByType<hpbarscript>();
            UI = FindFirstObjectByType<UiScene>();
            Timer += Time.deltaTime;
            if(Hp <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    void OnEnable()
    {
        // ¾À ¸Å´ÏÀúÀÇ sceneLoaded¿¡ Ã¼ÀÎÀ» °Ç´Ù.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Ã¼ÀÎÀ» °É¾î¼­ ÀÌ ÇÔ¼ö´Â ¸Å ¾À¸¶´Ù È£ÃâµÈ´Ù.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "02_MainScene")
        {
            Hp = 4;
            

        }
        else
        {
            GameStart = false;
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
