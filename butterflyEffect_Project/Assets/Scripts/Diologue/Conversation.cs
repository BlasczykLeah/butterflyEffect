using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation", order = 0)]
public class Conversation : ScriptableObject
{
    public Diologue[] diologues;
}


[Serializable]
public class Diologue
{
    public string name;
    [TextArea(3, 10)]
    public string text;
    public DiologueType type;
    [Tooltip("Used only if type == Prompt")]
    public Prompt[] prompts;
}

[Serializable]
public class Prompt
{
    public string name;
    public int diologueIndex;
}

public enum DiologueType
{
    Regular,        // normal text, click to next text
    Prompt,         // has options for player to choose from
    Response        // clicked prompt response; cannot be a prompt
}