using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    public Text health;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            int healthNum = int.Parse(health.text);
            healthNum--;
            health.text = healthNum.ToString();
        }
    }
}
