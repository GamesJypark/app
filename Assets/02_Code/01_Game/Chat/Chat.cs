using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public GameObject boom;
    [SerializeField]private int Score;
    [SerializeField]private float Speed;
    [SerializeField] private bool isMoved = false;
    public void Spawn(int Input_Score, float Input_Speed, Sprite sprite)
    {
        Chat chat1 = Instantiate(gameObject).GetComponent<Chat>();
        chat1.GetComponent<Image>().sprite = sprite;
        if (GameObject.Find("Content") != null) chat1.transform.SetParent(GameObject.Find("Content").transform, false);
        chat1.Score = Input_Score;
        chat1.Speed = Input_Speed;
        chat1.isMoved = false;
    }
    private void Update()
    {
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y > 490)
        {
            if(gameObject.tag == "Bad")
            {
                GameSystem.gameSystem.Fault(Score);
            }
            Destroy(gameObject);
        }
        else
        {
            if (GameSystem.gameSystem.isBossExist) Speed = 2;
            else if (Speed < 7) Speed = 2 + Mathf.Pow(2, GameSystem.gameSystem.Timer / 10);
            else Speed = 7;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + Time.deltaTime * 100 * Speed);
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.y >= -310 && isMoved == false)
            {
                isMoved = true;
                GameSystem.gameSystem.ChatSpawn();
            }
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.y >= 215 && gameObject.GetComponent<RectTransform>().anchoredPosition.y <= 315)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    boom.GetComponent<deleteboom>().spawns();
                    if (gameObject.tag != "Boss")
                    {
                        if (gameObject.tag == "Bad")
                        {
                            GameSystem.gameSystem.ScoreUp(Score);
                        }
                        if (gameObject.tag == "Good")
                        {
                            GameSystem.gameSystem.Fault(Score);
                        }
                        Destroy(gameObject);
                    }
                    else
                    {
                        gameObject.GetComponent<Boss_Chat>().hurt();
                    }
                }
            }
        }
    }
}
