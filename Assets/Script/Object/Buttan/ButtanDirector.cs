using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtanDirector : MonoBehaviour
{
    [SerializeField] int ButtansNumber = 3;
    private int bn, obn = 0,n = 0;
    private Buttan[] bs;
    [SerializeField] int Blue;
    [SerializeField] int Red;
    [SerializeField] int Yellow;
    private bool answer = true,Slide = false;
    [SerializeField] GameObject WallCore;
    private WallCore wc;

    void Start()
    {
        wc = WallCore.GetComponent<WallCore>();
        bs = new Buttan[ButtansNumber];
        foreach (Transform Buttans in this.gameObject.transform) {
            bs[n] = Buttans.gameObject.GetComponent<Buttan>();
            /*GameObject Buttan = this.gameObject.transform.GetChild(n).gameObject;
            bs = Buttan.GetComponent<Buttan>();*/
            n++;
        }
    }

    void Update()
    {
        if(Slide) wc.SlideUP();
    }

    public void ButtanNumberDirector(int color)
    {
        obn++;
        if (answer)
        {
            switch (color)
            {
                case 1:
                    if (obn != Blue) answer = false;
                    break;
                case 2:
                    if (obn != Red) answer = false;
                    break;
                case 3:
                    if (obn != Yellow) answer = false;
                    break;
                default:
                    Debug.Log("ButtanColorError");
                    break;
            }
        }
        if (ButtansNumber == obn) {
            if (answer) Slide = true;
            else
            {
                Coroutine coroutine = StartCoroutine("DelayResetMethod", 1.5f);
            }
        }
    }

    private IEnumerator DelayResetMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (n = 0; n < obn; n++)
            bs[n].Reset();
        obn = 0;
        answer = true;
    }
}
