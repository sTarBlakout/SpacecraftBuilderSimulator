using Core;
using UnityEngine;

namespace SpacecraftComponents
{
    // Base abstract class for Spacecraft components, has 2 default attributes: name and sprite.
    public abstract class SpacecraftComponent : ScriptableObject
    {
        [SerializeField] protected string name;
        [SerializeField] protected Sprite icon;
        
        public string Name => name;
        public Sprite Icon => icon;

        public abstract ComponentType GetComponentType();
        public abstract bool CanBeAdded(Spacecraft spacecraft, out string failReason);
    }

    public enum ComponentType
    {
        None,
        Motor,
        LivingArea,
        Shield,
        Cannon
    }
}
