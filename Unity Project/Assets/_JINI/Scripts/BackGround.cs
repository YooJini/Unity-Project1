using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Material mat;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //머티리얼은 렌더러 컴포넌트안에 속성으로 붙어있다.
        mat = GetComponent<MeshRenderer>().material;
        //mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundScroll();
    }

    private void BackGroundScroll()
    {
        //아래와 같은걸 캐스팅이라고 한다
        //transform.position 조정할 때의 방법과 동일

        //머티리얼의 메인텍스처 오프셋은 Vector2로 만들어져 있다
        Vector2 offset = mat.mainTextureOffset;
        //offset.y의 값만 보정해주면 된다 
        offset.Set(0, offset.y + (speed * Time.deltaTime));
        //다시 머티리얼 오프셋에 담는다
        mat.mainTextureOffset = offset;
    }
}
