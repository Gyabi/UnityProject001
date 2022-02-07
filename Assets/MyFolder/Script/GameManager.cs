using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("キューブオブジェクト")]
    List<GameObject> cubeList = new List<GameObject>();
    // Start is called before the first frame update

    void Awake()
    {
        // キューブオブジェクトを選択UIに反映
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
