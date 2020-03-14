using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Implementation.Hero
{
    public class PaintHeroController: HeroController
    {
        public List<GameObject> MappingObjects;
        private List<Object> _mappingControllers;


        protected override void Awake()
        {
            base.Awake();
            _mappingControllers = new List<Object>();
        }

        protected override void ScanningSceneHeroInit()
        {
            base.ScanningSceneHeroInit();

            for (var i = 0; i < MappingObjects.Count; i++)
            {
                var _mappingController = MappingObjects[i].AddComponent<MonoBehaviour>();
                _mappingControllers.Add(_mappingController);
            }
            MappingObjects.Clear();
        }

        public void InitCamera(Camera renderCamera)
        {
            for (var i = 0; i < _mappingControllers.Count; i++)
            {
              //  _mappingControllers[i].RenderCamera = renderCamera;
            }
        }
    }
}
