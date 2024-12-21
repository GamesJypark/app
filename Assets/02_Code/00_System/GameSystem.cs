using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem gameSystem = null;
    public Chat[] chats; // 0�� ���� ä��, 1�� ���� ä��
    public Sprite[] BadChat_images;
    public Sprite[] GoodChat_images;
    public hpbarscript hpbarscript;
    public UiScene UI;
    public int Score = 0;
    public int Hp = 0;
    public float Timer = 0;
    private bool GameStart = false;
    public bool isBossExist = false;
    void Awake()
    {
        if(gameSystem == null)
        {
            gameSystem = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameSet()
    {
        Score = 0;
        Hp = 4;
        Timer = 0;
        GameStart = true;
        isBossExist = false;
        ChatSpawn();
    }
    public void ScoreUp(int Quantity)
    {
        Score += Quantity;
        Debug.Log("���� ���� : " + Score);
    }
    public void Fault(int Quantity)
    {
        Hp -= Quantity;
        hpbarscript.status = (hpbarscript.hpstatus)Hp-1;
        Debug.Log("���� ü�� : " + Hp);
    }
    public void BossAdvent()
    {
        isBossExist = true;
        Debug.Log("보스등장");

    }
    public void BossDead()
    {
        isBossExist = false;
        Debug.Log("보스퇴장");
    }
    public void ChatSpawn()
    {
        int i = Random.Range(0, 101);
        if(i > 85 && i <= 95)
        {
            chats[1].Spawn(1, 1, BadChat_images[Random.Range(0, 4)]);
        }
        else if(i > 95 && i <= 99)
        {

            chats[2].Spawn(1, 1, BadChat_images[Random.Range(0, 4)]);
        }
        else if(i == 100)
        {
            if (isBossExist == false)
            {
                chats[3].Spawn(1, 1, BadChat_images[Random.Range(0, 4)]);
                BossAdvent();
            }
            else
            {
                Debug.Log("이미 보스 있어서 깜빡이는 애가 대신 나옴");
                chats[2].Spawn(1, 1, BadChat_images[Random.Range(0, 4)]);
            }
        }
        else
        {
            chats[0].Spawn(1, 1, GoodChat_images[Random.Range(0, 6)]);
        }
    }
    private void Update()
    {
        if (GameStart)
        {
            hpbarscript = FindFirstObjectByType<hpbarscript>();
            UI = FindFirstObjectByType<UiScene>();
            Timer += Time.deltaTime;
            if(Hp <= 0)
            {
                SceneManager.LoadScene(2);
            }
            if(Hp >= 3 && SoundManager.soundManager.audioSource.clip != SoundManager.soundManager.audioClips[2])
            {
                SoundManager.soundManager.audioSource.clip = SoundManager.soundManager.audioClips[2];
                SoundManager.soundManager.audioSource.Play();
            }
            else if(Hp <= 2 && SoundManager.soundManager.audioSource.clip != SoundManager.soundManager.audioClips[3])
            {
                SoundManager.soundManager.audioSource.clip = SoundManager.soundManager.audioClips[3];
                SoundManager.soundManager.audioSource.Play();
            }
        }
    }
    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "02_MainScene")
        {
            Hp = 4;
            

        }
        else
        {
            GameStart = false;
        }

        if (Hp <= 0)
        {
            if(UI != null)UI.uista = UiScene.UIStatus.end;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
