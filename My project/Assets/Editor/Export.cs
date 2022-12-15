using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class Export 
{
    static Dictionary<string, int> saveList = new Dictionary<string, int>();
    static Dictionary<int, GameObject> loadList = new Dictionary<int, GameObject>();
    // "Export/MapExport"를 선택했을 경우 MapExport함수가 호출된다.
    [MenuItem("Export/MapExport")]
    static public void MapExport()
    {
        // 3. 씬에 있는 Building이라는 이름의 태그를 갖는 게임오브젝트가 단일 오브젝트가 아닌 경우에 대하여 저장할수
        // 있도록 프로그램 코드를 수정하시오. 저장하는 데이터에서 이름,부모인덱스,위치,회전,스케일 정보를 저장.
        string sceneName = SceneManager.GetActiveScene().name;
        using(StreamWriter sr = new StreamWriter(Application.dataPath + "/" + sceneName + ".csv"))
        {
            GameObject [] buildings = GameObject.FindGameObjectsWithTag("Building");
            sr.WriteLine("index,name,parentIndex, posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");
            string lineData = string.Empty;
            for (int i = 0; i < buildings.Length; i++)
            {
                lineData = string.Empty;
                lineData += (i + 1).ToString();
                lineData += ",";
                lineData += buildings[i].name;
                lineData += ",";
                if (buildings[i].transform.parent.gameObject.name == "TerrainObject")
                {
                    lineData += "-1";
                }
                else
                {
                    // 부모게임오브젝트의 인덱스를 검색한다.
                    GameObject parentObj = buildings[i].transform.parent.gameObject;
                    lineData += saveList[parentObj.name].ToString();
                }
                lineData += ",";
                lineData += buildings[i].transform.localPosition.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localPosition.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localPosition.z.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.z.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.z.ToString();
                sr.WriteLine(lineData);
                saveList.Add(buildings[i].name, (i + 1));
            }
            sr.Close();
            saveList.Clear();
        }
    }

    [MenuItem("Load/MapLoad")]
    static public void MapLoad()
    {
        GameObject terrainParent = GameObject.Find("TerrainObject");
        if (terrainParent == null)
        {
            terrainParent = new GameObject("TerrainObject");
            terrainParent.transform.position = Vector3.zero;
        }
        // 1. 경로를 지정
        // 2. 파일 열기 패널을 이용해서 파일을 선택할 수 있도록
        string path = Application.dataPath + "/" + SceneManager.GetActiveScene().name + ".csv";
        using( StreamReader sr = new StreamReader(path))
        {
            string lineData = string.Empty;
            lineData = sr.ReadLine();
            while ((lineData = sr.ReadLine()) != null)
            {
                string[] datas = lineData.Split(',');
                int index = int.Parse(datas[0]);
                string name = datas[1];
                int parentIndex = int.Parse(datas[2]);
                float xPos = float.Parse(datas[3]);
                float yPos = float.Parse(datas[4]);
                float zPos = float.Parse(datas[5]);
                float xRot = float.Parse(datas[6]);
                float yRot = float.Parse(datas[7]);
                float zRot = float.Parse(datas[8]);
                float xScale = float.Parse(datas[9]);
                float yScale = float.Parse(datas[10]);
                float zScale = float.Parse(datas[11]);
                // 리소스 이름
                int pos = name.IndexOf('_');
                string prefabName = name.Substring(0, pos);
                prefabName = prefabName.Trim();
                GameObject rcPreFab = Resources.Load<GameObject>(prefabName);
                GameObject obj = GameObject.Instantiate<GameObject>(rcPreFab);
                obj.name = name;
                //부모가 존재할경우와 그렇지 않은 경우 구분
                if (parentIndex == -1)
                {
                    obj.transform.SetParent(terrainParent.transform);
                }
                else
                {
                    obj.transform.SetParent(loadList[parentIndex].transform);
                }
                obj.transform.localPosition = new Vector3(xPos, yPos, zPos);
                obj.transform.localEulerAngles = new Vector3(xRot, yRot, zRot);
                obj.transform.localScale = new Vector3(xScale, yScale, zScale);
                loadList.Add(index,obj);
            }
            sr.Close();
        }
    }
}

