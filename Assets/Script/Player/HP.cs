using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    private GameDirector gm;
    private GameObject hp;
    int _hp = 3;

    void Start()
    {
        GameObject GameDirector = GameObject.Find("GameDirector");
        gm = GameDirector.GetComponent<GameDirector>();
    }

    void Update()
    {
        if (_hp == 0)
            gm.GameOvar();
    }

    public void Damage()
    {
        hp = transform.GetChild(--_hp).gameObject;
        hp.SetActive(false);

        /*Destroy(transform.GetChild(0).gameObject);
        if (this.transform.childCount == 1)
            gm.GameOvar();*/            
    }

    public void ollDamage()
    {
        while (_hp > 0)
        {
            hp = transform.GetChild(--_hp).gameObject;
            hp.SetActive(false);
        }
    }

    public void Cure(int h)
    {
        for(int _h = 0; h > _h; _h++)
        {
            hp = transform.GetChild(_h).gameObject;
            hp.SetActive(true);
        }
        _hp = 3;
    }
}
