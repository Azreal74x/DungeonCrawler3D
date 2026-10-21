///updates the quest UI

using UnityEngine;

public class UpdateQuestUI : MonoBehaviour {

  [SerializeField] Quests quests;
  public TMPro.TMP_Text killCountText;
  public TMPro.TMP_Text keyCountText;

  void Start() { 
    quests.killQuestNewKill += UpdateKillQuestText;
    quests.killQuestComplete += UpdateKillQuestText;
    quests.keyQuestComplete += UpdateKeyQuestText;
  }
  void UpdateKillQuestText() {
    killCountText.text = "Kill 10 dragons " + quests.killCount + "/" + quests.maxKillCount;
  }

  void UpdateKeyQuestText() {
    keyCountText.text = "Find the exit key " + quests.keyCount + "/" + quests.maxKeyCount;
  }

}
