///show blood when player hurt event observer pattern

using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
  public Health health;
  [SerializeField] private GameObject blood;

  private void OnEnable() {
    health.playerHurt += ShowBlood;
  }

  private void OnDisable() {
    health.playerHurt -= ShowBlood;
  }

  private void ShowBlood() {
    StartCoroutine(Bloodtimer());
  }

  IEnumerator Bloodtimer() {
    blood.SetActive(true);

    yield return new WaitForSeconds(0.5f);

    blood.SetActive(false);
  }
}
