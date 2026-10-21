///manages player inventory, including adding and using items

using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour {

  public Dictionary<ItemTypeSO, int> items = new();

  public event Action<ItemTypeSO, int> onItemCountChanged;

  [SerializeField] private ItemTypeSO testHealthPotionSO;
  [SerializeField] private ItemTypeSO testBurnResistanceSO;

  [SerializeField] private GameObject inventoryUI;
  private void Start() {

  }

  private void Update() {
    CheckKeyInput();
  }

  public void Add(ItemTypeSO itemType) {
    if (!items.ContainsKey(itemType))
      items[itemType] = 0;

    items[itemType]++;
    onItemCountChanged?.Invoke(itemType, items[itemType]);
  }

  public bool TryUse(ItemTypeSO itemType) {
    if (!items.ContainsKey(itemType) || items[itemType] <= 0)
      return false;

    items[itemType]--;
    onItemCountChanged?.Invoke(itemType, items[itemType]);

    itemType.Use(gameObject);

    return true;
  }

  void CheckKeyInput() {

    //inventory showing toggle
    if (Input.GetKeyDown(KeyCode.I)) {
      if(inventoryUI.transform.localScale == new Vector3(0,0,0))
        inventoryUI.transform.localScale = new Vector3(1,1,1);
      else
        inventoryUI.transform.localScale = new Vector3(0,0,0);
    }

    if (Input.GetKeyDown("1")) {
      if (TryUse(testHealthPotionSO)) {
        Debug.Log("Used health potion!");
      }
      else {
        Debug.Log("No health potions in inventory!");
      }
    }

    if (Input.GetKeyDown("2")) {
      if (TryUse(testBurnResistanceSO)) {
        Debug.Log("Used burn resistance!");
      }
      else {
        Debug.Log("No burn resistance in inventory!");
      }
    }
  }
}
