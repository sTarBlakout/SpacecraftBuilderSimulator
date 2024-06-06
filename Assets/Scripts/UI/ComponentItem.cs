using SpacecraftComponents;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ComponentItem : MonoBehaviour
    {
        [SerializeField] private Text nameText;
        [SerializeField] private Image image;
        
        public void Init(SpacecraftComponent component)
        {
            nameText.text = component.Name;
            image.sprite = component.Icon;
        }
    }
}
