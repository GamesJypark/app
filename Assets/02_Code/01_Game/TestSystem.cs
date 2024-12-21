using UnityEngine;

public class TestSystem : MonoBehaviour
{
    public Chat chat;
    public Sprite[] images;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            chat.Spawn(1, 1f, images[Random.Range(0, 5)]);
        }
    }
    public void ChatSpawn()
    {
        chat.Spawn(1, 1, images[Random.Range(0, 5)]);
    }
}
