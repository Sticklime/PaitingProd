using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class Gradient : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI _textMeshPro;
        [SerializeField] public Gradient _gradient;
    
        private void Update()
        {
            float t = Mathf.PingPong(Time.time, 1f);
        }
    }
}