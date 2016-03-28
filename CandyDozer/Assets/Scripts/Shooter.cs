using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    const int SphereCandyFrequency = 3;

    int sampleCandyCount;
    public GameObject[] candyPrefabs;
    public GameObject[] candySquarePrefabs;
    public GameObject candyHolder;

    public GameObject candyPrefab;
    public float shotSpeed;
    public float shotTorque;
    public float baseWidth;
    	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1")) Shot();
	
	}

    // キャンディのプレファブからランダムに1つ選ぶ
    GameObject SampleCandy()
    {

        GameObject prefab = null;

        // 特定の回数に１回丸いキャンディを選択する。
        if(sampleCandyCount % SphereCandyFrequency == 0)
        {
            int index = Random.Range(0, candyPrefabs.Length);
            prefab = candyPrefabs[index];
        } else {
            int index = Random.Range(0, candySquarePrefabs.Length);
            prefab = candySquarePrefabs[index];
        }

        sampleCandyCount++;

        return prefab;
    }

    Vector3 GetInstantiatePosition ()
    {
        // 画面のサイズとInputの割合からキャンディ生成のポジションを計算
        float x = baseWidth *
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        // プレファブからCandyオブジェクトを生成
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity
            );

        // 生成したCandyオブジェクトの親をCandyHolderに設定する
        candy.transform.parent = candyHolder.transform;

        // CandyオブジェクトのRigidBodyを取得し力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotSpeed);
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

    }
}
