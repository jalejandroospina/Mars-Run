using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Stack inventoryOne;
    void Start()
    {
        inventoryOne = new Stack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddinventoryOne(GameObject item)
    {
        inventoryOne.Push(item);

    }
    public GameObject GetinventoryOne()
    {
       return  inventoryOne.Pop() as GameObject;

    }

}
