﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject inventoryUI = null;
    public GameObject flashlight = null;
    List<GameObject> items = new List<GameObject>();
    GameObject equippedItem = null;
    Vector3 eqippedItemPos = new Vector3(1.27f, -0.6f, 1.38f);

    void Start()
    {
        ToggleInventoryUI(); // Disable inventory UI at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryUI();
        }
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        if (equippedItem == null)
        {
            EquipItem(item);
        }
        else
        {
            UnequipItem(item);
        }
    }

    void EquipItem(GameObject item)
    {
        item.SetActive(true);
        item.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = eqippedItemPos;
        equippedItem = item;

        // Enable flashlight effect
        if (equippedItem.gameObject.name == "Flashlight" && flashlight != null)
        {
            flashlight.SetActive(true);
        }
    }

    void UnequipItem(GameObject item)
    {
        item.SetActive(false);
        item.transform.parent = GameObject.FindGameObjectWithTag("Inventory").transform;
        equippedItem = null;

        // Disable flashlight effect
        if (item.gameObject.name == "Flashlight" && flashlight != null)
        {
            flashlight.SetActive(false);
        }
    }

    void ToggleInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    
}
