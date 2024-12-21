using System.Collections;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField]private int Score;
    [SerializeField]private float Move_Cycle_Max;
    [SerializeField]private float Move_Cycle_Now;
    public void Spawn(int Input_Score, float Input_Move_Cycle)
    {
        Chat chat = Instantiate(gameObject, new Vector2(5, -3), Quaternion.identity).GetComponent<Chat>();
        chat.Score = Input_Score;
        chat.Move_Cycle_Max = Input_Move_Cycle;
        chat.Move_Cycle_Now = Input_Move_Cycle;
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
                Debug.Log(Move_Cycle_Now);
            }
            else
            {
                if (transform.position.y + 2 >= 5)
                {
                    Debug.Log("실패!");
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
        Debug.Log("성공!");
        GameSystem.gameSystem.ScoreUp(Score);
    }
}
