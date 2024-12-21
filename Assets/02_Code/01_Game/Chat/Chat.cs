using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField]private int Score;
    [SerializeField]private float Move_Cycle_Max;
    [SerializeField]private float Move_Cycle_Now;
    public void Spawn(int Input_Score, float Input_Move_Cycle, Sprite sprite)
    {
        Chat chat1 = Instantiate(gameObject).GetComponent<Chat>();
        chat1.GetComponent<Image>().sprite = sprite;
        chat1.transform.SetParent(FindFirstObjectByType<Canvas>().transform, false);
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
                if (gameObject.GetComponent<RectTransform>().anchoredPosition.y + 90 > 400)
                {
                    Debug.Log("실패!");
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 90);

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
