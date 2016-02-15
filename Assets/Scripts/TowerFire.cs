using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TowerFire : MonoBehaviour {

    private List<GameObject> target = new List<GameObject>();
    public GameObject bullet;
    public Text gold;
    private bool fire = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target.Add(other.gameObject);
            if (!fire)
            {
                Shoot();
                fire = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target.Remove(other.gameObject);
        }
    }

    void Shoot()
    {
        if(target.Count != 0)
        {
            GameObject bull = (GameObject)Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            bull.GetComponent<BulletScript>().Shooting(target[0]);
            bull.GetComponent<BulletScript>().gold = gold;
            if (target[0] == null)
            {
                target.RemoveAt(0);
                Shoot();
                return;
            }
            Invoke("Shoot", 2);
        }
        else
        {
            fire = false;
        }
    }
}
