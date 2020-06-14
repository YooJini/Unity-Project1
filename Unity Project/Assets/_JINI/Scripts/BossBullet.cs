using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(collision.collider.name=="Player")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
