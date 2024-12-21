using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    public Chat[] chats; // 0이 좋은 채팅, 1이 나쁜 채팅
    public Sprite[] BadChat_images;
    public Sprite[] GoodChat_images;
    private int Score = 0;
    private int Fault_Score = 0;
    private float Max_Time = 0;
    private float Exist_Time = 0;
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
        Fault_Score = 0;
        Max_Time = 100;
        Exist_Time = 0;
        ChatSpawn();
    }
    public void ScoreUp(int Quantity)
    {
        Score += Quantity;
        Debug.Log("현재 점수 : " + Score);
    }
    public void Fault(int Quantity)
    {
        Fault_Score += Quantity;
        Debug.Log("현재 잘못 잡은 점수 : " + Fault_Score);
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameSet();
        }
    }
}
