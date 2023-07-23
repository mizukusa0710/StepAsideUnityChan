using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //unitychan
    private GameObject unitychan;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    private float zpos;

    // アイテムを生成する距離（40m先から）誤り
    // private float generateDistance = 40.0f;

    //【正】アイテムを生成する間隔（15mごと）
    private float generateDistance = 15.0f;
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
        zpos = unitychan.transform.position.z;
    }

    void Update()
    {
        //保存したzposからの相対距離を求める
        float difference = unitychan.transform.position.z - zpos;

        //インターバル処理
        if (difference >= generateDistance)
        {
            //【正】ユニティちゃんから40メートル前の座標を渡す。
            GenerateItems(unitychan.transform.position.z + 40.0f);

            //相対距離をリセットするので以下の様になります。
            //【正】zposを更新する。（ユニティちゃんのZ座標で良い）
            zpos = unitychan.transform.position.z;
        }
        //【誤】40メートル進んだ所の座標
        //zpos = unitychan.transform.position.z + 40.0f;
        //以下の関数は引数を追加すると良いです。
        // GenerateItems();

    }
    //一列ずつ生成、引数 iで生成するZ座標を受け取る。
    void GenerateItems(float i)
    {
        ////アイテムを生成するｚ
        //float generatezpos = zpos + generateDistance;
        ////一定の距離ごとにアイテムを生成
        //for (float i = zpos; i <= generatezpos; i += 20)
        //{
        //    for (int itemCount = 0; itemCount < 8; itemCount++)
        //    {

        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
            }
        }
        else
        {

            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                }
            }
        }
    }
}