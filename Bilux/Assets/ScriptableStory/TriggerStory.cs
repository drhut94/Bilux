using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStory : MonoBehaviour {

    public Text text;

    [SerializeField]
    private StoryManager storyPart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(true);
            text.text = storyPart.storyText;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(storyPart.storyText));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }
    }

}
