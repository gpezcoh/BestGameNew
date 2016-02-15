using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {

    public GameObject mapPiece;
    public GameObject roadPiece;
    public GameObject centerPiece;
    public GameObject filler;
    public GameObject spawn;
    public GameObject homeBase;
    public Text health;
    public Text gold;
    public Dropdown canvas;
    public int rows;
    public int cols;
	// Use this for initialization
	void Start () {
	    for(float i = 0; i < rows; ++i)
        {
            for(float j = 0; j < cols; ++j)
            {
                GameObject cube = (GameObject)Instantiate(mapPiece, new Vector3(j*Mathf.Sqrt(2), i, i), Quaternion.Euler(45,0,0));
                cube.GetComponent<CreateTower>().dropdown = canvas;
                cube.GetComponent<CreateTower>().gold = gold;
                if (i != rows-1)
                {
                    if (j == 0 || j == cols - 1)
                    {
                        if (i == 0 && j == 0 || i == rows - 2 && j == cols - 1)
                        {
                            Instantiate(roadPiece, new Vector3(j * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                        }
                        else {
                            Instantiate(filler, new Vector3(j * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                        }
                    }
                    else {
                        Instantiate(roadPiece, new Vector3(j * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                    }
                }
                if (j != cols - 1)
                {
                    if (i == 0 || i == rows - 1)
                    {
                        Instantiate(filler, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i, i), Quaternion.Euler(45, 0, 90));
                    }
                    else if(j != cols - 2 && j != 0)
                    {
                        Instantiate(filler, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i, i), Quaternion.Euler(45, 0, 90));
                    }
                    else if(j == 0 && i % 2 != 0 || j == cols-2 && i%2 == 0)
                    {
                        Instantiate(filler, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i, i), Quaternion.Euler(45, 0, 90));
                    }
                    else {
                        Instantiate(roadPiece, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i, i), Quaternion.Euler(45, 0, 90));
                    }
                }
                if(i != rows - 1 && j != cols - 1)
                {
                    var center = (GameObject)Instantiate(centerPiece, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                    if(j == 0 && i != 0 || j == cols - 2 && i != rows - 2)
                    {
                        center.GetComponent<CenterTrigger>().isEnd = true;
                    }
                }
            }
        }
        for(float i = 0; i < rows; ++i)
        {
            if (i == rows - 2)
            {
                Instantiate(spawn, new Vector3(cols * Mathf.Sqrt(2) - 0.5f, i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
            }
            else if (i != rows - 1)
            {
                Instantiate(filler, new Vector3(cols * Mathf.Sqrt(2) - 0.5f, i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
            }
            var temp = (GameObject)Instantiate(mapPiece, new Vector3(cols * Mathf.Sqrt(2) - 0.5f, i, i), Quaternion.Euler(45, 0, 0));
                var script = temp.GetComponent<CreateTower>();
                script.setOccupied();
            script.dropdown = canvas;
            script.gold = gold;

        }
        for (float i = 0; i < rows; ++i)
        {
            if (i == 0)
            {
                GameObject home = (GameObject)Instantiate(homeBase , new Vector3(0 - 0.5f, i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                home.GetComponent<BaseScript>().health = health;
            }
            else if (i != rows - 1)
            {
                Instantiate(filler, new Vector3(0 - 0.5f, i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
            }
            var temp = (GameObject)Instantiate(mapPiece, new Vector3(0 - 0.5f, i, i), Quaternion.Euler(45, 0, 0));
            var script = temp.GetComponent<CreateTower>();
            script.setOccupied();
            script.dropdown = canvas;
            script.gold = gold;

        }
    }
	
}
