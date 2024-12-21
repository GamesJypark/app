using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    private int Score;
    private int Fault_Score;
    private float Max_Time;
    private float Exist_Time;
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
    }
}
