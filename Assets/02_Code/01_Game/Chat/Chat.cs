using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public GameObject canvars;
    [SerializeField]private int Score;
    [SerializeField]private float Move_Cycle_Max;
    [SerializeField]private float Move_Cycle_Now;
    public void Spawn(int Input_Score, float Input_Move_Cycle)
    {
        Chat chat1 = Instantiate(gameObject).GetComponent<Chat>();
        chat1.transform.parent = canvars.transform;
        chat1.Score = Input_Score;
        chat1.Move_Cycle_Max = Input_Move_Cycle;
        chat1.Move_Cycle_Now = Input_Move_Cycle;
    }
    private void Start()
    {
        StartCoroutine(Cycle());
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
                    Debug.Log("실패!");
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 80);

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
