///updates the XP bar UI 

using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour {

  [SerializeField] private Slider xpBarSlider;
  [SerializeField] private Gradient gradient;
  [SerializeField] private Image fill;
  [SerializeField] private TMPro.TextMeshProUGUI xpText;
  [SerializeField] private TMPro.TextMeshProUGUI levelText;

  private void Start() {

  }


  private void Update() {

  }

  public void SetXPBar(float pXP, int pLevel) {
    xpBarSlider.value = pXP;
    fill.color = gradient.Evaluate(xpBarSlider.normalizedValue);
    xpText.text = $"{Mathf.Round(pXP)}/{Mathf.Round(xpBarSlider.maxValue)}";
    levelText.text = pLevel.ToString();
  }

  public void ResetXPBar(float pMaxXP, int pLevel) {
    xpBarSlider.maxValue = pMaxXP;
    xpBarSlider.value = 0;
    fill.color = gradient.Evaluate(1f);
    xpText.text = $"0/{Mathf.Round(pMaxXP)}";
    levelText.text = pLevel.ToString();
  }
}
