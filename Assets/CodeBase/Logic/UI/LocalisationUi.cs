using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.UI
{
    public abstract class LocalisationUi : MonoBehaviour
    {
        private LocalisationStaticData _localizationData;

        public void Construct(LocalisationStaticData localizationData) =>
            _localizationData = localizationData;

        private void Start() =>
            Localisation(_localizationData);

        protected virtual void Localisation(LocalisationStaticData _localizationData) { }
    }
}