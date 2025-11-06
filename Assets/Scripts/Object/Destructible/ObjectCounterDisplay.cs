using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCounterDisplay : MonoBehaviour
{
    [SerializeField] private Image iconRenderer;
    [SerializeField] private TextMeshProUGUI counterText;

    public void SetCounter(Sprite icon, int amount)
    {
        iconRenderer.sprite = icon;
        counterText.text = amount.ToString();
    }
}
