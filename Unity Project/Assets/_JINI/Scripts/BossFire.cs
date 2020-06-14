using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    //보스 총알 발사 (총알 패턴)
    //1. 플레이어를 향해서 총알 발사
    //2. 회전총알 발사

    public GameObject _bullet;  //총알 프리팹
    public GameObject firePos;
    public GameObject target;

    public float fireTime = 1.0f;
    public float fireTime2 = 1.5f;
    float currTime = 0.0f;
    float currTime2 = 0.0f;

    public int bulletMax = 30;
    

    // Update is called once per frame
    void Update()
    {
        Fire1();
        Fire2();
    }

   
    //플레어어를 향해서 총알 발사
    private void Fire1()
    {
        //타겟이 없을 때 에러발생하니 예외처리
        if (target != null)
        {
            currTime += Time.deltaTime;

            if (currTime > fireTime)
            {
                currTime = 0.0f;
                //총알 공장에서 총알 생성            
                GameObject bullet = Instantiate(_bullet, firePos.transform.position, firePos.transform.rotation);
                //플레이어를 향하는 방향 구하기 (백터의 뺄셈)
                Vector3 dir = target.transform.position - firePos.transform.position;
                dir.Normalize();    //뺄셈연산시 노멀라이즈 해주기

                //총구의 방향도 맞춰준다(이게중요함)
                bullet.transform.up = dir;
            }
        }
    }

    //회전 총알 발사
    private void Fire2()
    {
        //타겟이 없을 때 에러발생하니 예외처리
        if (target != null)
        {
            currTime2 += Time.deltaTime;

            if (currTime2 > fireTime2)
            {
                //총알 최대 개수만큼
                for (int i = 0; i < bulletMax; i++)
                {
                    currTime2 = 0.0f;
                    //총알 공장에서 총알 생성            
                    GameObject bullet = Instantiate(_bullet, firePos.transform.position, firePos.transform.rotation);
                    //360도 방향으로 총알발사
                    float angle = 360.0f / bulletMax;
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
  
                }
            }
        }
    }

}
