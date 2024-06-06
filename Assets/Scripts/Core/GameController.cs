using System.Linq;
using SpacecraftComponents;
using UI;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameData data;
        [SerializeField] private ManagerUI managerUI; // Ofc it's better to have some abstract reference here, but to not complicate structure in this task I leave direct references :)

        private Spacecraft _currentSpacecraft;
        
        private void Start()
        {
            _currentSpacecraft = new Spacecraft();
            managerUI.InitComponents(data.SpacecraftComponents, ProcessAddingComponent)
                .SetClearCallback(ClearCreation);
        }

        private void ProcessAddingComponent(SpacecraftComponent component)
        {
            if (_currentSpacecraft.TryAddComponent(component, out var failReason))
            {
                managerUI.UpdateInfoText($"{component.GetComponentType() } with name \'{component.Name}\' is added!");
                managerUI.UpdateStat(component.GetComponentType(), _currentSpacecraft.GetStatPower(component.GetComponentType()));
                managerUI.AddComponentButton(component);
            }
            else
            {
                managerUI.UpdateInfoText($"{component.GetComponentType() } with name \'{component.Name}\' currently cannot be added! Reason: {failReason}");
            }
        }

        private void ClearCreation()
        {
            _currentSpacecraft = new Spacecraft();
        }
    }
}
