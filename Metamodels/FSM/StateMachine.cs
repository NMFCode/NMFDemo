//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMFDemo.Metamodels.FSM
{
    
    
    /// <summary>
    /// The representation of the StateMachine class
    /// </summary>
    [XmlIdentifierAttribute("name")]
    [XmlNamespaceAttribute("http://github.com/NMFCode/Examples/FiniteStateMachines")]
    [XmlNamespacePrefixAttribute("fsm")]
    [ModelRepresentationClassAttribute("http://github.com/NMFCode/Examples/FiniteStateMachines#//StateMachine/")]
    [DebuggerDisplayAttribute("StateMachine {Name}")]
    public class StateMachine : ModelElement, IStateMachine, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Name property
        /// </summary>
        private string _name;
        
        /// <summary>
        /// The backing field for the States property
        /// </summary>
        private ObservableCompositionList<IState> _states;
        
        /// <summary>
        /// The backing field for the StartState property
        /// </summary>
        private IState _startState;
        
        public StateMachine()
        {
            this._states = new ObservableCompositionList<IState>(this);
            this._states.CollectionChanged += this.StatesCollectionChanged;
        }
        
        /// <summary>
        /// The name property
        /// </summary>
        [XmlElementNameAttribute("name")]
        [IdAttribute()]
        [XmlAttributeAttribute(true)]
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((value != this._name))
                {
                    this._name = value;
                    this.OnNameChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Name");
                }
            }
        }
        
        /// <summary>
        /// The states property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("states")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        public virtual IListExpression<IState> States
        {
            get
            {
                return this._states;
            }
        }
        
        /// <summary>
        /// The startState property
        /// </summary>
        [XmlElementNameAttribute("startState")]
        [XmlAttributeAttribute(true)]
        public virtual IState StartState
        {
            get
            {
                return this._startState;
            }
            set
            {
                if ((this._startState != value))
                {
                    IState old = this._startState;
                    this._startState = value;
                    if ((old != null))
                    {
                        old.Deleted -= this.OnResetStartState;
                    }
                    if ((value != null))
                    {
                        value.Deleted += this.OnResetStartState;
                    }
                    this.OnPropertyChanged("StartState");
                    this.OnStartStateChanged(new ValueChangedEventArgs(old, value));
                }
            }
        }
        
        /// <summary>
        /// Gets the child model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> Children
        {
            get
            {
                return base.Children.Concat(new StateMachineChildrenCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new StateMachineReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets a value indicating whether the current model element can be identified by an attribute value
        /// </summary>
        public override bool IsIdentified
        {
            get
            {
                return true;
            }
        }
        
        /// <summary>
        /// Gets fired when the Name property changed its value
        /// </summary>
        public event EventHandler NameChanged;
        
        /// <summary>
        /// Gets fired when the StartState property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> StartStateChanged;
        
        /// <summary>
        /// Raises the NameChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnNameChanged(EventArgs eventArgs)
        {
            EventHandler handler = this.NameChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Forwards change notifications for the States property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void StatesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("States", e);
        }
        
        /// <summary>
        /// Raises the StartStateChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnStartStateChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.StartStateChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the StartState property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetStartState(object sender, EventArgs eventArgs)
        {
            this.StartState = null;
        }
        
        /// <summary>
        /// Gets the relative URI fragment for the given child model element
        /// </summary>
        /// <returns>A fragment of the relative URI</returns>
        /// <param name="element">The element that should be looked for</param>
        protected override string GetRelativePathForNonIdentifiedChild(IModelElement element)
        {
            int statesIndex = ModelHelper.IndexOfReference(this.States, element);
            if ((statesIndex != -1))
            {
                return ModelHelper.CreatePath("states", statesIndex);
            }
            return base.GetRelativePathForNonIdentifiedChild(element);
        }
        
        /// <summary>
        /// Resolves the given URI to a child model element
        /// </summary>
        /// <returns>The model element or null if it could not be found</returns>
        /// <param name="reference">The requested reference name</param>
        /// <param name="index">The index of this reference</param>
        protected override IModelElement GetModelElementForReference(string reference, int index)
        {
            if ((reference == "STATES"))
            {
                if ((index < this.States.Count))
                {
                    return this.States[index];
                }
                else
                {
                    return null;
                }
            }
            return base.GetModelElementForReference(reference, index);
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of the current model element
        /// </summary>
        public override NMF.Models.Meta.IClass GetClass()
        {
            return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://github.com/NMFCode/Examples/FiniteStateMachines#//StateMachine/");
        }
        
        /// <summary>
        /// Gets the identifier string for this model element
        /// </summary>
        /// <returns>The identifier string</returns>
        public override string ToIdentifierString()
        {
            return this.Name.ToString();
        }
        
        /// <summary>
        /// The collection class to to represent the children of the StateMachine class
        /// </summary>
        public class StateMachineChildrenCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private StateMachine _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public StateMachineChildrenCollection(StateMachine parent)
            {
                this._parent = parent;
            }
            
            /// <summary>
            /// Gets the amount of elements contained in this collection
            /// </summary>
            public override int Count
            {
                get
                {
                    int count = 0;
                    count = (count + this._parent.States.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.States.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.States.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                IState statesCasted = item.As<IState>();
                if ((statesCasted != null))
                {
                    this._parent.States.Add(statesCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.States.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.States.Contains(item))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Copies the contents of the collection to the given array starting from the given array index
            /// </summary>
            /// <param name="array">The array in which the elements should be copied</param>
            /// <param name="arrayIndex">The starting index</param>
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                IEnumerator<IModelElement> statesEnumerator = this._parent.States.GetEnumerator();
                try
                {
                    for (
                    ; statesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = statesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    statesEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                IState stateItem = item.As<IState>();
                if (((stateItem != null) 
                            && this._parent.States.Remove(stateItem)))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.States).GetEnumerator();
            }
        }
        
        /// <summary>
        /// The collection class to to represent the children of the StateMachine class
        /// </summary>
        public class StateMachineReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private StateMachine _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public StateMachineReferencedElementsCollection(StateMachine parent)
            {
                this._parent = parent;
            }
            
            /// <summary>
            /// Gets the amount of elements contained in this collection
            /// </summary>
            public override int Count
            {
                get
                {
                    int count = 0;
                    count = (count + this._parent.States.Count);
                    if ((this._parent.StartState != null))
                    {
                        count = (count + 1);
                    }
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.States.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.StartStateChanged += this.PropagateValueChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.States.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.StartStateChanged -= this.PropagateValueChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                IState statesCasted = item.As<IState>();
                if ((statesCasted != null))
                {
                    this._parent.States.Add(statesCasted);
                }
                if ((this._parent.StartState == null))
                {
                    IState startStateCasted = item.As<IState>();
                    if ((startStateCasted != null))
                    {
                        this._parent.StartState = startStateCasted;
                        return;
                    }
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.States.Clear();
                this._parent.StartState = null;
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.States.Contains(item))
                {
                    return true;
                }
                if ((item == this._parent.StartState))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Copies the contents of the collection to the given array starting from the given array index
            /// </summary>
            /// <param name="array">The array in which the elements should be copied</param>
            /// <param name="arrayIndex">The starting index</param>
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                IEnumerator<IModelElement> statesEnumerator = this._parent.States.GetEnumerator();
                try
                {
                    for (
                    ; statesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = statesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    statesEnumerator.Dispose();
                }
                if ((this._parent.StartState != null))
                {
                    array[arrayIndex] = this._parent.StartState;
                    arrayIndex = (arrayIndex + 1);
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                IState stateItem = item.As<IState>();
                if (((stateItem != null) 
                            && this._parent.States.Remove(stateItem)))
                {
                    return true;
                }
                if ((this._parent.StartState == item))
                {
                    this._parent.StartState = null;
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.States).Concat(this._parent.StartState).GetEnumerator();
            }
        }
    }
}

