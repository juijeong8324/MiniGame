using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float totalTime;
    public float fillAmount = 1;
    public Image myImage = null;
    SoundDDong song;

    private void Start()
    {
        song = FindObjectOfType<SoundDDong>();
    }

    void Update()
    {
        if(song.musicStart) // 음악이 재생될 때 줄어들기 
        {
            if (fillAmount > 0)
            {
                       
                fillAmount = fillAmount - (Time.deltaTime / (totalTime - 1)); 
                // Time.deltaTime =  한 프레임 당 실행 시간 / fillAmount는 0에서 1사이의 값이기 때문에 분모에 Time.deltaTime이 존재!!    
                myImage.fillAmount = fillAmount;
           
            }

        }
        
    }
}
