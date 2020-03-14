using System.Collections.Generic;
//using Assets.Scripts.Containers.Objects;
//using Assets.Scripts.Controllers.Interface;
//using Assets.Scripts.DataModels.MonsterSettings.SubSettings;
using Assets.Scripts.Utils;
using Assets.Scripts.Utils.CouplesHandlers;
//using Assets.Scripts.Utils.Enums;
//using Lean.Touch;
using UnityEngine;

namespace Assets.Scripts.Controllers.Implementation
{
    [RequireComponent(typeof(HeroAnimationController), typeof(HeroMovementController))]
    public class HeroController : MonoBehaviour//, IHeroController
    {
        public HeroAnimationController HeroAnimationController;
        public HeroMovementController HeroMovementController;
        public DominantRecessiveContainerHolder Container;
        public MonsterType WhoAmI;
        public string VuforiaId { get; set; }
        //public Dictionary<MonsterType, AnimationType> ReactionDictionary { get; set; }
       // public MonsterSettingsObject MonsterSettings;

        public void SetFixedJoystickComp(FixedJoystick fixedJoystick)
        {
            HeroMovementController.FixedJoystickComp = fixedJoystick;
        }

        protected virtual void Awake()
        {
            //ReactionDictionary = new Dictionary<MonsterType, AnimationType>();

            HeroMovementController.OnStartMove = HandleStartMove;
            HeroMovementController.OnStopMove = HandleStopMove;

        }

        public void LookAt(Transform transform)
        {
            gameObject.transform.LookAt(transform);
            var Quat = gameObject.transform.localRotation;
            Quat.x = 0;
            Quat.z = 0;
            gameObject.transform.localRotation = Quat;
        }

        public void Initialize(SceneType monsterUseType)
        {
            switch (monsterUseType)
            {
                //case SceneType.ScanningScene:
                //    {
                //        ScanningSceneHeroInit();
                //        break;
                //    }
                //case SceneType.CollectionScene:
                //    {
                //        CollectionSceneHeroInit();
                //        break;
                //    }
                //case SceneType.TamagochiScene:
                //    {
                //        TamagochiSceneHeroInit();
                //        break;
                //    }
                //case SceneType.PortalScene:
                //    {
                //        PortalSceneHeroInit();
                //        break;
                //    }
            }
        }
        protected virtual void ScanningSceneHeroInit()
        {
            //var settings = MonsterSettings.ScanningSceneSettings;

            //SetTransfromFromSettings(settings.StartTransformSettings);

            //SetMovementControllerSettings(settings.MovementSettingsSettings);

            //var leanSelect = gameObject.AddComponent<LeanSelectable>();
            //var leanScale = gameObject.AddComponent<LeanScale>();

            //leanScale.IgnoreStartedOverGui = false;
            //leanScale.RequiredFingerCount = 2;
            //leanScale.RequiredSelectable = leanSelect;
            //leanScale.ScaleClamp = true;

            ////leanScale.ScaleMin = MonsterSettings.ScanningSceneSettings.GetScaleMin();
            ////leanScale.ScaleMax = MonsterSettings.ScanningSceneSettings.GetScaleMax();

            //AddCollider(settings.ColliderSettingsSettingsObject);
        }
        protected virtual void CollectionSceneHeroInit()
        {
            //var settings = MonsterSettings.CollectionSceneSettings;

            //SetTransfromFromSettings(settings.StartTransformSettings);

            //SetMovementControllerSettings(settings.MovementSettingsSettings);

            //HeroAnimationController.PlayReactionDependsOnType(AnimationType.Idle);
        }
        protected virtual void TamagochiSceneHeroInit()
        {
            //var settings = MonsterSettings.TamagochiSceneSettings;

            //SetTransfromFromSettings(settings.StartTransformSettings);

            //SetMovementControllerSettings(settings.MovementSettingsSettings);

            //AddCollider(settings.ColliderSettingsSettingsObject);

            //gameObject.AddComponent<TamagochiController>();
            //AddRigidBody();
        }
        protected virtual void PortalSceneHeroInit()
        {
            //var settings = MonsterSettings.PortalSceneSettingsObject;

            //SetTransfromFromSettings(settings.StartTransformSettings);

            //SetMovementControllerSettings(settings.MovementSettingsSettings);

            //HeroAnimationController.PlayReactionDependsOnType(AnimationType.Idle);

            //AddCollider(settings.ColliderSettingsSettingsObject);


            //var portalHeroController = gameObject.AddComponent<PortalHeroController>();
        }

       private void SetMovementControllerSettings(MovementSettingsSettingsObject settings)
        {
            //HeroMovementController.Speed = settings.Speed;
            //HeroMovementController.MoveEnabled = settings.MoveEnabled;
        }
        private void SetTransfromFromSettings(StartTransformSettingsObject settings)
        {
            //gameObject.transform.position = settings.GetPosition();
            //gameObject.transform.Rotate(new Vector3(0, 1, 0), settings.RotationAngle);
            //gameObject.transform.localScale = settings.GetScale();
        }
        private void AddCollider(ColliderSettingsSettingsObject settings)
        {
            //var collider = gameObject.AddComponent<CapsuleCollider>();
            //collider.center = settings.GetCenter();
            //collider.radius = settings.Radius;
            //collider.height = settings.Height;
        }
        private void AddRigidBody()
        {
            var rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        }

        private void HandleStartMove() => HeroAnimationController.PlayReactionDependsOnType();// AnimationType.Walk);

        private void HandleStopMove() => HeroAnimationController.StopAnimationDependsOnType();// AnimationType.Walk);
    }
}
