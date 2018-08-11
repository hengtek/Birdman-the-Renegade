﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SIS.States;
using SIS.Items;


namespace SIS.Characters.Sis
{
	public class Sis : Character
	{
		#region StateMachine Setup
		private StateMachine<Sis> stateMachine = new StateMachine<Sis>();
		public float delta { get { return stateMachine.delta; } }
		private new void Start()
		{
			base.Start();
			stateMachine.Init();

		}
		//Run State Machine Logic
		private void FixedUpdate()
		{
			stateMachine.FixedTick();
		}
		private void Update()
		{
			stateMachine.Tick();
		}

		#endregion

		public float health;
		//Serializable Properties
		public MovementValues movementValues;
		public Inventory inventory;

		#region MovementValues
		[System.Serializable]
		public class MovementValues
		{
			public float horizontal;
			public float vertical;
			public float moveAmount;
			public Vector3 moveDirection;
			public Vector3 lookDirection;
			public Vector3 aimPosition;
		}
		#endregion

		#region Flags and Toggles
		public bool isAiming;
		public bool isShooting;
		public bool isCrouching;
		public bool isReloading;
		public bool isInteracting;

		public void ToggleCrouching()
		{
			isCrouching = !isCrouching;
		}
		public void SetReloading()
		{
			isReloading = true;
		}
		#endregion

		//Complex Components
		[HideInInspector]
		public IKAiming aiming;

		protected override void SetupComponents()
		{
		}

		//Public Functions
		public void PlayAnimation(string targetAnim)
		{
			anim.CrossFade(targetAnim, 0.2f);
		}
	}
	[CreateAssetMenu(menuName = "Characters/Sis/Sis State")]
	public class SisState : State<Sis>
	{
		public new SisStateActions[] onFixed;
		public new SisStateActions[] onUpdate;
		public new SisStateActions[] onEnter;
		public new SisStateActions[] onExit;

		[SerializeField]
		public new List<SisTransition> transitions = new List<SisTransition>();
	}

	//Allows to be shown in GUI since Unity is anti-generics in the inspector
	public abstract class SisStateActions : StateActions<Sis> { }
	public abstract class SisCondition : Condition<Sis> { }
	[System.Serializable]
	public class SisTransition : Transition<Sis> {
		public new SisCondition condition;
		public new SisState targetState;
	}
}