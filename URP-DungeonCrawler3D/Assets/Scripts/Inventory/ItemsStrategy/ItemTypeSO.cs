///defines a ccriptable object class for item types in the inventory

using UnityEngine;

[CreateAssetMenu(menuName = "ItemType/item")]
public class ItemTypeSO : ScriptableObject {
  public string itemName;

  public virtual void Use(GameObject user) {
    Debug.Log("Using item: " + itemName);
  }
}
