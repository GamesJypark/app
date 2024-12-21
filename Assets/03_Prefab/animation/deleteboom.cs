using UnityEngine;

public class deleteboom : MonoBehaviour
{
    public void spawns()
    {
        Instantiate(gameObject, new Vector2(6.6f, 2.46f), Quaternion.identity);
    }
    public void boomdestroy()
    {
        Destroy(gameObject);
    }
}
