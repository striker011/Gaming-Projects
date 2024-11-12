using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Planet : MonoBehaviour
{
    public PlanetData planetData;
    public bool isPurchased = false;

    private float currentResourceAmount;
    private float currentMiningSpeed;
    private float nextMiningSpeedUpgradeCost;

    // UI-Elemente
    public Text planetNameText;
    public Image planetSpriteImage;
    public Text resourceAmountText;
    public Button purchaseButton;
    public Button upgradeMiningSpeedButton;
    public Text miningSpeedText;

    void Start()
    {
        InitializePlanet();
    }

    void InitializePlanet()
    {
        planetNameText.text = planetData.planetName;
        planetSpriteImage.sprite = planetData.planetSprite;
        currentResourceAmount = planetData.baseResourceAmount;
        currentMiningSpeed = planetData.baseMiningSpeed;
        nextMiningSpeedUpgradeCost = planetData.miningSpeedUpgradeCost;
        UpdateUI();

        if (isPurchased)
        {
            purchaseButton.gameObject.SetActive(false);
            StartCoroutine(GenerateResources());
        }
        else
        {
            upgradeMiningSpeedButton.gameObject.SetActive(false);
        }
    }

    public void PurchasePlanet()
    {
        // Überprüfe, ob der Spieler genügend Ressourcen hat (muss noch implementiert werden)
        isPurchased = true;
        purchaseButton.gameObject.SetActive(false);
        upgradeMiningSpeedButton.gameObject.SetActive(true);
        StartCoroutine(GenerateResources());

        // Erstelle das Raumschiff (implementieren wir später)
        CreateSpaceship();
    }

    IEnumerator GenerateResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentResourceAmount += currentMiningSpeed;
            UpdateUI();
        }
    }

    public void UpgradeMiningSpeed()
    {
        // Überprüfe, ob der Spieler genügend Ressourcen hat (muss noch implementiert werden)
        currentMiningSpeed += planetData.baseMiningSpeed; // Oder eine andere Logik für die Erhöhung
        nextMiningSpeedUpgradeCost *= 1.5f; // Erhöhe die Upgrade-Kosten
        UpdateUI();
    }

    void UpdateUI()
    {
        resourceAmountText.text = $"Ressourcen: {currentResourceAmount:F1}";
        miningSpeedText.text = $"Abbaugeschwindigkeit: {currentMiningSpeed:F1}";
    }

    void CreateSpaceship()
    {
        // Hier instanziieren wir das Raumschiff (implementieren wir später)
    }

    public float CollectResources(float amount)
    {
        float collectedAmount = Mathf.Min(amount, currentResourceAmount);
        currentResourceAmount -= collectedAmount;
        UpdateUI();
        return collectedAmount;
    }
}
