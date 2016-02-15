using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

    private GameObject target = null;
    public Text gold;
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
                changeGold();
            }
            Destroy(this.gameObject);
        }
    }

	public void Shooting(GameObject targ)
    {
        target = targ;
    }

    void changeGold()
    {
        int goldNum = int.Parse(gold.text);
        goldNum += 10;
        gold.text = goldNum.ToString();
    }
}
