using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonePartSelector : MonoBehaviour {
    public Text partSelectorText;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 1000))
            {
                partSelectorText.text = hit.transform.name;
            }
        }
    }
}
