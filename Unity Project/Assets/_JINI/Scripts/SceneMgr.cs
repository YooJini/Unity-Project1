using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    //씬매니저 싱글톤 만들기
    //씬매니저는 시작, 게임, 종료씬 모두를 관리해야 한다.
    //또한 씬매니저는 씬이 변경되어도 삭제되면 안된다.

    public static SceneMgr instance;
    private void Awake()
    {
        //씬매니저가 존재한다면
        //새로 생성되는 씬매니저는 삭제하고 바로 빠져나와라
        if(instance)
        {
            //일반적인 Destroy는 메모리상에서 언제 삭제되는지 알 수 없음
            //DestroyImmediate는 즉시 삭제
            DestroyImmediate(gameObject);
            return;
        }
        //인스턴스가 없을 때
        instance = this;
        DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 게임오브젝트가 사라지지않음
    }

    public void LoadScene(string value)
    {
        SceneManager.LoadScene(value);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
