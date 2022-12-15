using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
 대리자(delegate)
 c언어에서 함수포인터의 개념과 유사
 함수의 대리 역할을 수행할 수 있도록 구현
 함수를 대입하여 사용할 수 있다.
 대입하는 함수는 대리자의 정의와 리턴값, 매개변수의 타입과 개수가 맞아야 한다.
 대리자는 함수를 대입할 수 있는 자료형
 */
/*
 Lamda 식
 자바에서는 무명 메서드라고 칭함
 => 연산자를 사용
 => 왼쪽은 매개변수를 의미, 오른쪽은 식이나 문 코드블럭을 의미
    람다식에서는 매개변수를 정의할 때 데이터형을 명시하지 않아도 된다.
    식 람다에서는 연산결과를 리턴
매개변수가 없는 식람다
()=>x*x; (식람다)

매개변수가 있는 식람다
(x)=>x*x;

매개변수가 없는 문 람다
() => { };

매개변수가 있는 문 람다
(x) => { };
 */

public delegate void Do();
public delegate int Doi();
public class LamdaExample_3 : MonoBehaviour
{
    float elapsed;
    Do doSomthing;  // Do형 변수 doSomething을 선언
    Do doChain;  // Do형 변수 doSomething을 선언
    Do doBlink;
    Doi doiSomthing;
    /*
        Action이란?
        라이브러리에서 제공하는 delegate
        한개의 매개변수와 반환형식이 없는 delegate
        Action<매개변수의자료형>
    */
    Action<float> act2;

    /*
     Func란?
     라이브러리에서 제공하는 delegate
     매개변수와 반환형식이 존재, 
     Func<T, TResult> : T는 매개변수, TResult는 반환형식
     Func<TResult>  : 매개변수는 생략, TResult는 반환형식
     */
    Func<bool> funcB;
    Func<Do, bool> funcC;
    //문제
    //funcB에 대입할 수 있는 함수를 정의하시오.
    //funcC에 대입할 수 있는 함수를 정의하시오.
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
        doChain();  // A함수 호출후에 B함수 호출

        doChain -= B;
        doChain -= A;

        doSomthing = DisplayData;
        doSomthing();
        doSomthing = () => { 
            Debug.Log("람다를 이용한 함수정의"); 
        };
        doSomthing();
        doiSomthing = () => 20 * 20;    // 20 * 20의 연산결과를 반환하기 때문에 대리자의 반환형식이 int이어야만 한다.
        Debug.Log(doiSomthing());
        //
        DoAction(() =>
        {
            Debug.Log("DoAction함수의 매개변수로 전달");
        });
        DoAction(DisplayData);
        //
        // Action 사용
        act2 = ActionFunction;
        act2(100f);
        //
        // Func 사용
        funcB = FuncTest;
        Debug.Log(funcB());
        //
        // 1초마다 한번씩 A함수와 B함수를 번갈아서 호출
        elapsed = 1f;
        doBlink = A;
    }
    /*
     * 함수를 매개변수로 전달
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
