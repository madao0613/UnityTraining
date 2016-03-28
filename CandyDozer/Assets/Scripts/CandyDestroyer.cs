using UnityEngine;
using System.Collections;

public class CandyDestroyer : MonoBehaviour {
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            // オブジェクトの削除
            Destroy(other.gameObject);
        }
    }

}
