using System;
using System.Collections.Generic;

namespace LevvionSimple
{
	/// <summary>
	/// An enum denoting how the evalution should compare values in LevvionSimple.
	/// </summary>
	public enum ComparisonType
	{
		/// <summary>
		/// If the two values are equal....
		/// </summary>
		Equals,
		/// <summary>
		/// If the two values are not equal....
		/// </summary>
		NotEquals,
		/// <summary>
		/// If the real value is less than the desired value...
		/// </summary>
		LessThan,
		/// <summary>
		/// If the real value is greater than the desired value...
		/// </summary>
		GreaterThan,
		/// <summary>
		/// If the real value is less than or equal to the desired value...
		/// </summary>
		LessThanOrEquals,
		/// <summary>
		/// If the real value is greater than or equal to the desired value...
		/// </summary>
		GreaterThanOrEquals,
	}

	/// <summary>
	/// The base conditional for use in LevvionAI. All conditionals must inherit from this.
	/// </summary>
	public class LevvionConditional
	{
		/// <summary>
		/// The state of the AI.
		/// </summary>
		protected LevvionState State;
		
		/// <summary>
		/// Occurs when [actions].
		/// </summary>
		protected event Action Actions;

		/// <summary>
		/// Initializes a new instance of the <see cref="LevvionConditional"/> class.
		/// </summary>
		public LevvionConditional()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LevvionConditional"/> class.
		/// </summary>
		/// <param name="action">The action to be carried out when the conditional evaluates as true.</param>
		public LevvionConditional(Action action)
		{
			AddAction(action);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LevvionConditional"/> class.
		/// </summary>
		/// <param name="actions">The list of actions to be carried out when the conditional evaluates as true..</param>
		public LevvionConditional(List<Action> actions)
		{
			foreach (var action in actions)
			{
				AddAction(action);
			}
		}

		/// <summary>
		/// Sets the state to be used for evaluation.
		/// </summary>
		/// <param name="state">The state.</param>
		public virtual void SetState(LevvionState state)
		{
			State = state;
		}

		/// <summary>
		/// Adds an action to the list of actions to call.
		/// </summary>
		/// <param name="action">The action.</param>
		public void AddAction(Action action)
		{
			if (action != null)
			{
				Actions += action;
			}
		}

		/// <summary>
		/// Frees actions. Call this to ensure memory leaks are handled.
		/// </summary>
		public void FreeActions()
		{
			Actions = null;
		}

		/// <summary>
		/// Calls all actions in the list of actions.
		/// </summary>
		public void CallActions()
		{
			if (Actions != null)
			{
				Actions();
			}
		}
		
		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		public virtual bool Evaluate()
		{
			return false;
		}

		/// <summary>
		/// Update the conditional if necessary.
		/// </summary>
		/// <param name="deltatime">The deltatime.</param>
		public virtual void Update(float deltatime)
		{

		}
	}
}
