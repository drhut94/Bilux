using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "ScriptableObjects/StoryPart", order = 1)]
public class StoryManager : ScriptableObject
{

    [TextArea]
    public string storyText;

    public string StoryText
    {
        get { return storyText; }
    }

}
