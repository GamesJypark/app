using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbarscript : MonoBehaviour
{
    public List<GameObject> hpbar;
    public enum  hpstatus
    {
        one,two,three,four
    }

    public Text hp;
    public hpstatus status;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = hpstatus.four;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case hpstatus.four:
                hpbar[0].SetActive(false);
                hpbar[1].SetActive(false);
                hpbar[2].SetActive(false);
                hpbar[3].SetActive(true);
                hp.text = "hp : 1ms";
                break;
            case hpstatus.three:
                hpbar[0].SetActive(false);
                hpbar[1].SetActive(false);
                hpbar[2].SetActive(true);
                hpbar[3].SetActive(false);
                hp.text = "hp : 26ms";
                break;
            case hpstatus.two:
                hpbar[0].SetActive(false);
                hpbar[1].SetActive(true);
                hpbar[2].SetActive(false);
                hpbar[3].SetActive(false);
                hp.text = "hp : 51ms";
                break;
            case hpstatus.one:
                hpbar[0].SetActive(true);
                hpbar[1].SetActive(false);
                hpbar[2].SetActive(false);
                hpbar[3].SetActive(false);
                hp.text = "hp : 76ms";
                break;
        }
    }
}
