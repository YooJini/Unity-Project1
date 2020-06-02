using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;

    private WaitForSeconds ws;

    private void Awake()
    {
        ws = new WaitForSeconds(0.3f);
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
