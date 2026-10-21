///observer pattern to handle game over event

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public Health health;

  private void OnEnable() {
    health.onDie += EndGame;
  }

  private void OnDisable() {
    health.onDie -= EndGame;
  }

  private void EndGame() {
    SceneManager.LoadScene("Demo_Scene");
  }
}
