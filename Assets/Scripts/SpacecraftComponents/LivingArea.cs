using Core;
using UnityEngine;

namespace SpacecraftComponents
{
    [CreateAssetMenu(fileName = "LivingArea", menuName = "SpacecraftComponents/LivingArea")]
    public class LivingArea : SpacecraftComponent
    {
        [SerializeField] protected int capacity; // Some dummy attribute, which can be used in real game

        public int Capacity => capacity;

        public override ComponentType GetComponentType()
        {
            return ComponentType.LivingArea;
        }

        public override bool CanBeAdded(Spacecraft spacecraft, out string failReason)
        {
            failReason = "";
            var canBeAdded = spacecraft.GetComponentsAmount(ComponentType.Motor) >= (spacecraft.GetComponentsAmount(ComponentType.LivingArea) + 1) * 2;
            if (!canBeAdded) failReason = "A living area can only be added if you have twice the number of motors!";
            return canBeAdded;
        }
    }
}
