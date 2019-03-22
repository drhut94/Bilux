using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Editor : MonoBehaviour {


    public GameObject normalBlock, destructibleBlock, destructibleT1, hookBlock, bouncyBlock;
    private GameObject block;
    private Vector3 mousePos;
    public Button normalButton, destructibleButton, destructibleT1Button, hookButton, bouncyButton;
    [HideInInspector]
    public enum BlockName
    {
        destructibleBlock,
        normalBlock,
        destructibleTriangle1,
        hooKBlock,
        bouncyBlock
    }





	void Start ()
    {
        normalButton.onClick.AddListener(delegate { SelectBlock(BlockName.normalBlock); });
        destructibleButton.onClick.AddListener(delegate { SelectBlock(BlockName.destructibleBlock); });
        destructibleT1Button.onClick.AddListener(delegate { SelectBlock(BlockName.destructibleTriangle1); });
        hookButton.onClick.AddListener(delegate { SelectBlock(BlockName.hooKBlock); });
        bouncyButton.onClick.AddListener(delegate { SelectBlock(BlockName.bouncyBlock); });
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(block, new Vector3(mousePos.x, mousePos.y, 0), new Quaternion(0, 0, 0, 1));
        }
    }

    public void SelectBlock(BlockName blockname)
    {
        switch (blockname)
        {
            case BlockName.normalBlock:
                block = normalBlock;
                break;
            case BlockName.destructibleBlock:
                block = destructibleBlock;
                break;
            case BlockName.destructibleTriangle1:
                block = destructibleT1;
                break;
            case BlockName.hooKBlock:
                block = hookBlock;
                break;
            case BlockName.bouncyBlock:
                block = bouncyBlock;
                break;
        }
    }
}
