using TMPro;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "LocalisationStaticData",fileName = "LocalisationServices")]
    public class LocalisationStaticData : ScriptableObject
    {
        public string NameLocalisation;
        public TMP_FontAsset Font;
        public string DrawingForTwo;
        public string Drawing;
        public string BlueWin;
        public string RedWin;
    }
}
