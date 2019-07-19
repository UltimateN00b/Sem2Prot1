using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(36);
        }
    }
}
