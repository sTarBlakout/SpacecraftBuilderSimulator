using System;
using Core;
using UnityEngine;

namespace SpacecraftComponents
{
    [CreateAssetMenu(fileName = "Motor", menuName = "SpacecraftComponents/Motor")]
    public class Motor : SpacecraftComponent
    {
        [SerializeField] protected float power; // Some dummy attribute, which can be used in real game

        public float Power => power;

        public override ComponentType GetComponentType()
        {
            return ComponentType.Motor;
        }

        public override bool CanBeAdded(Spacecraft spacecraft, out string failReason)
        {
            failReason = "";
            return true;
        }
    }
}
