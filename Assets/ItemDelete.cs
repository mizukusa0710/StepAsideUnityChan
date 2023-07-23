using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    //カメラのオブジェクト
    private GameObject mainCamera;
 
    // Start is called before the first frame update
    void Start()
    {
        //カメラのオブジェクトを取得
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    { 
        //自身よりカメラが前へ行った。（画面の外になった）
        if (mainCamera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
