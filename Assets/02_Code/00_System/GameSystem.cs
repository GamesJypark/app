using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
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
    }
    public void ScoreUp(int Quantity)
    {
        Score += Quantity;
    }
}
