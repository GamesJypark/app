using System.Collections;
using UnityEngine;

public class Chat : MonoBehaviour
{
    private int Score;
    private float Move_Cycle_Max;
    private float Move_Cycle_Now = 100;
    public void Spawn(int Input_Score, float Input_Move_Cycle)
    {
        Chat chat = Instantiate(gameObject, new Vector2(5, -3), Quaternion.identity).GetComponent<Chat>();
        chat.Score = Input_Score;
        chat.Move_Cycle_Max = Input_Move_Cycle;
        chat.Move_Cycle_Now = Move_Cycle_Max;
        chat.StartCoroutine(Cycle());
    }
    IEnumerator Cycle()
    {
        while (true)
        {
            if (Move_Cycle_Now > 0)
            {
                yield return new WaitForSeconds(1);
                Move_Cycle_Now -= 1;
            }
            else
            {
                if (transform.position.y + 2 >= 5)
                {
                    Debug.Log("����!");
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 2);

                }
                Move_Cycle_Now = Move_Cycle_Max;
            }
        }
    }
    public void Hit()
    {
        Debug.Log("����!");
        GameSystem.gameSystem.ScoreUp(Score);
    }
}