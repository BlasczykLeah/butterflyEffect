using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiologueManager : MonoBehaviour
{
    public static DiologueManager instance;

    public Conversation testConvo;
    public int currentText;

    public TextDelay2 myText;
    public GameObject[] buttons;

    public bool waitForClick = false;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (testConvo)
        {
            myText.EnterText(testConvo.diologues[currentText].text);
        }
    }

    void Update()
    {
        if (waitForClick)
        {
            if (Input.GetMouseButtonDown(0)) NextDiologue();
        }
    }

    public void FinishedText()
    {
        if (testConvo.diologues[currentText].type == DiologueType.Prompt)
        {
            for (int i = 0; i < testConvo.diologues[currentText].prompts.Length; i++)
            {
                buttons[i].SetActive(true);
                buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = testConvo.diologues[currentText].prompts[i].name;
            }
        }
        else Invoke("delayWaitingForClick", 0.2F);
    }

    void delayWaitingForClick()
    {
        waitForClick = true;
    }

    public void PromptPressed(int index)
    {
        foreach (GameObject a in buttons) a.SetActive(false);

        if (index < testConvo.diologues[currentText].prompts.Length)
        {
            currentText = testConvo.diologues[currentText].prompts[index].diologueIndex;
            myText.EnterText(testConvo.diologues[currentText].text);
        }
        else Debug.LogError("invalid index given");
    }

    void NextDiologue()
    {
        waitForClick = false;
        currentText++;
        if (currentText >= testConvo.diologues.Length) EndConversation();
        else
        {
            while (testConvo.diologues[currentText].type == DiologueType.Response)
            {
                currentText++;
                if (currentText >= testConvo.diologues.Length)
                {
                    EndConversation();
                    return;
                }
            }

            myText.EnterText(testConvo.diologues[currentText].text);
        }
    }

    public void EndConversation()
    {
        Debug.LogWarning("Diologue has ended.");
        myText.transform.parent.gameObject.SetActive(false);
    }
}
