using CodeBase.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI
{
    public class LocalisationMainMenu : LocalisationUi
    {
        [SerializeField] private TMP_Text _drawingForTwo;
        [SerializeField] private TMP_Text _drawing;
   
        protected override void Localisation(LocalisationStaticData _localizationData)
        {
            _drawingForTwo.text = _localizationData.DrawingForTwo;
            _drawing.text = _localizationData.Drawing;
            
            _drawingForTwo.font = _localizationData.Font;
            _drawingForTwo.font = _localizationData.Font;
        }
    }
}