using UnityEngine;
using System.Collections;

public class BaseScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("rekt");
        }
    }
}
