using System;
using System.Collections.Generic;
//using Assets.Scripts.Controllers.Interface;
//using Assets.Scripts.Utils.Enums;
//using Assets.Scripts.Utils.HeroAnimations;
using UnityEngine;

namespace Assets.Scripts.Controllers.Implementation
{
    public class HeroAnimationController : MonoBehaviour//, IHeroAnimationController
    {
        protected Animator AnimatorComp { get; set; }
        protected Dictionary<AnimationType, Action> TypeChoose;
        protected Dictionary<AnimationType, Action> StopChoose;
        protected const string ERROR_MESSAGE = "You are trying to call unspecific animation. There is unexpected flow, please, do not use this class to make specific calls: HeroAnimationController.cs";
        public virtual void PlayReactionDependsOnType(AnimationType type)
        {
            //Bad code
            if (TypeChoose == null)
            {
                //if (type == AnimationType.Idle)
                //{
                //    PlayIdle();
                //    return;
                //}
            }
            if (!TypeChoose.ContainsKey(type))
            {
                var msg = ERROR_MESSAGE + ". Unspecified type: " + type.ToString();
                throw new Exception(ERROR_MESSAGE);
            }
            TypeChoose[type].Invoke();
        }
        public virtual void StopAnimationDependsOnType(AnimationType type)
        {
            if (!StopChoose.ContainsKey(type))
            {
                throw new Exception(ERROR_MESSAGE);
            }
            StopChoose[type].Invoke();
        }
        protected virtual void PlayIdle()
        {
            //GetAnimatorComponent();
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.IDLE_TRIGGER);
        }

        protected virtual void PlayMove()
        {
            //GetAnimatorComponent(false);
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.MOVE_TRIGGER);
            //AnimatorComp.SetBool(HeroAnimationsKeys.ENABLE_WALK_FLAG, true);
        }
        protected virtual void StopMove()
        {
            //GetAnimatorComponent(false);
            //AnimatorComp.SetBool(HeroAnimationsKeys.ENABLE_WALK_FLAG, false);
        }

        protected virtual void PlayDance()
        {
            //Debug.Log("start play dance");
            //GetAnimatorComponent(false);
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.DANCE_TRIGGER);
        }
        protected virtual void PlayBadReaction()
        {
            //GetAnimatorComponent(false);
           // AnimatorComp.SetTrigger(HeroAnimationsKeys.NEGATIVE_TRIGGER);
        }

        protected virtual void PlayGoodReaction()
        {
            //ssswwdaawdasdqGetAnimatorComponent(false);
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.POSITIVE_TRIGGER);
        }

        protected virtual void PlayInteraction()
        {
            ////////ssswwdaawdasdqGetAnimatorComponent(false);
            //////ssswwdaawdasdqAnimatorComp.SetTrigger(HeroAnimationsKeys.INTERACTION_TRIGGER);
        }

        public virtual void SetIsDanceLoop(bool state)
        {
           ////ssswwdaawdasdq Debug.Log("start play dance");
           ////ssswwdaawdasdq GetAnimatorComponent(false);
            //AnimatorComp.SetBool(HeroAnimationsKeys.IS_DANCE_LOOP_FLAG, state);
        }

        protected virtual void PlaySeparetedAppearance()
        {

        }
        public virtual void SetAnimatorEnable(bool state)
        {
            GetAnimatorComponent(false);
            AnimatorComp.enabled = state;
        }

        protected virtual void PlayPartner()
        {
            //GetAnimatorComponent(false);
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.PARTNER_TRIGGER);
        }

        protected virtual void PlayDisco()
        {
            //GetAnimatorComponent(false);
            //AnimatorComp.SetTrigger(HeroAnimationsKeys.DISCO_TRIGGER);
        }

        protected virtual void Start()
        {
            GetAnimatorComponent(false);
            TypeChoose = new Dictionary<AnimationType, Action>
            {
                //{AnimationType.Idle, PlayIdle },
                //{AnimationType.Interaction, PlayInteraction },
                //{AnimationType.Negative, PlayBadReaction },
                //{AnimationType.Positive, PlayGoodReaction },
                //{AnimationType.Dance, PlayDance },
                //{AnimationType.Appearence, PlaySeparetedAppearance },
                //{AnimationType.Walk, PlayMove },
                //{AnimationType.Partner, PlayPartner},
                //{AnimationType.Disco,  PlayDisco}
            };
            StopChoose = new Dictionary<AnimationType, Action>
            {
                //{ AnimationType.Walk, StopMove },
            };
        }
        protected virtual void GetAnimatorComponent(bool isForce = true)
        {
            if(AnimatorComp != null && !isForce)
            {
                return;
            }
            var animator = gameObject.GetComponent<Animator>();
            AnimatorComp = animator;
        }

        internal void PlayReactionDependsOnType()
        {
            throw new NotImplementedException();
        }

        internal void StopAnimationDependsOnType()
        {
            throw new NotImplementedException();
        }
    }
}
