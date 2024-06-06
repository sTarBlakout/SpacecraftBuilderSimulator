using System;
using SpacecraftComponents;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ComponentPickButton : MonoBehaviour
    {
        private Action<SpacecraftComponent> _onClickedCallback;
        private SpacecraftComponent _spacecraftComponent;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public ComponentPickButton Init(SpacecraftComponent spacecraftComponent)
        {
            GetComponentInChildren<Text>().text = $"{spacecraftComponent.GetComponentType()}\n \"{spacecraftComponent.Name}\"";
            _spacecraftComponent = spacecraftComponent;
            return this;
        }

        public ComponentPickButton SetOnClickedCallback(Action<SpacecraftComponent> onClickedCallback)
        {
            _onClickedCallback = onClickedCallback;
            return this;
        }

        private void OnClick()
        {
            _onClickedCallback?.Invoke(_spacecraftComponent);
        }
    }
}
