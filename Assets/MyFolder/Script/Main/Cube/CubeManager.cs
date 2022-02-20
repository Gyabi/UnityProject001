using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager
{
    private static CubeManager _instance;
    public static CubeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CubeManager();
            }
            return _instance;
        }
    }
    // cubeリスト
    private List<GameObject> _cubeList = new List<GameObject>();

    // 現在生成可能なキューブのインデックス
    private int _currentCubeIndex = 0;

    public void SetCubeList(ref List<GameObject> list)
    {
        this._cubeList = list;
    }

    public void SetCurrentCube(int value)
    {
        if(value < 0 || value >= _cubeList.Count)
        {
            return;
        }
        _currentCubeIndex = value;
    }

    public GameObject GetCurrentCube()
    {
        return _cubeList[_currentCubeIndex];
    }

}
