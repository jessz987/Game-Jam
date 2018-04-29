using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    
	void Update () {
		if (GameManager.gotEverything)
        {
            gameObject.SetActive(false);
        }
	}
}
