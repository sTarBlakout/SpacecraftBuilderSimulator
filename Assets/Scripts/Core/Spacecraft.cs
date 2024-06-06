using System;
using System.Collections.Generic;
using System.Linq;
using SpacecraftComponents;
using UnityEngine;

namespace Core
{
    // Spacecraft class which isn't used a lot in this demo, but can be developed for real game.
    public class Spacecraft
    {
        private List<SpacecraftComponent> _components;

        public Spacecraft()
        {
            _components = new List<SpacecraftComponent>();
        }

        public float GetStatPower(ComponentType stat)
        {
            var neededComponents = _components.Where(c => c.GetComponentType() == stat);
            var power = neededComponents.Sum(component => stat switch
            {
                ComponentType.Motor => ((Motor)component).Power,
                ComponentType.LivingArea => ((LivingArea)component).Capacity,
                ComponentType.Shield => ((Shield)component).Durability,
                ComponentType.Cannon => ((Cannon)component).Damage,
                _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
            });
            
            return power;
        }

        public int GetComponentsAmount(ComponentType componentType)
        {
            return _components.Count(component => component.GetComponentType() == componentType);
        }

        public bool TryAddComponent(SpacecraftComponent component, out string failReason)
        {
            if (component.CanBeAdded(this, out failReason))
            {
                _components.Add(component);
                return true;
            }
            
            return false;
        }
    }
}
