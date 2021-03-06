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

namespace NMFDemo.Metamodels.PN
{
    
    
    /// <summary>
    /// The representation of the Net class
    /// </summary>
    [XmlIdentifierAttribute("name")]
    [XmlNamespaceAttribute("http://github.com/NMFCode/Examples/PetriNet")]
    [XmlNamespacePrefixAttribute("pn")]
    [ModelRepresentationClassAttribute("http://github.com/NMFCode/Examples/PetriNet#//Net/")]
    [DebuggerDisplayAttribute("Net {Name}")]
    public class Net : ModelElement, INet, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Name property
        /// </summary>
        private string _name;
        
        /// <summary>
        /// The backing field for the Places property
        /// </summary>
        private ObservableCompositionList<IPlace> _places;
        
        /// <summary>
        /// The backing field for the Transitions property
        /// </summary>
        private ObservableCompositionList<ITransition> _transitions;
        
        public Net()
        {
            this._places = new ObservableCompositionList<IPlace>(this);
            this._places.CollectionChanged += this.PlacesCollectionChanged;
            this._transitions = new ObservableCompositionList<ITransition>(this);
            this._transitions.CollectionChanged += this.TransitionsCollectionChanged;
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
        /// The places property
        /// </summary>
        [LowerBoundAttribute(1)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("places")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        public virtual IListExpression<IPlace> Places
        {
            get
            {
                return this._places;
            }
        }
        
        /// <summary>
        /// The transitions property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("transitions")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        public virtual IListExpression<ITransition> Transitions
        {
            get
            {
                return this._transitions;
            }
        }
        
        /// <summary>
        /// Gets the child model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> Children
        {
            get
            {
                return base.Children.Concat(new NetChildrenCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new NetReferencedElementsCollection(this));
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
        /// Forwards change notifications for the Places property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void PlacesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Places", e);
        }
        
        /// <summary>
        /// Forwards change notifications for the Transitions property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void TransitionsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Transitions", e);
        }
        
        /// <summary>
        /// Gets the relative URI fragment for the given child model element
        /// </summary>
        /// <returns>A fragment of the relative URI</returns>
        /// <param name="element">The element that should be looked for</param>
        protected override string GetRelativePathForNonIdentifiedChild(IModelElement element)
        {
            int placesIndex = ModelHelper.IndexOfReference(this.Places, element);
            if ((placesIndex != -1))
            {
                return ModelHelper.CreatePath("places", placesIndex);
            }
            int transitionsIndex = ModelHelper.IndexOfReference(this.Transitions, element);
            if ((transitionsIndex != -1))
            {
                return ModelHelper.CreatePath("transitions", transitionsIndex);
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
            if ((reference == "PLACES"))
            {
                if ((index < this.Places.Count))
                {
                    return this.Places[index];
                }
                else
                {
                    return null;
                }
            }
            if ((reference == "TRANSITIONS"))
            {
                if ((index < this.Transitions.Count))
                {
                    return this.Transitions[index];
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
            return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://github.com/NMFCode/Examples/PetriNet#//Net/");
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
        /// The collection class to to represent the children of the Net class
        /// </summary>
        public class NetChildrenCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Net _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public NetChildrenCollection(Net parent)
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
                    count = (count + this._parent.Places.Count);
                    count = (count + this._parent.Transitions.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Places.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.Transitions.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Places.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.Transitions.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                IPlace placesCasted = item.As<IPlace>();
                if ((placesCasted != null))
                {
                    this._parent.Places.Add(placesCasted);
                }
                ITransition transitionsCasted = item.As<ITransition>();
                if ((transitionsCasted != null))
                {
                    this._parent.Transitions.Add(transitionsCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Places.Clear();
                this._parent.Transitions.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Places.Contains(item))
                {
                    return true;
                }
                if (this._parent.Transitions.Contains(item))
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
                IEnumerator<IModelElement> placesEnumerator = this._parent.Places.GetEnumerator();
                try
                {
                    for (
                    ; placesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = placesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    placesEnumerator.Dispose();
                }
                IEnumerator<IModelElement> transitionsEnumerator = this._parent.Transitions.GetEnumerator();
                try
                {
                    for (
                    ; transitionsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = transitionsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    transitionsEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                IPlace placeItem = item.As<IPlace>();
                if (((placeItem != null) 
                            && this._parent.Places.Remove(placeItem)))
                {
                    return true;
                }
                ITransition transitionItem = item.As<ITransition>();
                if (((transitionItem != null) 
                            && this._parent.Transitions.Remove(transitionItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Places).Concat(this._parent.Transitions).GetEnumerator();
            }
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Net class
        /// </summary>
        public class NetReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Net _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public NetReferencedElementsCollection(Net parent)
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
                    count = (count + this._parent.Places.Count);
                    count = (count + this._parent.Transitions.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Places.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.Transitions.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Places.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.Transitions.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                IPlace placesCasted = item.As<IPlace>();
                if ((placesCasted != null))
                {
                    this._parent.Places.Add(placesCasted);
                }
                ITransition transitionsCasted = item.As<ITransition>();
                if ((transitionsCasted != null))
                {
                    this._parent.Transitions.Add(transitionsCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Places.Clear();
                this._parent.Transitions.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Places.Contains(item))
                {
                    return true;
                }
                if (this._parent.Transitions.Contains(item))
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
                IEnumerator<IModelElement> placesEnumerator = this._parent.Places.GetEnumerator();
                try
                {
                    for (
                    ; placesEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = placesEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    placesEnumerator.Dispose();
                }
                IEnumerator<IModelElement> transitionsEnumerator = this._parent.Transitions.GetEnumerator();
                try
                {
                    for (
                    ; transitionsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = transitionsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    transitionsEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                IPlace placeItem = item.As<IPlace>();
                if (((placeItem != null) 
                            && this._parent.Places.Remove(placeItem)))
                {
                    return true;
                }
                ITransition transitionItem = item.As<ITransition>();
                if (((transitionItem != null) 
                            && this._parent.Transitions.Remove(transitionItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Places).Concat(this._parent.Transitions).GetEnumerator();
            }
        }
    }
}

