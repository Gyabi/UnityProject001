using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField, Header("CubeUI一覧")]
    private List<GameObject> cubeUIList = new List<GameObject>();

    [SerializeField, Header("CubeUIを格納する親オブジェクト")]
    private GameObject cubeUIParent = null;

    private List<GameObject> cubeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetCurrentCube(int value)
    {
        GameManager.Instance.SetCurrentCube(value);
        
    }

    public void SetCubeList(ref List<GameObject> list)
    {
        this.cubeList = list;
        MakeGUi();
    }


    private void MakeGUi()
    {   
        Debug.Log("MakeGUI");
        // 事前に設定しているUiの元データを書き換える為の配列
        List<GameObject> tempList = new List<GameObject>();
        for(int i=0; i<cubeList.Count; i++)
        {
            // 対応するUIオブジェクトを取得
            GameObject whitecubeUI = cubeUIList[i];
            // インスタンス化
            GameObject cubeUI = Instantiate(cubeList[i], cubeUIParent.transform);

            // rectの情報をコピー
            cubeUI.AddComponent<RectTransform>();
            RectTransform rectTransform = cubeUI.GetComponent<RectTransform>();
            RectTransform originalrectTransform = whitecubeUI.GetComponent<RectTransform>();
            rectTransform.SetParent(cubeUIParent.transform);
            rectTransform.localPosition    = originalrectTransform.localPosition;
            rectTransform.localRotation    = originalrectTransform.localRotation;
            rectTransform.localScale       = originalrectTransform.localScale;
            rectTransform.pivot            = originalrectTransform.pivot;
            rectTransform.anchorMin        = originalrectTransform.anchorMin;
            rectTransform.anchorMax        = originalrectTransform.anchorMax;
            rectTransform.anchoredPosition = originalrectTransform.anchoredPosition;
            rectTransform.sizeDelta        = originalrectTransform.sizeDelta;
            cubeUI.name = cubeUIList[i].name;
            cubeUI.layer = cubeUIList[i].layer;
            tempList.Add(cubeUI);
            // 書き換えたデータを削除
            Destroy(whitecubeUI);
        }
        // リスト更新
        cubeUIList = tempList;
    }
}
