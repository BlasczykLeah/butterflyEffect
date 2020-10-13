using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDelay : MonoBehaviour
{
    public float typeSpeed;
    public bool isTyping;

    TextMeshProUGUI myText;
    string newText;
    int currentLetter;

    public void enterText(string message)
    {
        if(message != null)
        {
            isTyping = true;
            myText.text = "";
            currentLetter = 0;
            newText = message;
            StartCoroutine("InsertLetter", typeSpeed);
        } 
    }

    IEnumerator InsertLetter(float time)
    {
        string currentText = myText.text + newText[currentLetter];
        currentLetter++;
        myText.text = currentText;

        yield return new WaitForSeconds(time);

        if (currentLetter < newText.Length) StartCoroutine("InsertLetter", typeSpeed);
    }

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        enterText("some really long message that is super long and would take a long time to type");
    }

    void Update()
    {
        if(isTyping && Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            myText.text = newText;
            isTyping = false;
        }
    }
}
