using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerFire : MonoBehaviour {

    private List<GameObject> target = new List<GameObject>();
    public GameObject bullet;
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
