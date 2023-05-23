using TMPro;
using UnityEngine;

namespace Aviator.Code.Core.UI
{
    public class FieldText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fieldText;
        
        public void SetText(string text) => _fieldText.text = text;

        public void SetColor(Color color) => _fieldText.color = color;

        public void ResetColor() => _fieldText.color = Color.white;
    }
}