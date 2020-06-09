using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            BgmMgr.instance.PlayBgm("bgm1");
        }
        if(Input.GetKeyDown("2"))
        {
            BgmMgr.instance.PlayBgm("bgm2");
        }
        if (Input.GetKeyDown("3"))
        {
            BgmMgr.instance.CrossFadeBGM("bgm1",3.0f);
        }
    }
}
