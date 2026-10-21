///updates the inventory UI when item counts changes

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInventoryUI : MonoBehaviour {

  public ItemTypeSO itemType;
  public TMPro.TMP_Text countText;

  //private TextMeshPro text;

  [SerializeField] private Inventory inventory;

  void Start() {
    inventory.onItemCountChanged += UpdateText;

    int count = 0;
    if (inventory.items.ContainsKey(itemType)) {
      count = inventory.items[itemType];
    }
    UpdateText(itemType, count);
  }

  private void UpdateText(ItemTypeSO changedType, int newCount) {
    if (changedType != itemType) return;
    countText.text = newCount.ToString();
  }
}
