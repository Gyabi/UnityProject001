using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("キューブオブジェクト")]
    private List<GameObject> _cubeList = new List<GameObject>();

    [SerializeField, Header("キューブUI管理クラス")]
    private ObjectSelector _objectSelector;
    // Start is called before the first frame update

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private int _currentCubeIndex = 0;

    void Awake()
    {
        // キューブオブジェクトを選択UIに反映
        _objectSelector.SetCubeList(ref _cubeList);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentCube(int value)
    {
        _currentCubeIndex = value;
        Debug.Log(_currentCubeIndex);
    }
}
