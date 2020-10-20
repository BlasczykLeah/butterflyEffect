using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextDelay2 : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 0.08f;
    private bool isTyping;
    private TextMeshProUGUI myText;
    private Coroutine typeCoroutine;

    public void EnterText(string message)
    {
        if(message != null)
        {
            myText.text = message;
            typeCoroutine = StartCoroutine(TypeCharacters(typeSpeed));
        }
    }

    IEnumerator TypeCharacters(float time)
    {
        isTyping = true;
        for(int i = 0; i <= myText.textInfo.characterCount; i++)
        {
            myText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(time);
        }
        isTyping = false;
    }

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        EnterText("some really long message that is super long and would take a long time to type");
    }

    void Update()
    {
        if(isTyping && Input.GetMouseButtonDown(0))
        {
            StopCoroutine(typeCoroutine);
            isTyping = false;
            myText.maxVisibleCharacters = myText.textInfo.characterCount;
        }
    }
}