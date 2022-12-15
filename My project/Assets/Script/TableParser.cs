using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 리스트에 저장하는 구조체
public struct MonsterData
{
    public int index;
    public string name;
    public float str;
}
public struct NpcData
{
    public int index;
    public string name;
    public byte type;
}

// T는 싱글톤을 위한 T
// Q는 리스트에 저장하기 위한 Q
public class TableParser<T,Q> where T : class ,new() where Q : struct
{
    protected List<Q> list;
    public List<Q> LIST
    {
        get { return list; }
    }
    private static T inst;
    public static T instance
    {
        get 
        {
            if (inst == null)
                inst = new T();
            return inst; 
        }
    }
    public TableParser()
    {

    }
    public void LoadData(string _fileName)
    {
        list = new List<Q>();
        using (StreamReader sr = new StreamReader(_fileName))
        {
            string line = string.Empty;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] datas = line.Split(',');
                ReadData(datas);
            }
            sr.Close();
        }
    }
    virtual public void ReadData(string [] _datas)
    {
    }
}


public class MonsterTable : TableParser<MonsterTable,MonsterData>
{

    public override void ReadData(string[] _datas)
    {
        MonsterData tmp;
        tmp.index = int.Parse(_datas[0]);
        tmp.name = _datas[1];
        tmp.str = float.Parse(_datas[2]);
        list.Add(tmp);
    }
}

public class NpcTable : TableParser<NpcTable, NpcData>
{
    public override void ReadData(string[] _datas)
    {
        NpcData tmp;
        tmp.index = int.Parse(_datas[0]);
        tmp.name = _datas[1];
        tmp.type = byte.Parse(_datas[2]);
        list.Add(tmp);
    }
}
