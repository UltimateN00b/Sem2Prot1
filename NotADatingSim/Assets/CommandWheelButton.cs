using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandWheelButton : MonoBehaviour {

    bool fadeCameraMusicMischief;
    bool fadeCameraMusicNormal;

    bool fadeOut = true;
    bool fadeIn = false;

    private static AudioClip _normalTrack;
    private static AudioClip _mischiefTrack;

    // Use this for initialization
    void Start () {
        fadeCameraMusicMischief = false;
        fadeCameraMusicNormal = false;

        _normalTrack = Resources.Load("MainThemeSoundtrack01") as AudioClip;
        _mischiefTrack = Resources.Load("MischieviousSoundtrack01") as AudioClip;
}
	
	// Update is called once per frame
	void Update () {
		if (fadeCameraMusicMischief)
        {
            FadeCameraMusic(_mischiefTrack);
        } else if (fadeCameraMusicNormal)
        {
            FadeCameraMusic(_normalTrack);
        }
	}

    private void OnMouseOver()
    {
        GameObject commandWheelText = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(1).gameObject;
        GameObject commandWheelImage = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(0).gameObject;

        commandWheelText.GetComponent<MyUIFade>().FadeIn();
        commandWheelImage.GetComponent<MyUIFade>().FadeIn();

        string commandName = this.gameObject.name;
        if (commandName == "Go")
        {
            commandName = "Go To";
        } else if (commandName == "Talk")
        {
            commandName = "Talk To";
        }
        commandWheelText.GetComponent<Text>().text = commandName + "\n" + Item.currSelectedItem.name;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fadeCameraMusicMischief = true;
        }
    }

    private void OnMouseExit()
    {
        GameObject commandWheelText = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(1).gameObject;
        GameObject commandWheelImage = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(0).gameObject;
        commandWheelText.GetComponent<MyUIFade>().FadeOut();
        commandWheelImage.GetComponent<MyUIFade>().FadeOut();
    }

    private void FadeCameraMusic(AudioClip newClip)
    {
        print("SHOULD FADE!");

        AudioSource aS = Camera.main.GetComponent<AudioSource>();

        if (fadeOut)
        {
            if (aS.volume > 0)
            {
                aS.volume -= 5f*Time.deltaTime;
            } else
            {
                fadeOut = false;
                fadeIn = true;
                aS.clip = newClip;
                aS.Play();
            }
        }else if (fadeIn)
        {
            print("MUSIC SHOULD FADE IN!");
            if (aS.volume < 1)
            {
                aS.volume += 5f * Time.deltaTime;
            }
            else
            {
                fadeOut = true;
                fadeIn = false;
                fadeCameraMusicMischief = false;
                fadeCameraMusicNormal = false;
            }
        }
    }

    public void PlayNormalClip()
    {
        fadeCameraMusicNormal = true;
    }
}
