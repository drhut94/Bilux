using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelScrollBehaviour : MonoBehaviour {

    public RectTransform panel; //Scroll Panel
    public Button[] button; //Level buttonns
    public RectTransform center; //Center to campare distance for each button

    private float[] distance;
    private bool dragging = false; //True when Scroll is moving
    private int buttonDistance; //mantain distance between buttons
    private int minButtonNum; // Hold Min distance of Button

	void Start () {
        int buttonLenght = button.Length;
        distance = new float[buttonLenght];

        buttonDistance = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x -
            button[0].GetComponent<RectTransform>().anchoredPosition.x);
        Debug.Log(buttonDistance);
	}
	
	
	void Update () {
		for (int i = 0; i < button.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - button[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance); //Get min distance

        for (int i = 0; i < button.Length; i++)
        {
            if (minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }

        if (!dragging)
        {
            LerpToButton(minButtonNum * -buttonDistance);
        }
	}

    void LerpToButton(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDarg()
    {
        dragging = false;
    }
}
