using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryRemember : MonoBehaviour {

    public int restartNode;

    private static bool _retry = false;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(this.gameObject);

        if (_retry)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(restartNode);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public static void SetRetryTrue()
    {
        _retry = true;
    }
}
