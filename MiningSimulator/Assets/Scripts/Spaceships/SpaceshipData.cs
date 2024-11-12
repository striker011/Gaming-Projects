using UnityEngine;

[CreateAssetMenu(fileName = "NewSpaceshipData", menuName = "ScriptableObjects/SpaceshipData", order = 2)]
public class SpaceshipData : ScriptableObject
{
    public string spaceshipName;
    public Sprite spaceshipSprite;
    public float baseCargoSize;
    public float baseSpeed;
    public float cargoUpgradeCost;
    public float speedUpgradeCost;
}
