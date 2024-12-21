using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Boss_Chat : MonoBehaviour
{
    private int hp;
    private void Start()
    {
        hp = 3;
    }
    public void hurt()
    {
        
        hp -= 1;
        Debug.Log("보스 피해 입음 남은 체력 : " + hp);
        if (hp <= 0)
        {
            GameSystem.gameSystem.ScoreUp(3);
            GameSystem.gameSystem.BossDead();
            Destroy(gameObject);
        }
    }
}
