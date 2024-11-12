using UnityEngine;

[CreateAssetMenu(fileName = "NewPlanetData", menuName = "ScriptableObjects/PlanetData", order = 1)]
public class PlanetData : ScriptableObject
{
    public string planetName;
    public Sprite planetSprite;
    public ResourceType resourceType;
    public float baseResourceAmount;
    public float baseMiningSpeed;
    public float miningSpeedUpgradeCost;
    public float planetPurchaseCost;
}
