using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

    public GameObject mapPiece;
    public GameObject roadPiece;
    public GameObject centerPiece;
    public int rows;
    public int cols;
	// Use this for initialization
	void Start () {
	    for(float i = 0; i < rows; ++i)
        {
            for(float j = 0; j < cols; ++j)
            {
                Instantiate(mapPiece, new Vector3(j*Mathf.Sqrt(2), i, i), Quaternion.Euler(45,0,0));
                if (i != rows-1)
                {
                    Instantiate(roadPiece, new Vector3(j * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                }
                if (j != cols - 1)
                {
                    Instantiate(roadPiece, new Vector3((j + 0.5f) * Mathf.Sqrt(2) , i, i), Quaternion.Euler(45, 0, 90));
                }
                if(i != rows - 1 && j != cols - 1)
                {
                    Instantiate(centerPiece, new Vector3((j + 0.5f) * Mathf.Sqrt(2), i + 0.5f, i + 0.5f), Quaternion.Euler(45, 0, 0));
                }
            }
        }
	}
	
}
