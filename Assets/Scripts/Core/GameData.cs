using System.Collections;
using System.Collections.Generic;
using SpacecraftComponents;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private List<SpacecraftComponent> spacecraftComponents;

    public List<SpacecraftComponent> SpacecraftComponents => spacecraftComponents;
}
