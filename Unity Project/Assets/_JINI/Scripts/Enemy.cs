﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    //위에서 아래로 떨어지기만 한다 (똥피하기 느낌)
    //충돌처리 (에너미와 플레이어, 에너미와 플레이어 총알)

    public float speed = 10.0f;

    public GameObject fxFactory;

    // Update is called once per frame
    void Update()
    {
        //아래로 이동해라
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
        //아래로 이동해라
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자기자신도 없애고
        //충돌된 오브젝트도 없앤다.
        Destroy(collision.gameObject);
        Destroy(gameObject);

        //이펙트 보여주기
        ShowEffect();

        //점수 추가
        if (collision.gameObject.name.Contains("Bullet"))
        {
            Score.instance.AddScore();
        }
    }
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory, transform.position,transform.rotation);
    }
}
