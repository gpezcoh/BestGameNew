using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
    public float speed = 1.0f;
    public int rotate = 1;
    public bool turn = false;
    public Vector3 vec = Vector3.left;
    public int health = 5;

    public GameObject healthBar;

    // Update is called once per frame
    void Update () {
        if (turn)
        {
            Invoke("Rotate", 0.3f);
            turn = false;
        }
        Move();
    }

    void Move()
    {
        transform.position += vec * speed * Time.deltaTime;
    }

   // void OnTriggerEnter(Collider other)
    //{

//    }

    void Rotate()
    {
        if (rotate == 1)
        {
            vec = Vector3.left;
        }
        else if (rotate == 2 || rotate == 4)
        {
            vec = new Vector3(0, -1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2));
        }
        else if (rotate == 3)
        {
            vec = Vector3.right;
        }
    }
}
