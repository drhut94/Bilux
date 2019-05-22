using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour {

    public static GameMngr instance;
    public float tutorial;
    public float level1;
    public float level2;
    public float level3;
    public float level4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {

        if (!PlayerPrefs.HasKey("tutorial"))
        {
            ResetGameProgres();
        }
    }
	

    public void DeleteGameData ()
    {
        PlayerPrefs.DeleteAll();    
        UpdateLevels();
    }

    public void UpdateLevels()
    {

        tutorial = PlayerPrefs.GetFloat("tutorial");
        level1 = PlayerPrefs.GetFloat("level1");
        level2 = PlayerPrefs.GetFloat("level2");
        level3 = PlayerPrefs.GetFloat("level3");
        level4 = PlayerPrefs.GetFloat("level4");

        FindObjectOfType<UIInteractions>().UnlockLevel(0, "tutorial");

        if (tutorial >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(1, "level1");
        }
        if (level1 >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(2, "level2");
        }
        if (level2 >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(3, "level3");
        }
        FindObjectOfType<UIInteractions>().UnlockLevel(6, "bonusLevel");
        FindObjectOfType<UIInteractions>().UnlockLevel(4, "bonusLevel");
        FindObjectOfType<UIInteractions>().UnlockLevel(5, "bonusLevel");
        FindObjectOfType<UIInteractions>().UnlockLevel(1, "bonusLevel");
        FindObjectOfType<UIInteractions>().UnlockLevel(2, "bonusLevel");
        FindObjectOfType<UIInteractions>().UnlockLevel(3, "bonusLevel");

    }

    public void ResetGameProgres()
    {
        PlayerPrefs.SetFloat("tutorial", 0.0f);
        PlayerPrefs.SetFloat("level1", 0.0f);
        PlayerPrefs.SetFloat("level2", 0.0f);
        PlayerPrefs.SetFloat("level3", 0.0f);
        PlayerPrefs.SetFloat("tutorialNC", 0.0f);
        PlayerPrefs.SetFloat("level1NC", 0.0f);
        PlayerPrefs.SetFloat("level2NC", 0.0f);
        PlayerPrefs.SetFloat("level3NC", 0.0f);
        PlayerPrefs.SetInt("checkpoint", 1);
        UpdateLevels();
    }

}
