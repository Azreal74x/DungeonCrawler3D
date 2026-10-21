using UnityEngine;

public class XPTest : MonoBehaviour {

  [SerializeField] private XP xp;
  [SerializeField] private float xpAddAmount = 50f;

  [SerializeField] private TMPro.TextMeshProUGUI xpAddText;
  [SerializeField] private TMPro.TextMeshProUGUI swordStrengthText;

  void Start() {

  }

  void Update() {
    CheckKey();
    UpdateStatsText();
  }

  void CheckKey() {
    if (Input.GetKeyDown("1")) {
      xpAddAmount += 50f;
    }
    else if (Input.GetKeyDown("2")) {
      xpAddAmount -= 50f;
    }
    else if (Input.GetKeyDown("3")) {
      xp.AddXP(xpAddAmount);
    }
    else if (Input.GetKeyDown("4")) {
      xp.ResetXPStats();
    }
  }

  void UpdateStatsText() {
    xpAddText.text = "XP add amount: " + xpAddAmount;
    swordStrengthText.text = "Sword strength: " + xp.GetComponent<PlayerAttack>().swordStrength;
  }
}
