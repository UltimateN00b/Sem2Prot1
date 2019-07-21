using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTracker : MonoBehaviour
{

    public int bestEndNode;
    public int neutralEndNode;
    public int worstEndNode;
    public int bestEndNodeWithContext;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckEnding()
    {
        int interactCount = this.GetComponent<InteractionTracker>().GetInteractCount();


        if (interactCount >= 3)
        {
            int angerCount = this.GetComponent<AngerTracker>().GetAnger();

            if (angerCount <= 5)
            {
                JumpToNeutralEnd();
            }
            else if (angerCount > 5 && angerCount <= 8)
            {
                JumpToBestEndWithContext();
            }
            else
            {
                JumpToWorstEnd();
            }
        }
    }

    public void JumpToWorstEnd()
    {
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(worstEndNode);
    }
    public void JumpToBestEnd()
    {
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(bestEndNode);
    }
    public void JumpToNeutralEnd()
    {
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(neutralEndNode);
    }

    public void JumpToBestEndWithContext()
    {
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(bestEndNodeWithContext);
    }
}
