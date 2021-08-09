using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDestroy : MonoBehaviour
{
    RightTiming RTimingManager; // 다른 부분 

    private void Start()
    {
        RTimingManager = GetComponent<RightTiming>(); //다른 부분 

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "RIGHTD")
        {
            try
            {

                RTimingManager.RightList.Remove(other.gameObject); // 해당 객체를 리스트에서 제거 시켜주자 여기는 각각 다르다!! 
            }
            catch (NullReferenceException ex) // 예외처리!! 안 넣어주면 아예 에러떠서 실행 안됨.. 근데 예외는 발생해도 없어지긴 한다?? 
            {
                //empty
            }

            if (other.gameObject != null)
            {
                ObjectPool.instance.LeftQueue.Enqueue(other.gameObject); // 여기도!!
                other.gameObject.SetActive(false);
                // 여기서 소멸 됨!!
            }

        }

    }
}
