using UnityEngine;

public class Chat : MonoBehaviour
{
    private int Score;
    private float Move_Cycle_Max;
    private float Move_Cycle_Now;
    private bool isMoved = false;
    public void Spawn(int Input_Score, float Input_Move_Cycle)
    {
        Chat chat = Instantiate(gameObject, new Vector2(5, -3), Quaternion.identity).GetComponent<Chat>();
        chat.Score = Input_Score;
        chat.Move_Cycle_Max = Input_Move_Cycle;
        chat.Move_Cycle_Now = Move_Cycle_Max;
        chat.isMoved = false;
        
    }
    private void Update()
    {
        if(Move_Cycle_Now > 0)
        {
            Move_Cycle_Now -= Time.deltaTime;
        }
        else
        {
            if(transform.position.y + 2 >= 5)
            {
                Debug.Log("����!");
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                if(isMoved == false)
                {
                    isMoved = true;
                    FindFirstObjectByType<TestSystem>().ChatSpawn();//�׽�Ʈ �ڵ�, ���߿� gameSystem���� �ٲ� ��.
                    Debug.Log("����");
                }
            }
            Move_Cycle_Now = Move_Cycle_Max;
        }
    }
    public void Hit()
    {
        Debug.Log("����!");
        GameSystem.gameSystem.ScoreUp(Score);
    }
}
