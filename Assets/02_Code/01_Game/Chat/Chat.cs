using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Chat : MonoBehaviour
{
    [SerializeField]private int Score;
    [SerializeField]private float Speed;
    [SerializeField] private bool isMoved = false;
    public void Spawn(int Input_Score, float Input_Soeed, Sprite sprite)
    {
        Chat chat1 = Instantiate(gameObject).GetComponent<Chat>();
        chat1.GetComponent<Image>().sprite = sprite;
        chat1.transform.SetParent(GameObject.Find("Content").transform, false);
        chat1.Score = Input_Score;
        chat1.Speed = Input_Soeed;
        chat1.isMoved = false;
    }
    private void Update()
    {
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y > 490)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + Time.deltaTime * 100 * Speed);
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.y >= -400 && isMoved == false)
            {
                isMoved = true;
                GameSystem.gameSystem.ChatSpawn();
            }
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.y >= 220 && gameObject.GetComponent<RectTransform>().anchoredPosition.y <= 330)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if (gameObject.tag == "Bad")
                    {
                        GameSystem.gameSystem.ScoreUp(Score);
                    }
                    if(gameObject.tag == "Good")
                    {
                        GameSystem.gameSystem.Fault(Score);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
