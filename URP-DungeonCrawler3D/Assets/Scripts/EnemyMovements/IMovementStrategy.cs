///interface for different enemy movement strategies

using UnityEngine;

public interface IMovementStrategy {
  void Move(GameObject enemy, GameObject player);

}
