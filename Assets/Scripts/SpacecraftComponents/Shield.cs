using Core;
using UnityEngine;

namespace SpacecraftComponents
{
    [CreateAssetMenu(fileName = "Shield", menuName = "SpacecraftComponents/Shield")]
    public class Shield : SpacecraftComponent
    {
        [SerializeField] protected float durability; // Some dummy attribute, which can be used in real game

        public float Durability => durability;

        public override ComponentType GetComponentType()
        {
            return ComponentType.Shield;
        }

        public override bool CanBeAdded(Spacecraft spacecraft, out string failReason)
        {
            failReason = "";
            return true;
        }
    }
}
