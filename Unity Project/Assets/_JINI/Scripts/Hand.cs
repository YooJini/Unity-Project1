using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Hand : MonoBehaviour
{
    CanvasGroup cg;
    float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if ((int)count % 2 == 0) cg.alpha = 0;
        else cg.alpha = 1;

    }
}
