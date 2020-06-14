using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MiniFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;
    float timer = 5.0f;

    private WaitForSeconds ws;

    private void Awake()
    {
        ws = new WaitForSeconds(0.3f);
    }
    private void Start()
    {
        timer = 5.0f;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(Fire());
    }
   
   

    IEnumerator Fire()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletFactory, firePoint.transform.position, firePoint.transform.rotation);

            yield return ws;
        }
    }
   
}
