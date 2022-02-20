using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CubeEditCam : MonoBehaviour
{
    [SerializeField, Header("ワイヤフレームオブジェクト")]
    GameObject _wireframe;

    [SerializeField, Header("キューブの親オブジェクト")]
    GameObject _cubeParent;

    private GameObject _wireframeInstance;

    // raycastの範囲
    float max_distance = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        _wireframeInstance = Instantiate(_wireframe);
    }

    // Update is called once per frame
    void Update()
    {
        // 常時rayを放って衝突点にワイヤフレームprefabを表示
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        
        bool is_hit = Physics.Raycast(ray, out hit, max_distance);

        if(is_hit)
        {
            _wireframeInstance.transform.position = GetGridPosition(hit.point);
            _wireframeInstance.SetActive(true);
        }
        else
        {
            _wireframeInstance.SetActive(false);
        }

        // マウスクリックでキューブを生成
        if (Input.GetMouseButtonDown(0) && !IsUGUIHit(Input.mousePosition))
        {
            if (is_hit)
            {
                // ワイヤフレームの位置からキューブを生成
                GameObject cube = Instantiate(CubeManager.Instance.GetCurrentCube(), _wireframeInstance.transform.position, _wireframeInstance.transform.rotation);
                cube.transform.parent = _cubeParent.transform;
            }
        }
    }


    private Vector3 GetGridPosition(Vector3 position)
    {
        return new Vector3(
            Mathf.Round(position.x),
            Mathf.Round(position.y)+0.5f,
            Mathf.Round(position.z)
        );
    }


    // Raygaがuiに接触しているか判定
    public static bool IsUGUIHit(Vector3 _scrPos){ // Input.mousePosition
        PointerEventData pointer = new PointerEventData (EventSystem.current);
        pointer.position = _scrPos;
        List<RaycastResult> result = new List<RaycastResult> ();
        EventSystem.current.RaycastAll (pointer, result);
        return (result.Count > 0);
    }
}
