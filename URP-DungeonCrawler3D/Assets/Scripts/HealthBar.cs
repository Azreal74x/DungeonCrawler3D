///updates the UI health bar 

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

  [SerializeField] private Slider healthBarSlider;
  [SerializeField] private Gradient gradient;
  [SerializeField] private Image fill;

  private void Start() {
    
  }


  private void Update() {

  }

  public void SetHealthBar(float pHealth) {
    healthBarSlider.value = pHealth;
    fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);
  }

  public void SetMaxHealthBar(float pMaxHealth) {
    healthBarSlider.maxValue = pMaxHealth;
    healthBarSlider.value = pMaxHealth;
    fill.color = gradient.Evaluate(1f);
  }
}