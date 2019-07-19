using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogImage : MonoBehaviour {

    public List<Sprite> myExpressions;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeExpression(string expression)
    {
        Sprite changeSprite = this.GetComponent<Image>().sprite;

        foreach (Sprite s in myExpressions)
        {
            string expressionName = s.name.Substring(s.name.IndexOf("_") + 1);

            if (expressionName.ToUpper().Equals(expression.ToUpper()))
            {
                changeSprite = s;
            }
        }

        this.GetComponent<Image>().sprite = changeSprite;
    }
}
