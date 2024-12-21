using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoving : MonoBehaviour
{
    public void Scenemoving(int index)
    {
        SceneManager.LoadScene(index);
    }
}
