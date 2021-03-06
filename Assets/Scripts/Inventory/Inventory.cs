﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int maxSize = 4;
    [SerializeField]
    private List<Item> itemList;

    public List<Item> ItemList
    {
        get
        {
            return itemList;
        }

        set
        {
            itemList = value;
        }
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }

    public Item PopItem(int index)
    {
        if (index >= itemList.Count)
            return null;
        Item item = itemList[index];
        itemList.RemoveAt(index);
        return item;
    }

    public Item GetItem(int index)
    {
        if (index >= itemList.Count)
            return null;
        Item item = itemList[index];
        return item;
    }

    public string ItemNames()
    {
        string output = "";
        foreach (Item item in ItemList)
        {
            output += item.name + "\n";
        }
        return output;
    }

    public bool IsFull()
    {
        return itemList.Count >= maxSize;
    }
}
