//////////////////////////////////////////////////////////////////////
//FSM.State
//by Sam Onions
//////////////////////////////////////////////////////////////////////
//Basic Interface for an FSM state
//////////////////////////////////////////////////////////////////////

namespace FSM {

    public abstract class State
    {
        public IFiniteStateMachine fsm { set { m_FSM = value; } }
        protected IFiniteStateMachine m_FSM;

        public virtual void Enter(object owner) { }
        public abstract void Execute(object owner);
        public virtual void Leave(object owner) { }
        public virtual void Pause(object owner) { }
        public virtual void Unpause(object owner) { }
    }
}