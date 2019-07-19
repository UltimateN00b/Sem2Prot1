using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{

    public static GameObject currSelectedItem;

    public bool canBark;
    public bool canPeeOn;
    public bool canSpill;
    public bool canBreak;

    public UnityEvent m_OnBark;
    public UnityEvent m_OnPee;
    public UnityEvent m_OnBreak;
    public UnityEvent m_OnSpill;

    public bool _canHueShift = true;

    private List<bool> _applicableButtons;
    private bool _fadeHue;

    private bool _fadeToBlue;
    private bool _resetToWhite;

    // Use this for initialization
    void Start()
    {
        ResetApplicableButtons();
        _fadeToBlue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canHueShift)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)|| Input.GetKeyDown(KeyCode.RightControl)|| Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown(KeyCode.RightCommand))
            {
                _fadeHue = true;
                _resetToWhite = false;
            }

            if (_fadeHue)
            {

                if (_fadeToBlue)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.blue, 0.02f);
                    print(this.GetComponent<SpriteRenderer>().color.r + "RCOLOUR");
                    if (this.GetComponent<SpriteRenderer>().color.r <= 0.3f)
                    {
                        _fadeToBlue = false;
                    }
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.white, 0.03f);
                    if (this.GetComponent<SpriteRenderer>().color.r >= 0.9f)
                    {
                        _fadeToBlue = true;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _fadeHue = false;
                    _resetToWhite = true;
                }
            }

            if (_resetToWhite)
            {
                this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.white, 0.03f);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currSelectedItem = this.gameObject;
            ChangeCommandWheelEvents();
            GameObject.Find("CommandWheel").GetComponent<CommandWheel>().ChangeApplicableButtons(_applicableButtons);

            if (GameObject.Find("CommandWheel").GetComponent<CommandWheel>().CanClick())
            {
                //GameObject.Find("UseItemManager").GetComponent<UseItemManager>().UseObject(this.gameObject);
            }
        }
    }

    private void ChangeCommandWheelEvents()
    {
        GameObject commandWheel = GameObject.Find("CommandWheel");

        MyButtonCommand bark = Utilities.SearchChild("Bark", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand peeOn = Utilities.SearchChild("Pee On", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand breaking = Utilities.SearchChild("Break", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand spill = Utilities.SearchChild("Spill", commandWheel).GetComponent<MyButtonCommand>();


        if (canBark)
        {
            bark.SetClickedEvent(m_OnBark);
        }
        else
        {
            bark.SetClickedEvent(new UnityEvent());
        }

        if (canPeeOn)
        {
            peeOn.SetClickedEvent(m_OnPee);
        }
        else
        {
            peeOn.SetClickedEvent(new UnityEvent());
        }


        if (canBreak)
        {
            breaking.SetClickedEvent(m_OnBreak);
        }
        else
        {
            breaking.SetClickedEvent(new UnityEvent());
        }


        if (canSpill)
        {
            spill.SetClickedEvent(m_OnSpill);
        }
        else
        {
            spill.SetClickedEvent(new UnityEvent());
        }

    }

    public void ChangeApplicableButton(string button)
    {
        if (button.Equals("Bark"))
        {
            canBark = !canBark;
        }
        else if (button.Equals("Pee On"))
        {
            canPeeOn = !canPeeOn;
        }
        else if (button.Equals("Break"))
        {
            canBreak = !canBreak;
        }
        else if (button.Equals("Spill"))
        {
            canSpill = !canSpill;
        }

        ResetApplicableButtons();
    }

    public void ChangeApplicableButtonTrue(string button)
    {

        if (button.Equals("Bark"))
        {
            canBark = true;
        }
        else if (button.Equals("Pee On"))
        {
            canPeeOn = true;
        }
        else if (button.Equals("Break"))
        {
            canBreak = true;
        }
        else if (button.Equals("Spill"))
        {
            canSpill = true;
        }

        ResetApplicableButtons();
    }

    private void ResetApplicableButtons()
    {
        _applicableButtons = new List<bool>();

        _applicableButtons.Add(canBark);
        _applicableButtons.Add(canPeeOn);
        _applicableButtons.Add(canBreak);
        _applicableButtons.Add(canSpill);
    }

    public void UpdateItem(int num)
    {
        List<GameObject> allObjects = new List<GameObject>();
        allObjects.Add(this.gameObject);

        for (int i = 0; i < this.transform.childCount; i++)
        {
            allObjects.Add(this.gameObject.transform.GetChild(i).gameObject);
        }

        GameObject update = Utilities.SearchChild(num + "_Update", this.gameObject);
        update.SetActive(true);
        update.name = this.name;
        update.transform.parent = this.transform.parent;

        foreach (GameObject g in allObjects)
        {
            if (g != update)
            {
                g.transform.SetParent(update.transform);
            }
        }

        Destroy(this.gameObject);
    }

    public void HueShift()
    {
        _fadeHue = true;
    }
}
