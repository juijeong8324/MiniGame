using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStartGame = false;

    [SerializeField] Animator ready;
    [SerializeField] Animator start;
    string ppang = "Ready";

    SoundDDong music;

    void Start()
    {
        music = FindObjectOfType<SoundDDong>();
        instance = this;
        Invoke("Delay", 1f);
        Invoke("Delay_first", 3f);
        Invoke("Delay_second", 4f); // 시간차를 주도록 한다!! 왜냐하면 Invoke는 동시에 호출되니까!! 
    }

    void Delay()
    {
        ready.SetTrigger(ppang); // 준비
    }

    void Delay_first()
    {
        start.SetTrigger(ppang); //시작

    }

    void Delay_second()
    {
        music.myAudio.Play(); //음악재생
        music.musicStart = true;

    }
    
}
