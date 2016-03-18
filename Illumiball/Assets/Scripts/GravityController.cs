using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {

    //重力加速度
    const float Gravity = 9.81f;

    //重力の適用具合
    public float gravityScale = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vector = new Vector3();

        if (Application.isEditor)
        {
            //キーの入力を検知しベクトルを設定
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //高さ方向の判定キーはZキーとする
            if (Input.GetKey("z"))
            {

                vector.y = 1.0f;

            } else {

                vector.y = -1.0f;

            }
        } else {

            //加速度センサーの入力をUnity空間の軸にマッピングする
            vector.x = Input.acceleration.x;
            vector.y = Input.acceleration.z;
            vector.z = Input.acceleration.y;

        }

        //シーンの重力を入力ベクトルの方向にあわせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;

	}
}
