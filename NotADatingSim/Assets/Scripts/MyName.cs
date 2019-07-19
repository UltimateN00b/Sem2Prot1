using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyName : MonoBehaviour {

    private static string _myName;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        _myName = "NAME_NOT_FOUND";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _myName = this.GetComponent<InputField>().textComponent.text;
            StoreInfoPuppyLove.EnterName(_myName);
            SceneManager.LoadScene("SampleScene");
        }
	}
}
