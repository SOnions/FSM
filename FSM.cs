//////////////////////////////////////////////////////////////////////
//FSM.State
//by Sam Onions
//////////////////////////////////////////////////////////////////////
//A Generic FSM Implementation
//////////////////////////////////////////////////////////////////////
using System.Collections.Generic;

namespace FSM
{
    public interface IFiniteStateMachine
    {
        void Update();
        void ChangeState(State newState);
        void PushState(State newState);
        void PopState();
    }

    public class FiniteStateMachine<T> : IFiniteStateMachine
    {
        //Member Variables
        private T m_Owner;
        private Stack<State> m_Stack = new Stack<State>();


        public void Configure(T owner, State InitialState)
        {
            m_Owner = owner;
            PushState(InitialState);
        }


        public void Update()
        {
            State currentState = m_Stack.Peek();
            if (currentState != null) currentState.Execute(m_Owner);
        }

        public void ChangeState(State newState)
        {
            State oldState = m_Stack.Pop();
            oldState.Leave(m_Owner);
            newState.fsm = this;
            m_Stack.Push(newState);
            newState.Enter(m_Owner);
        }

        public void PushState(State newState)
        {
            if (m_Stack.Count > 0)
            {
                State currentState = m_Stack.Peek();
                currentState.Pause(m_Owner);
            }
            newState.fsm = this;
            m_Stack.Push(newState);
            newState.Enter(m_Owner);
        }

        public void PopState()
        {
            State oldState = m_Stack.Pop();
            oldState.Leave(m_Owner);
            State currentState = m_Stack.Peek();
            if (currentState != null) currentState.Unpause(m_Owner);
        }
    }
}