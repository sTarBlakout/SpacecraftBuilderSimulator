using Core;
using UnityEngine;

namespace SpacecraftComponents
{
    [CreateAssetMenu(fileName = "Cannon", menuName = "SpacecraftComponents/Cannon")]
    public class Cannon : SpacecraftComponent
    {
        [SerializeField] protected float damage; // Some dummy attribute, which can be used in real game

        public float Damage => damage;

        public override ComponentType GetComponentType()
        {
            return ComponentType.Cannon;
        }

        // "A shield is always added before a cannon!", as I understood there should at least one shield before adding a cannon?
        // If it should be always a shield before a cannon, then "canBeAdded" should be this way:
        // var canBeAdded = spacecraft.GetComponentsAmount(ComponentType.Shield) > spacecraft.GetComponentsAmount(ComponentType.Cannon);
        public override bool CanBeAdded(Spacecraft spacecraft, out string failReason)
        {
            failReason = "";
            var canBeAdded = spacecraft.GetComponentsAmount(ComponentType.Shield) > 0;
            if (!canBeAdded) failReason = "A shield is always added before a cannon!";
            return canBeAdded;
        }
    }
}
