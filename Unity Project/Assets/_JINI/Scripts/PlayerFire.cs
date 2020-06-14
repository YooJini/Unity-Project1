using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;

    //레이저를 발사하기 위해서는 라인렌더러가 필요하다.
    //선은 최소 2개의 점이 필요하다 (시작점, 끝점)

    LineRenderer lr;    //라인렌더러 컴포넌트

    public float rayTime = 3.0f;
    private float timer = 0.0f;

    //사운드 재생
    AudioSource _audio;


    //오브젝트 풀링
    //오브젝트 풀링에 사용할 최대 총알 개수
    int poolSize = 20;

    //1. 배열
    //GameObject[] bulletPool;

    //2. 리스트
    //public List<GameObject> bulletPool;

    //3. 큐
    public Queue<GameObject> bulletPool;

    RaycastHit hit;

    //레이저 버튼
    public Button laserBtn;

    public GameObject laserEffect;
    // Start is called before the first frame update
    void Start()
    {
        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();

        //중요!!!
        //게임오브젝트는 활성화/비활성화 => SetActive() 함수 사용
        //컴포넌트는 enabled 속성 사용

        _audio = GetComponent<AudioSource>();

        //오브젝트 풀링 초기화
        InitObjectPooling();
    }

    private void InitObjectPooling()
    {
        // //1. 배열
        // bulletPool = new GameObject[poolSize];
        // for(int i=0; i<poolSize;i++)
        // {
        //     GameObject bullet = Instantiate(bulletFactory);
        //     bullet.SetActive(false);
        //     bulletPool[i] = bullet;
        // }

        //2. 리스트
        //bulletPool = new List<GameObject>();
        //for(int i = 0;i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool.Add(bullet);
        //}

        //3. 큐
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        //FireRay();

        if (lr.enabled)
        {
            Vector3 pos = transform.position + Vector3.up * 0.5f;
            lr.SetPosition(0, pos);
            lr.SetPosition(1, pos + Vector3.up * 9);

            if (Physics.Raycast(transform.position, Vector3.up, out hit))
            {   
               
                //디스트로이존의 탑을 제외한 충돌오브젝트 모두 지우기               
                if (hit.collider.name != "Top")
                {   //레이저의 끝점 지정
                    lr.SetPosition(1, hit.point);
                    if (hit.collider.name.Contains("Enemy"))
                    {
                        Score.instance.AddScore();
                        GameObject effect = Instantiate(laserEffect,hit.collider.transform);
                        Destroy(hit.collider.gameObject, 0.2f);

                    }
                }
               
            }
            timer += Time.deltaTime;
            if (timer > rayTime)
            {
                lr.enabled = false;
                timer = 0.0f;
            }
        }

        if (laserBtn.image.fillAmount == 1.0f) laserBtn.interactable = true;
        else
        { 
            laserBtn.interactable = false;
            laserBtn.image.fillAmount += 0.1f * Time.deltaTime;
        }

    }

    
    //총알 발사 함수
    public void Fire()
   {
       
         
            //1. 배열 오브젝트 풀링으로 총알발사
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;
            //fireIndex++;
            //if (fireIndex > poolSize) fireIndex = 0;

            //2. 리스트 오브젝트풀링으로 총알 발사
            //bulletPool[fireIndex].setActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;
            //fireIndex++;
            //if (fireIndex >= poolSize) fireIndex = 0;

            //3. 리스트 오브젝트풀링으로 총알 발사 (진짜 오브젝트 풀링)
            //if(bulletPool.Count>0)
            //{
            //    GameObject bullet = bulletPool[0];
            //    bullet.SetActive(true);
            //    bullet.transform.position = firePoint.transform.position;
            //    bullet.transform.up = firePoint.transform.up;
            //    //오브젝트 풀에서 빼준다
            //    bulletPool.Remove(bullet);
            //}
            //else//오브젝트 풀이 비어서 총알이 하나도 없으니 풀크기를 늘려준다
            //{
            //    GameObject bullet = Instantiate(bulletFactory);
            //    bullet.SetActive(false);
            //    //오브젝트 풀에 추가한다
            //    bulletPool.Add(bullet);
            //}
            
            //4. 큐 오브젝트풀링 사용하기
            if(bulletPool.Count>0)
            {
                GameObject bullet = bulletPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.up = firePoint.transform.up;
            }
            else
            {
                //총알오브젝트 생성
                GameObject bullet = Instantiate(bulletFactory);
                bullet.SetActive(false);
                //생성된 총알 오브젝트를 풀에 담는다
                bulletPool.Enqueue(bullet);
            }

            //총알공장에서 총알을 무한대로 찍어낼 수 있다.
            //GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);
   }
    


   //레이저 발사 함수
    public void FireRay()
    {

            //레이저 사운드 재생
            _audio.Play();

            lr.enabled = true;
            //라인 시작점, 끝점
            //Vector3 pos = transform.position + Vector3.up*0.5f;
            //lr.SetPosition(0, pos);
            //lr.SetPosition(1, pos + Vector3.up*10);


    }

    //총알발사 버튼을 눌렀을 때
    public void OnFireButtonClick()
    {
        Fire();
        //총알공장에서 총알을 무한대로 찍어낼 수 있다.
        //GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);
    }

    //레이저발사 버튼을 눌렀을 때
    public void OnLaserButtonClick()
    {
        FireRay();
        laserBtn.image.fillAmount = 0.0f;
    }
}
