using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public GameObject _item;     
    public GameObject[] spawnPoints;    //스폰 위치 배열
    float spawnTime = 15.0f;             //스폰타임 (몇초에 한번씩 생성?)
    float curTime = 0.0f;               //누적타임



    // Update is called once per frame
    void Update()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        //몇초에 한번씩 이벤트 발동?
        //시간 누적타임으로 계산한다.
        //게임에서 정말 자주 사용함

        curTime += Time.deltaTime;
        if (curTime > spawnTime)
        {
            //누적된 현재시간을 0.0초로 초기화 (반드시 해줘야 함)
            curTime = 0.0f;
            //스폰타임을 랜덤으로
            spawnTime = Random.Range(10.0f, 20.0f);

            //아이템 생성
            GameObject item = Instantiate(_item);
            int index = Random.Range(0, spawnPoints.Length);
            item.transform.position = spawnPoints[index].transform.position;
        }
    }
}
