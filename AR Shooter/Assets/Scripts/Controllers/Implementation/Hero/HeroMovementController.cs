using System;
//using Assets.Scripts.Controllers.Interface;
using UnityEngine;

namespace Assets.Scripts.Controllers.Implementation
{
    public class HeroMovementController : MonoBehaviour//, IHeroMovementController
    {
        public Action OnStartMove;
        public Action OnStopMove;

        public float Speed = 0.1f;
        public FixedJoystick FixedJoystickComp { get; set; }

        public bool MoveEnabled = false;

        private bool _isStartMoving = false;
        protected void FixedUpdate()
        {
            //if (MoveEnabled && FixedJoystickComp != null)
            //{
            //    if (FixedJoystickComp.Direction != new Vector2(0, 0))
            //    {
            //        if (!_isStartMoving)
            //        {
            //            OnStartMove?.Invoke();
            //            _isStartMoving = true;
            //            Debug.Log(_isStartMoving + " start moving");
            //        }

            //        var eulerRot = Vector2.SignedAngle(new Vector2(0, 1), FixedJoystickComp.Direction);
            //        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -eulerRot, transform.localEulerAngles.z);

            //        var direction = transform.forward * Speed * (Mathf.Abs(FixedJoystickComp.Vertical) + Mathf.Abs(FixedJoystickComp.Horizontal));

            //        transform.Translate(direction, Space.World);
            //    }
            //    else
            //    {
            //        if (_isStartMoving)
            //        {
            //            OnStopMove?.Invoke();
            //            _isStartMoving = false;
            //            Debug.Log(_isStartMoving + " stop moving");
            //        }
            //    }
            //}
        }
    }
}
