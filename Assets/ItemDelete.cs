using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    //�J�����̃I�u�W�F�N�g
    private GameObject mainCamera;
 
    // Start is called before the first frame update
    void Start()
    {
        //�J�����̃I�u�W�F�N�g���擾
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    { 
        //���g���J�������O�֍s�����B�i��ʂ̊O�ɂȂ����j
        if (mainCamera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
