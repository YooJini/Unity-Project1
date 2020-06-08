using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    public Text scoreTxt;
    public Text highScoreTxt;
    //public TextMeshProUGUI textTxt //텍스트메시프로 텍스트 사용시

    //스코어매니저 싱글톤 만들기 (간단하게)
    public static Score instance;
    private void Awake() => instance = this;

    // public static Score instance = null;

    // private void Awake()
    // {
    //     if(instance==null)
    //     {
    //         instance = this;
    //     }
    //     else if(instance!=this)
    //     {
    //         Destroy(this.gameObject);
    //     }
    //
    //     LoadGameData();
    // }
    //
    //게임의 초기 데이터 로드

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("score");
        highScoreTxt.text = "HighScore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //하이스코어
        SaveHighScore();    
    }

    private void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("score", highScore);
            highScoreTxt.text = "HighScore: " + highScore;
        }
    }

    //점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        scoreTxt.text ="Score: " + score;
    }
}
