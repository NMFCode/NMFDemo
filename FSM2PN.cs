using System;
using System.Linq;
using NMF.Transformations;
using NMF.Transformations.Core;
using NMF.Utilities;
using NMFDemo.Metamodels.FSM;
using PN = NMFDemo.Metamodels.PN;

namespace NMFDemo
{
    /// <summary>
    /// This is an example of a simple model transformation in NTL
    /// </summary>
    public class FSM2PN : ReflectiveTransformation
    {
        /// <summary>
        /// The transformation rules are public nested classes. This first transformation rule transforms state machines to Petri nets
        /// </summary>
        public class AutomataToNet : TransformationRule<StateMachine, PN.Net>
        {
            /// <summary>
            /// Here we specify how exactly state machines are transformed to Petri nets
            /// </summary>
            /// <param name="input">The input state machine</param>
            /// <param name="output">The target Petri net output</param>
            /// <param name="context">The context of this transformation run, used e.g. for tracing</param>
            /// <remarks>We could also override other bits of the transformation such as for example altering the way how target model elements are created</remarks>
            public override void Transform(StateMachine input, PN.Net output, ITransformationContext context)
            {
                output.Name = input.Name;
            }
        }

        /// <summary>
        /// This rule transforms states of the input state machine into Petri net places
        /// </summary>
        public class StateToPlace : TransformationRule<IState, PN.Place>
        {
            /// <summary>
            /// During transformation, we simply copy the name
            /// </summary>
            /// <param name="input">The input model element</param>
            /// <param name="output">The target Petri net place</param>
            /// <param name="context">The context of this transformation run, used e.g. for tracing</param>
            public override void Transform(IState input, PN.Place output, ITransformationContext context)
            {
                output.Name = input.Name;
            }

            /// <summary>
            /// In this RegisterDependencies method, we may add dependencies to other transformation rules
            /// </summary>
            public override void RegisterDependencies()
            {
                // The transformation rule State2Place should be called each time we transform a finite state machine to a Petri net
                CallForEach(Rule<AutomataToNet>(),
                    selector: fsm => fsm.States,
                    persistor: (pn, places) => pn.Places.AddRange(places));
            }
        }

        /// <summary>
        /// This transformation rule transforms state machine transitions to transitions of the Petri net
        /// </summary>
        public class TransitionToTransition : TransformationRule<ITransition, PN.Transition>
        {
            /// <summary>
            /// In the transformation method, we copy the input and register the created transition at the petri net
            /// </summary>
            /// <param name="input">The input state machine transition</param>
            /// <param name="output">The target Petri net transition</param>
            /// <param name="context">The context of this transformation run, used e.g. for tracing</param>
            public override void Transform(ITransition input, PN.Transition output, ITransformationContext context)
            {
                output.Input = input.Input;

                // We can always navigate to an elements container, even if there is no explicit reference
                var fsm = input.Source.Parent as StateMachine;
                // Here, we resolve the petri net created for the state machine containing the source state
                var pn = context.Trace.ResolveIn(Rule<AutomataToNet>(), fsm);
                if (pn != null)
                {
                    pn.Transitions.Add(output);
                }
            }

            /// <summary>
            /// Registration of dependencies
            /// </summary>
            public override void RegisterDependencies()
            {
                // First, we make sure that Transition2Transition is called each time a state is transformed
                CallForEach(Rule<StateToPlace>(),
                    selector: s => s.Outgoing,
                    persistor: (p, transitions) => p.Outgoing.AddRange(transitions));

                // Here, we make sure that the target state is also transformed before the transition is transformed
                Require(Rule<StateToPlace>(),
                    selector: t => t.Target,
                    persistor: (t, p) => t.To.Add(p));
            }
        }

        /// <summary>
        /// This rule transforms each start state to a corresponding transition
        /// </summary>
        public class StartStateToTransition : TransformationRule<IState, PN.Transition>
        {
            /// <summary>
            /// In the transform method, we add the corresponding place to the transition
            /// </summary>
            /// <param name="input">The input state</param>
            /// <param name="output">The output transition</param>
            /// <param name="context">The context of this transformation run, used e.g. for tracing</param>
            public override void Transform(IState input, PN.Transition output, ITransformationContext context)
            {
                output.To.Add(context.Trace.ResolveIn(Rule<StateToPlace>(), input));
                output.Input = "";
            }

            /// <summary>
            /// Here we register when this transformation rule should be called
            /// </summary>
            public override void RegisterDependencies()
            {
                // We only need to call this transformation rule for the start state of the state machine
                CallFor(Rule<AutomataToNet>(),
                    selector: fsm => fsm.StartState,
                    persistor: (t, pn) => pn.Transitions.Add(t));
            }
        }

        /// <summary>
        /// This transformation rule creates transitions for each final state
        /// </summary>
        public class EndStateToTransition : TransformationRule<IState, PN.Transition>
        {
            /// <summary>
            /// Like in the start state transformation rule, we simply trace the place for which the transition has been created
            /// </summary>
            /// <param name="input">The input state</param>
            /// <param name="output">The target transition</param>
            /// <param name="context">The context of this transformation run, used e.g. for tracing</param>
            public override void Transform(IState input, PN.Transition output, ITransformationContext context)
            {
                output.From.Add(context.Trace.ResolveIn(Rule<StateToPlace>(), input));
                output.Input = "";
            }

            /// <summary>
            /// Here, we register when this transformation rule should be called.
            /// </summary>
            public override void RegisterDependencies()
            {
                // The transformation rule should be called for every state that is accepting.
                // Therefore, you can specify different guards for different situations for which the transformation rule should be called
                CallForEach(Rule<AutomataToNet>(),
                    selector: fsm => fsm.States.Where(s => s.IsAccepting),
                    persistor: (pn, endTransitions) => pn.Transitions.AddRange(endTransitions));
            }
        }
    }
}
