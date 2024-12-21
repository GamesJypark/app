using UnityEngine;

public class TestSystem : MonoBehaviour
{
    public Chat chat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            chat.Spawn(1, 1f);
        }
    }
    public void ChatSpawn()
    {
        chat.Spawn(1, 1);
    }
}
