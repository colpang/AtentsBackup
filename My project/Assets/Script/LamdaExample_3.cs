using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
 �븮��(delegate)
 c���� �Լ��������� ����� ����
 �Լ��� �븮 ������ ������ �� �ֵ��� ����
 �Լ��� �����Ͽ� ����� �� �ִ�.
 �����ϴ� �Լ��� �븮���� ���ǿ� ���ϰ�, �Ű������� Ÿ�԰� ������ �¾ƾ� �Ѵ�.
 �븮�ڴ� �Լ��� ������ �� �ִ� �ڷ���
 */
/*
 Lamda ��
 �ڹٿ����� ���� �޼����� Ī��
 => �����ڸ� ���
 => ������ �Ű������� �ǹ�, �������� ���̳� �� �ڵ���� �ǹ�
    ���ٽĿ����� �Ű������� ������ �� ���������� ������� �ʾƵ� �ȴ�.
    �� ���ٿ����� �������� ����
�Ű������� ���� �Ķ���
()=>x*x; (�Ķ���)

�Ű������� �ִ� �Ķ���
(x)=>x*x;

�Ű������� ���� �� ����
() => { };

�Ű������� �ִ� �� ����
(x) => { };
 */

public delegate void Do();
public delegate int Doi();
public class LamdaExample_3 : MonoBehaviour
{
    float elapsed;
    Do doSomthing;  // Do�� ���� doSomething�� ����
    Do doChain;  // Do�� ���� doSomething�� ����
    Do doBlink;
    Doi doiSomthing;
    /*
        Action�̶�?
        ���̺귯������ �����ϴ� delegate
        �Ѱ��� �Ű������� ��ȯ������ ���� delegate
        Action<�Ű��������ڷ���>
    */
    Action<float> act2;

    /*
     Func��?
     ���̺귯������ �����ϴ� delegate
     �Ű������� ��ȯ������ ����, 
     Func<T, TResult> : T�� �Ű�����, TResult�� ��ȯ����
     Func<TResult>  : �Ű������� ����, TResult�� ��ȯ����
     */
    Func<bool> funcB;
    Func<Do, bool> funcC;
    //����
    //funcB�� ������ �� �ִ� �Լ��� �����Ͻÿ�.
    //funcC�� ������ �� �ִ� �Լ��� �����Ͻÿ�.
    public bool FuncTest()
    {
        return true;
    }
    public void ActionFunction(float _data)
    {
        Debug.Log(_data);
    }
    public void A()
    {
        Debug.Log("A");
        doBlink = B;
    }
    public void B()
    {
        Debug.Log("B");
        doBlink = A;
    }
    public void DisplayData()
    {
        Debug.Log("DisplayData");
    }
    void Start()
    {
        doChain += A;
        doChain += B;
        doChain();  // A�Լ� ȣ���Ŀ� B�Լ� ȣ��

        doChain -= B;
        doChain -= A;

        doSomthing = DisplayData;
        doSomthing();
        doSomthing = () => { 
            Debug.Log("���ٸ� �̿��� �Լ�����"); 
        };
        doSomthing();
        doiSomthing = () => 20 * 20;    // 20 * 20�� �������� ��ȯ�ϱ� ������ �븮���� ��ȯ������ int�̾�߸� �Ѵ�.
        Debug.Log(doiSomthing());
        //
        DoAction(() =>
        {
            Debug.Log("DoAction�Լ��� �Ű������� ����");
        });
        DoAction(DisplayData);
        //
        // Action ���
        act2 = ActionFunction;
        act2(100f);
        //
        // Func ���
        funcB = FuncTest;
        Debug.Log(funcB());
        //
        // 1�ʸ��� �ѹ��� A�Լ��� B�Լ��� �����Ƽ� ȣ��
        elapsed = 1f;
        doBlink = A;
    }
    /*
     * �Լ��� �Ű������� ����
     */
    void DoAction(Do _do)
    {
        if(_do!=null)
            _do();
    }
    void Update()
    {
        if(doChain != null)
        {
            doChain();
            doChain = null;
        }
        elapsed += Time.deltaTime;
        if(elapsed >= 1f)
        {
            doBlink();
            elapsed -= 1f;
        }
    }
}
