using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]// 이 키워드가 있어야 이 객체를 Inspector창에서 볼 수 있다!! 
public class ObjectInfo // Pool정보 즉 객체 정보를 담는 클래스 
{
    public GameObject goPrefab;
    public int count; // 필요한 개수 
    public Transform tfPoolParent; // 위치 
}

public class ObjectPool : MonoBehaviour
{   
    //ObjectPool 자체가 언제 어디서든 사용할 수 있도록 인스턴스를 만들어버리자!
     public static ObjectPool instance; 

    // 객체의 정보를 담는 배열
    [SerializeField] ObjectInfo[] objectinfo;  

    // 이게 하나의 Pool이라고 생각하면 된다! 
    public Queue<GameObject> LeftQueue = new Queue<GameObject>();
    public Queue<GameObject> RightQueue = new Queue<GameObject>();
    public Queue<GameObject> UpQueue = new Queue<GameObject>();
    public Queue<GameObject> DownQueue = new Queue<GameObject>();


    void Start()
    {
        instance = this; // 자기자신을 대입해주장! 
        LeftQueue = InsertQueue(objectinfo[0]); // 먼저 배열 0번째만 있는 애를 넣어주자!
        RightQueue = InsertQueue(objectinfo[1]);
        UpQueue = InsertQueue(objectinfo[2]);
        DownQueue = InsertQueue(objectinfo[3]);
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectinfo) // 큐를 리턴시키는 함수 
    {
        Queue<GameObject> t_queue = new Queue<GameObject>(); // 임시 큐 

        for(int i=0; i <p_objectinfo.count; i++)
        {
            // 프리팹을 생성 이때 위치정보를 주기 위한 용도 
            GameObject t_clone = Instantiate(p_objectinfo.goPrefab, p_objectinfo.goPrefab.transform.position, p_objectinfo.goPrefab.transform.rotation);

            // 비활성화 시키자! 
            t_clone.SetActive(false);
            
            // 기존의 객체는 Left와 같은 최상위 객체가 부모였다!
            // 즉 그 부모객체가 존재하면 그 부모 객체 그대로 가고 
            if (p_objectinfo.tfPoolParent != null)  
                t_clone.transform.SetParent(p_objectinfo.tfPoolParent);
            else // 없으면 이 스크립트가 붙어있는 객체를 부모로 설정하도록 할 것임^^
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone); // 반복문이 돌고 나면 큐에는 카운트 개수 만큼 객체가 담겨있을 것이고
        }

        return t_queue; // 이 큐를 반환 
    }
}
