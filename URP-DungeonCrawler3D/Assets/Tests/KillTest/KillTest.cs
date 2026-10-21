using UnityEngine;

public class KillTest : MonoBehaviour {
 
  [SerializeField] private GameObject blue;
  [SerializeField] private GameObject purple;
  [SerializeField] private GameObject red;

  void Start() {
    
  }

  void Update() {
    CheckKey();
  }

  void CheckKey() {
    if (Input.GetKeyDown("1")) {
      GameObject newBlue = Instantiate(blue, transform.position, Quaternion.identity);
      newBlue.GetComponent<EnemyDrop>().enabled = false;
      newBlue.GetComponent<EnemyGiveXP>().enabled = false;
    }
    else if (Input.GetKeyDown("2")) {
      GameObject newPurple = Instantiate(purple, transform.position, Quaternion.identity);
      newPurple.GetComponent<EnemyDrop>().enabled = false;
      newPurple.GetComponent<EnemyGiveXP>().enabled = false;
    }
    else if (Input.GetKeyDown("3")) {
      GameObject newRed = Instantiate(red, transform.position, Quaternion.identity);
      newRed.GetComponent<EnemyGiveXP>().enabled = false;
    }
  }
}
