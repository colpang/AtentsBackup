using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Exam : MonoBehaviour
{
    string Name;    //캐릭터 이름
    public string NAME
    {
        get { return Name; }
        set { Name = value; }
    }
    int Age;        //캐릭터 나이
    public int AGE
    {
        get { return Age; }
        set { Age = value; }
    }
    int Gender;    //캐릭터 성별
    public int GENDER
    {
        get { return Gender; }
        set { Gender = value; }
    }
    int Level;      //캐릭터 레벨
    public int LEVEL
    {
        get { return Level; }
        set { Level = value; }
    }
    float Hp;       //캐릭터 체력
    public float HP
    {
        get { return Hp; }
        set { Hp = value; }
    }
    public void Attack()
    {
        Debug.Log("공격함수 출력");
    }
    public void Defence()
    {
        Debug.Log("방어함수 출력");
    }
    public void LevelUp(int _num)
    {
        LEVEL = _num;
        Debug.Log("Levelup 출력");
    }
    /// <summary>
    /// 변수 초기값 초기화
    /// Name=null, Age=0,Gender=0,Hp=0,Level=10
    /// </summary>
    public void init()
    {
        NAME = null;
        AGE = 0;
        GENDER = 0;
        HP = 0;
        LEVEL = 0;
    }

    float time;             //게임 시작 후 3초를 재는 실수 변수
    bool tmp;               //메세지가 출력되었는 지를 뜻하는 bool 변수
    /// <summary>
    /// 게임 시작 후 3초일 때 데이터를 출력하는 함수
    /// </summary>
    public void DataPrint()
    {
        if (time >= 3f && !tmp)
        {
            tmp = true;
            Debug.Log("이름은 = " + NAME + "입니다");
            Debug.Log("나이는 = " + AGE + "입니다");
            Debug.Log("성별은 = " + GENDER + "입니다");
            Debug.Log("레벨은 = " + LEVEL + "입니다");
            Debug.Log("체력은 = " + HP + "입니다");
        }
    }

    private void Awake()
    {
        //변수 초기화
        init();
        time = 0;
        tmp = false;
    }
    private void Start()
    {
        //인스턴스 생성 시 공격,방어,레벨업 함수 호출
        Debug.Log("인스턴스가 생성되었습니다");
        Attack();
        Defence();
        LevelUp(10);
    }
    void Update()
    {
        if (time <= 3f)
            time += Time.deltaTime;
        DataPrint();
    }
}
