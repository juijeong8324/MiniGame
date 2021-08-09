using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dgo : MonoBehaviour
{
    public float speed = 0;


    // Update is called once per frame
    void Update()
    {
       transform.localPosition += Vector3.back * speed * Time.deltaTime;
        // 이 스크립트가 붙어있는 객체의 localPosition을 변경
        // 1초에 해당 speed만큼 앞으로 이동시켜줄 것임! 

    }

   
}
