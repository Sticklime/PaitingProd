using CodeBase.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI
{
    public class LocalisationHud : LocalisationUi
    {
        [SerializeField] private TMP_Text _redWin;
        [SerializeField] private TMP_Text _blueWin;
        
        protected override void Localisation(LocalisationStaticData _localizationData)
        {
            _redWin.text = _localizationData.RedWin;
            _blueWin.text = _localizationData.BlueWin;
            
            _redWin.font = _localizationData.Font;
            _blueWin.font = _localizationData.Font;
        }
    }
}