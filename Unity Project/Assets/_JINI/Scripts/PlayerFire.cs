using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;

    //레이저를 발사하기 위해서는 라인렌더러가 필요하다.
    //선은 최소 2개의 점이 필요하다 (시작점, 끝점)

    LineRenderer lr;    //라인렌더러 컴포넌트

    public float rayTime = 1.0f;
    private float timer = 0.0f;

    //사운드 재생
    AudioSource _audio;

    RaycastHit hit;
   
    // Start is called before the first frame update
    void Start()
    {
        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();

        //중요!!!
        //게임오브젝트는 활성화/비활성화 => SetActive() 함수 사용
        //컴포넌트는 enabled 속성 사용

        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // Fire();
        FireRay();

    }

   //총알 발사 함수
   public void Fire()
   {
       
         //마우스 왼쪽 버튼 또는 왼쪽 컨트롤 키
         if(Input.GetButtonDown("Fire1")) //인풋 매니저에 만들어져 있음
         {
             //총알공장에서 총알을 무한대로 찍어낼 수 있다.
            GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);
         }
    }


   //레이저 발사 함수
    public void FireRay()
    {
     
        if(Input.GetButtonDown("Fire1"))
        {
            //레이저 사운드 재생
            _audio.Play();

            lr.enabled = true;
            //라인 시작점, 끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, pos);
            lr.SetPosition(1, pos + Vector3.up * 10);
            if (Physics.Raycast(transform.position, Vector3.up, out hit))
            {
               //레이저의 끝점 지정
                lr.SetPosition(1, hit.point);
               //디스트로이존의 탑을 제외한 충돌오브젝트 모두 지우기               
               if (hit.collider.name != "Top")
                {
                    Destroy(hit.collider.gameObject);
                }
               //name.Contains("") -> 해당 문자열을 포함하냐

            }

        }
        if(lr.enabled)
        {
            timer += Time.deltaTime;
            if(timer>rayTime)
            {
                lr.enabled = false;
                timer = 0.0f;
            }
        }
    }

    public void OnFireButtonClick()
    {
        //총알공장에서 총알을 무한대로 찍어낼 수 있다.
        GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);
    }
}
