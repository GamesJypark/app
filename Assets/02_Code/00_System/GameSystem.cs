using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    public Chat[] chats; // 0�� ���� ä��, 1�� ���� ä��
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
        Debug.Log("���� ���� : " + Score);
    }
    public void Fault(int Quantity)
    {
        Hp -= Quantity;
        hpbarscript.status = (hpbarscript.hpstatus)Hp-1;
        Debug.Log("���� ü�� : " + Hp);
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameSet();
        }

        if (Hp <= 0)
        {
            UI.uista = UiScene.UIStatus.end;
        }
    }
}
