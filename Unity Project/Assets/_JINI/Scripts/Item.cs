using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Item : MonoBehaviour
{
   
    //충돌처리 (아이탬과 플레이어)

    public float speed = 1.0f;

  
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
        Destroy(gameObject);
        if (collision.collider.name == "Player")
            collision.collider.GetComponent<PlayerMove>().ActiveMini();
    }
   
}
