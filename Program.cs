using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NMF.Models.Repository;
using NMF.Expressions.Linq;
using NMF.Transformations;

using NMFDemo.Metamodels.FSM;
using PN = NMFDemo.Metamodels.PN;

namespace NMFDemo
{
    /// <summary>
    /// This is a very small demonstration application that gives you a rough overview of what you can do with the .NET Modelling Framework.
    /// For more information, please refer to http://nmf.codeplex.com or http://github.com/NMFCode/NMF
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Loading models

            // At first, we create a new repository in which we want to load models
            var repository = new ModelRepository();
            // To actually load models into that repository, we simply need to resolve a URI. A locator component in the repository
            // will handle different URI types. By default, file URIs are supported.
            // The serializer automatically detects the assembly-wide attributes which we used to register the metamodel.
            var model = repository.Resolve("Example.fsm");
            // We can access the root elements and cast them into the model type
            var fsm = model.RootElements[0] as StateMachine;

            #endregion

            #region Incremental model analysis

            // To demonstrate incremental model analysis, we first create an analysis.
            // For this we support LINQ-queries. Because we added a using statement to NMF.Expressions.Linq, 
            // the stateHubs variable is of type IEnumerableExpression that offers both batch mode execution and incrementalization
            var stateHubs = from s in fsm.States
                            where s.Incoming.Count == fsm.States.Max(s2 => s2.Incoming.Count)
                            select s.Name;

            // Next, we switch to the incrementalized version using AsNotifiable() which offers an event CollectionChanged. We subscribe
            // to this event and simply print any new elements to the console.
            var incrementalStateHubs = stateHubs.AsNotifiable();
            incrementalStateHubs.CollectionChanged += (o, e) =>
            {
                if (e.NewItems != null) foreach (string name in e.NewItems) Console.WriteLine("{0} is a new hub", name);
                if (e.OldItems != null) foreach (string name in e.OldItems) Console.WriteLine("{0} is no longer a hub", name);
            };

            // To demonstrate how the event is fired, we now modify the model that we analysed for hubs before and insert a new transition.
            var checkStock = fsm.States[1];
            checkStock.Outgoing.Add(new Transition()
            {
                Input = "items are for free",
                Target = fsm.States[2]
            });

            // Because we set the target of the new transition to an existing state, the transition is implicitly added to the set of incoming transitions
            // for that state, because the Target reference of a transition is the opposite of a states Incoming reference.
            // However, now the state Ship Order also has equally many incoming transitions than the maximum so far.
            // As we switched on incremental analysis, the notifications created for our changes to the model have actually updated the analysis result
            // Thus, if you insert a breakpoint here, you should actually see a message printed to the console, though we have not actively rerun the analysis.
            // If we do not want to receive these updates anymore, there is also a Detach method available
            incrementalStateHubs.Detach();
            #endregion

            #region Model transformation

            // Now, we are going to run a model transformation on the finite state machine.
            // For this, we just have to instantiate the model transformation and pass it to the transformation engine
            var net = TransformationEngine.Transform<StateMachine, PN.Net>(fsm, new FSM2PN());
            
            #endregion

            #region Saving models

            // The easiest way to save a model physically to a file is to simply save it into a repository. This will persist the model as XMI file.
            repository.Save(net, "Example.pn");

            #endregion
        }
    }
}
