using System;
using System.Collections.Generic;
using SpacecraftComponents;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class ManagerUI : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Button componentButtonPrefab;
        [SerializeField] private ComponentItem componentItemPrefab;
        
        [Header("General Components")]
        [SerializeField] private Text infoText;
        [SerializeField] private Button clearButton;
        
        [Header("Containers")]
        [SerializeField] private Transform componentsButtonContainer;
        [SerializeField] private Transform motorsContent;
        [SerializeField] private Transform livingAreasContent;
        [SerializeField] private Transform cannonsContent;
        [SerializeField] private Transform shieldsContent;
        
        [Header("Stats")]
        [SerializeField] private Text cannonDamageText;
        [SerializeField] private Text enginePowerText;
        [SerializeField] private Text shieldDurabilityText;
        [SerializeField] private Text personnelCapacityText;

        private Action _clearCallback;

        private void Start()
        {
            clearButton.onClick.AddListener(OnClearClicked);
        }

        public ManagerUI InitComponents(List<SpacecraftComponent> spacecraftComponents, Action<SpacecraftComponent> onComponentClicked)
        {
            foreach (var upgrade in spacecraftComponents)
            {
                var btn = Instantiate(componentButtonPrefab, componentsButtonContainer);
                btn.GetComponent<ComponentPickButton>().Init(upgrade).SetOnClickedCallback(onComponentClicked);
            }

            return this;
        }

        public void UpdateInfoText(string text)
        {
            infoText.text = text;
        }

        public void UpdateStat(ComponentType stat, float value)
        {
            switch (stat)
            {
                case ComponentType.Motor: enginePowerText.text = $"Engine Power: {value}"; break;
                case ComponentType.LivingArea: personnelCapacityText.text = $"Personnel Capacity: {value}"; break;
                case ComponentType.Shield: shieldDurabilityText.text = $"Shield Durability: {value}"; break;
                case ComponentType.Cannon: cannonDamageText.text = $"Cannon Damage: {value}"; break;
                default: throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
        }

        public ManagerUI SetClearCallback(Action callback)
        {
            _clearCallback = callback;
            return this;
        }

        public void AddComponentButton(SpacecraftComponent component)
        {
            var contentTransform = component.GetComponentType() switch
            {
                ComponentType.Motor => motorsContent,
                ComponentType.LivingArea => livingAreasContent,
                ComponentType.Shield => shieldsContent,
                ComponentType.Cannon => cannonsContent,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Instantiate(componentItemPrefab, contentTransform).Init(component);
            
        }

        private void OnClearClicked()
        {
            DestroyAllChildren(motorsContent);
            DestroyAllChildren(livingAreasContent);
            DestroyAllChildren(cannonsContent);
            DestroyAllChildren(shieldsContent);
            
            UpdateStat(ComponentType.Motor, 0);
            UpdateStat(ComponentType.LivingArea, 0);
            UpdateStat(ComponentType.Shield, 0);
            UpdateStat(ComponentType.Cannon, 0);
            
            _clearCallback?.Invoke();
        }

        private void DestroyAllChildren(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
