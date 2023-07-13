using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Localisation
{
    public class LocalisationServices
    {
        private Dictionary<string, LocalisationStaticData> _localisationData;

        public void Load() =>
            _localisationData = Resources
                .LoadAll<LocalisationStaticData>(PathManager.LocalisationDataPath)
                .ToDictionary(x => x.NameLocalisation, x => x);

        public LocalisationStaticData GetLocalisationData(string nameLocalisation) =>
            _localisationData.TryGetValue(nameLocalisation, out LocalisationStaticData staticData)
                ? staticData
                : null;
    }
}