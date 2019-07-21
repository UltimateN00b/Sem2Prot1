using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{

    public static GameObject currSelectedItem;

    public bool canBark;
    public bool canPeeOn;
    public bool canBite;
    public bool canPush;

    public UnityEvent m_OnBark;
    public UnityEvent m_OnPee;
    public UnityEvent m_OnBite;
    public UnityEvent m_OnPush;

    public UnityEvent m_OnUpdate;

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

        if (m_OnUpdate == null)
        {
            m_OnUpdate = new UnityEvent();
        }
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

        MyButtonCommand bark = Utilities.SearchChild("Bark At", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand peeOn = Utilities.SearchChild("Pee On", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand push = Utilities.SearchChild("Push", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand bite = Utilities.SearchChild("Bite", commandWheel).GetComponent<MyButtonCommand>();


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


        if (canPush)
        {
            push.SetClickedEvent(m_OnPush);
        }
        else
        {
            push.SetClickedEvent(new UnityEvent());
        }


        if (canBite)
        {
            bite.SetClickedEvent(m_OnBite);
        }
        else
        {
            bite.SetClickedEvent(new UnityEvent());
        }

    }

    public void ChangeApplicableButton(string button)
    {
        if (button.Equals("Bark At"))
        {
            canBark = !canBark;
        }
        else if (button.Equals("Pee On"))
        {
            canPeeOn = !canPeeOn;
        }
        else if (button.Equals("Push"))
        {
            canPush = !canPush;
        }
        else if (button.Equals("Bite"))
        {
            canBite = !canBite;
        }

        ResetApplicableButtons();
    }

    public void ChangeApplicableButtonTrue(string button)
    {

        if (button.Equals("Bark At"))
        {
            canBark = true;
        }
        else if (button.Equals("Pee On"))
        {
            canPeeOn = true;
        }
        else if (button.Equals("Push"))
        {
            canPush = true;
        }
        else if (button.Equals("Bite"))
        {
            canBite = true;
        }

        ResetApplicableButtons();
    }

    private void ResetApplicableButtons()
    {
        _applicableButtons = new List<bool>();

        _applicableButtons.Add(canBark);
        _applicableButtons.Add(canPeeOn);
        _applicableButtons.Add(canBite);
        _applicableButtons.Add(canPush);
    }

    public void UpdateItem(string s)
    {
        List<GameObject> allObjects = new List<GameObject>();
        allObjects.Add(this.gameObject);

        for (int i = 0; i < this.transform.childCount; i++)
        {
            allObjects.Add(this.gameObject.transform.GetChild(i).gameObject);
        }

        GameObject update = Utilities.SearchChild(s, this.gameObject);
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

        update.GetComponent<Item>().m_OnUpdate.Invoke();

        Destroy(this.gameObject);
    }

    public void HueShift()
    {
        _fadeHue = true;
    }
}
