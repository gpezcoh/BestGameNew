using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour {

    public GameObject tower;
    private bool occupied = false;
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        MakeTower(this.gameObject);
    }

    public void setOccupied()
    {
        occupied = true;
    }

    void MakeTower(GameObject piece)
    {
        if (!occupied)
        {
            Instantiate(tower, new Vector3(piece.transform.position.x, piece.transform.position.y, piece.transform.position.z), Quaternion.Euler(45, 0, 0));
            occupied = true;
        }
    }
}
