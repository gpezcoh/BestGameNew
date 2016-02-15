using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Dropdown createTower;
    public bool creating = false;
    public int towerNum;

	void Update()
    {
        createTower.onValueChanged.AddListener(delegate { create(); });
    }

    void create()
    {
        creating = true;
        towerNum = createTower.value;
    }
}
