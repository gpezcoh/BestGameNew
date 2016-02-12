using UnityEngine;
using System.Collections;

public class CenterTrigger : MonoBehaviour {
	
    public bool isEnd = false;
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Enemy"))
        {
            if (isEnd)
            {
                if (other.GetComponent<EnemyScript>().rotate == 4)
                {
                    other.GetComponent<EnemyScript>().rotate = 1;
                }
                else
                {
                    other.GetComponent<EnemyScript>().rotate++;
                }
                other.GetComponent<EnemyScript>().turn = true;
            }
        }
	}
}
