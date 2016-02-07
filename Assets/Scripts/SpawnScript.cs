using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {


    public GameObject enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Invoke("Spawn", 2);
        }
	}

    void Spawn()
    {
        Instantiate(enemy, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.3f), Quaternion.Euler(45, 0, 0));
    }
}
