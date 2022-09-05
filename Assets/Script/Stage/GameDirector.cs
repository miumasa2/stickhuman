using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameDirector : MonoBehaviour
{
    [SerializeField] UnityEvent GameOver;
    [SerializeField] UnityEvent Restart;
    [SerializeField] Text GameOverText;
    [SerializeField] Player ps;
    [SerializeField] GameObject cursor;
    private RectTransform crt;
    private Vector2 StartPosition;
    private GameObject Player;
    private HP hp;
    [SerializeField] GameObject ReStartButton = default;    // 最初から始めるボタン
    [SerializeField] GameObject TitleButton = default;      // タイトルに戻るボタン
    private string SaveFilePath;
    private AudioSource audioSource;
    [SerializeField] AudioSource pas;
    private bool pause = false, limiter = true;

    private void Start()
    {
        GameObject HP = GameObject.Find("H");
        hp = HP.GetComponent<HP>();
        Player = GameObject.Find("player");
        SaveFilePath = Application.dataPath + "/Savefile/savedata.json";
        audioSource = GetComponent<AudioSource>();
        crt = cursor.gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 6"))
        {
            if (audioSource.mute) 
            { 
            
                Time.timeScale = 1f;        // 時間再始動
                pause = false;
                audioSource.mute = false;
                pas.mute = false;
                ReStartButton.SetActive(false);
                cursor.SetActive(false);
                ps.enabled = true;
                PushReStartButton();
            
            }
          
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            Application.Quit();
        }
        if (pause)
        {
            float y = Input.GetAxisRaw("Vertical");

            if (y == 1)
            {
                if (limiter)
                {
                    if (crt.localPosition.y != -40)
                        crt.localPosition += new Vector3(0, 40, 0);
                    else
                        crt.localPosition = new Vector3(-50, -80, 0);
                    limiter = false;
                }
            }
            else if (y == -1)
            {
                if (limiter)
                {
                    if (crt.localPosition.y != -80)
                        crt.localPosition -= new Vector3(0, 40, 0);
                    else
                        crt.localPosition = new Vector3(-50, -40, 0);
                    limiter = false;
                }
            }
            else limiter = true;

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyUp("joystick button 1"))
            {
                switch (crt.localPosition.y)
                {
                    case -40:
                        PushReStartButton();
                        break;
                }

            }
        }
    }

    public void GameOvar()
    {
        audioSource.mute = true;
        Player.SetActive(false);
        GameOver.Invoke();
        GameOverText.enabled = true;        // ゲームオーバーテキストの表示
        Time.timeScale = 0f;                // 時間停止
        ReStartButton.SetActive(true);      // リスタートするボタンを表示
        TitleButton.SetActive(true);        // タイトルに戻るボタンを表示
    }

    public void Repop()
    {
        ps.startPlayer();
        ps.speedManager(1);
        Player.SetActive(true);
    }

    // リスタートボタンを押した時の処理
    public void PushReStartButton()
    {
        GameOverText.enabled = false;
        ReStartButton.SetActive(false);
        Time.timeScale = 1f;
        // Application.LoadLevel(0);
        Restart.Invoke();
        SceneManager.LoadScene("Stage1");
        Repop();
        hp.Cure(3);
    }
}


