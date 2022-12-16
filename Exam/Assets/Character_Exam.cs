using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Exam : MonoBehaviour
{
    string Name;    //ĳ���� �̸�
    public string NAME
    {
        get { return Name; }
        set { Name = value; }
    }
    int Age;        //ĳ���� ����
    public int AGE
    {
        get { return Age; }
        set { Age = value; }
    }
    int Gender;    //ĳ���� ����
    public int GENDER
    {
        get { return Gender; }
        set { Gender = value; }
    }
    int Level;      //ĳ���� ����
    public int LEVEL
    {
        get { return Level; }
        set { Level = value; }
    }
    float Hp;       //ĳ���� ü��
    public float HP
    {
        get { return Hp; }
        set { Hp = value; }
    }
    public void Attack()
    {
        Debug.Log("�����Լ� ���");
    }
    public void Defence()
    {
        Debug.Log("����Լ� ���");
    }
    public void LevelUp(int _num)
    {
        LEVEL = _num;
        Debug.Log("Levelup ���");
    }
    /// <summary>
    /// ���� �ʱⰪ �ʱ�ȭ
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

    float time;             //���� ���� �� 3�ʸ� ��� �Ǽ� ����
    bool tmp;               //�޼����� ��µǾ��� ���� ���ϴ� bool ����
    /// <summary>
    /// ���� ���� �� 3���� �� �����͸� ����ϴ� �Լ�
    /// </summary>
    public void DataPrint()
    {
        if (time >= 3f && !tmp)
        {
            tmp = true;
            Debug.Log("�̸��� = " + NAME + "�Դϴ�");
            Debug.Log("���̴� = " + AGE + "�Դϴ�");
            Debug.Log("������ = " + GENDER + "�Դϴ�");
            Debug.Log("������ = " + LEVEL + "�Դϴ�");
            Debug.Log("ü���� = " + HP + "�Դϴ�");
        }
    }

    private void Awake()
    {
        //���� �ʱ�ȭ
        init();
        time = 0;
        tmp = false;
    }
    private void Start()
    {
        //�ν��Ͻ� ���� �� ����,���,������ �Լ� ȣ��
        Debug.Log("�ν��Ͻ��� �����Ǿ����ϴ�");
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
