using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour {

    public GameObject tower;
    private bool occupied = false;
    public Dropdown dropdown;
    public Text gold;
    public int creating = 0;
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        MakeTower(this.gameObject);
    }

    void OnMouseEnter()
    {
        creating = dropdown.value;

        if (!occupied && creating != 0)
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(20f / 255f, 103f / 255f, 31f / 255f));
        }
    }

    void OnMouseExit()
    {
        creating = dropdown.value;

        if (!occupied && creating != 0)
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(41f/255f,204f/255f,62f/255f));
        }
    }

    public void setOccupied()
    {
        occupied = true;
    }

    void MakeTower(GameObject piece)
    {
        creating = dropdown.value;

        if (!occupied && creating != 0 && checkGold() >= 50)
        {
            GameObject tow = (GameObject)Instantiate(tower, new Vector3(piece.transform.position.x, piece.transform.position.y, piece.transform.position.z), Quaternion.Euler(45, 0, 0));
            tow.GetComponent<TowerFire>().gold = gold;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(41f / 255f, 204f / 255f, 62f / 255f));
            changeGold();
            occupied = true;
        }
    }
    void changeGold()
    {
        int goldNum = int.Parse(gold.text);
        goldNum-=50;
        gold.text = goldNum.ToString();
    }
    int checkGold()
    {
        return int.Parse(gold.text);
    }
}
