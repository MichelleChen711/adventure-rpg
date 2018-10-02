namespace StateBehavior {
	public class StateMachine<T> {

		public State<T> currentState { get; private set; }
		public T Owner;

		// constructor
		public StateMachine (T owner) {
			Owner = owner;
			currentState = null;
		}

		public void ChangeState (State<T> newState) {
			if (currentState != null) {
				currentState.ExitState(Owner);
			}
			currentState = newState;
			currentState.EnterState(Owner);
		}

		// Update is called once per frame
		void Update () {
			if (currentState != null) {
				currentState.UpdateState(Owner);
			}
		}
	}

	// Classes of type State will inherit these methods
	public abstract class State<T> {
		public abstract void EnterState(T owner);
		public abstract void ExitState(T owner);
		public abstract void UpdateState(T owner);
	}
}