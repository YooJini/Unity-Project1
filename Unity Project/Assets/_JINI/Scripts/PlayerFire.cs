using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        //마우스 왼쪽 버튼 또는 왼쪽 컨트롤 키
        if(Input.GetButtonDown("Fire1")) //인풋 매니저에 만들어져 있음
        {
            //총알공장에서 총알을 무한대로 찍어낼 수 있다.
           GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
