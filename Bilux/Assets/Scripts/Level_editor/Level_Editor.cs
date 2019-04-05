using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Level_Editor : MonoBehaviour {


    public GameObject normalBlock, destructibleBlock, destructibleT1, hookBlock, bouncyBlock;
    private GameObject block;
    private Vector3 mousePos;
    private GameObject blockInstance;
    private level_saver levelSaver;
    private string path;
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

    List<GameObject> blocks = new List<GameObject>();



    void Start ()
    {
        levelSaver = GetComponent<level_saver>(); //Crea la lista (array dinamico)
        path = Application.persistentDataPath + "/save.dat"; //Indica el path relativo donde se van a guardar los niveles
        normalButton.onClick.AddListener(delegate { SelectBlock(BlockName.normalBlock); });
        destructibleButton.onClick.AddListener(delegate { SelectBlock(BlockName.destructibleBlock); });
        destructibleT1Button.onClick.AddListener(delegate { SelectBlock(BlockName.destructibleTriangle1); });
        hookButton.onClick.AddListener(delegate { SelectBlock(BlockName.hooKBlock); });
        bouncyButton.onClick.AddListener(delegate { SelectBlock(BlockName.bouncyBlock); });
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            blockInstance = Instantiate(block, new Vector3( (int) mousePos.x, (int) mousePos.y, 0), new Quaternion(0, 0, 0, 1)); //Crea una nueva instancia de un prefab bloque

            blocks.Add(blockInstance); //Añade la instancia del prefab a una lista que despues sera cargada en bytes a un archivo.
        }

        if (Input.GetButtonDown("Save"))
        {
            GuardaNivel();
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

    public void GuardaNivel()
    {
        StreamWriter text = new StreamWriter("text.txt", true);

        for (int i = 0; i < blocks.Count; i++)
        {
            //File.WriteAllText("text.txt", string.Empty);
           
           text.WriteLine(blocks[i].name + "," + blocks[i].transform.position.x.ToString() + "," + blocks[i].transform.position.y.ToString() + "," + blocks[i].transform.position.z.ToString() + "," + blocks[i].transform.rotation.ToString() + ";;", false);

        }
        text.Close();
    }
}
