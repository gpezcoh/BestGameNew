using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private GameObject target = null;
    public float speed = 1f;

    void Update()
    {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }
        else
        {
            Destroy(this.gameObject); // maybe fix this later, but might be best option
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().health--;
            other.GetComponent<EnemyScript>().healthBar.GetComponent<TextMesh>().text = other.GetComponent<EnemyScript>()
                .healthBar.GetComponent<TextMesh>().text.Remove(other.GetComponent<EnemyScript>().healthBar.GetComponent<TextMesh>().text.Length - 1);
            if(other.GetComponent<EnemyScript>().health == 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

	public void Shooting(GameObject targ)
    {
        target = targ;
    }
}
