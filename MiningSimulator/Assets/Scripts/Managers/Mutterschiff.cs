using UnityEngine;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour
{
    public float totalResources = 0f;
    public Text totalResourcesText;

    void Start()
    {
        UpdateUI();
    }

    public void ReceiveResources(float amount)
    {
        totalResources += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        totalResourcesText.text = $"Gesamte Ressourcen: {totalResources:F1}";
    }
}
