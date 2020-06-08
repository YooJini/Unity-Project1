using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 margin; //뷰포트좌표는 0.0f~1.0f사이의 값

    //조이스틱 사용하기
    public VariableJoystick joyStick;

    public Transform[] mini;

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
        mini = gameObject.GetComponentsInChildren<Transform>(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
      
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform go in mini)
            {
                go.gameObject.SetActive(true);
            }
        }
       
    }

    //플레이어 이동 함수
    private void Move() // alt + Enter , Enter
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //조이스틱 사용하기
        //키보드가 안눌렸을 때 => 조이스틱 사용하면 된다
        if(h == 0 && v == 0)
        {
            h = joyStick.Horizontal;
            v = joyStick.Vertical;
        }

        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime,0);

        Vector3 dir = h * Vector3.right + v * Vector3.up; //Vector3 dir = new Vector3(h, v, 0);
        //dir.Normalize(); ->티 안남
        transform.Translate(dir * speed * Time.deltaTime);

        //위치 = 현재위치 + (방향*시간)
        //P = P0 +vt;
        //transform.position = transform.position + (dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;

        MoveInScreen();
    }

    //플레이어가 화면밖으로 나가지 못하게 하는 함수
    private void MoveInScreen()
    {
        //방법은 크게 3가지
        //1. 화면밖의 공간에 큐브 4개 만들어서 배치
        //리지드바디의 충돌체로 이동 못하게 막기

        //2. 플레이어의 포지션으로 이동처리
        //캐스팅: 트랜스폼의 포지션 값을 Vector3 변수로 만든 후 접근, 계산 후 다시 대입하는 과정
        //Vector3 position = transform.position; 
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        //position.y = Mathf.Clamp(position.y, -2.5f, 2.5f);
        //transform.position = position;

        //3. 메인카메라의 뷰포트를 가져와서 처리한다
        //스크린좌표: 좌측하단(0,0), 우측상단(maxX, maxY)
        //뷰포트좌표: 좌측하단(0,0), 우측상단(1.0f,1.0f)
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f+margin.x, 1.0f-margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f+margin.y, 1.0f-margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

       ////내가 만들어본 거
       //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
       //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
       //
       //Vector3 position = transform.position;
       //position.x = Mathf.Clamp(position.x, min.x + 0.5f, max.x - 0.5f);
       //position.y = Mathf.Clamp(position.y, min.y + 0.5f, max.y - 0.5f);
       //transform.position = position;
    }
}
