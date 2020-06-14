using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            if (GameObject.Find("Player"))
            {
                PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
                pf.bulletPool.Enqueue(other.gameObject);
            }
        }
        else
            Destroy(other.gameObject);
    }
}
