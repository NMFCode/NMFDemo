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
    /// The representation of the Transition class
    /// </summary>
    [XmlNamespaceAttribute("http://github.com/NMFCode/Examples/PetriNet")]
    [XmlNamespacePrefixAttribute("pn")]
    [ModelRepresentationClassAttribute("http://github.com/NMFCode/Examples/PetriNet#//Transition/")]
    public class Transition : ModelElement, ITransition, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Input property
        /// </summary>
        private string _input;
        
        /// <summary>
        /// The backing field for the From property
        /// </summary>
        private TransitionFromCollection _from;
        
        /// <summary>
        /// The backing field for the To property
        /// </summary>
        private TransitionToCollection _to;
        
        public Transition()
        {
            this._from = new TransitionFromCollection(this);
            this._from.CollectionChanged += this.FromCollectionChanged;
            this._to = new TransitionToCollection(this);
            this._to.CollectionChanged += this.ToCollectionChanged;
        }
        
        /// <summary>
        /// The input property
        /// </summary>
        [XmlElementNameAttribute("input")]
        [XmlAttributeAttribute(true)]
        public virtual string Input
        {
            get
            {
                return this._input;
            }
            set
            {
                if ((value != this._input))
                {
                    this._input = value;
                    this.OnInputChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Input");
                }
            }
        }
        
        /// <summary>
        /// The from property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("from")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute(typeof(IPlace), "outgoing")]
        public virtual IListExpression<IPlace> From
        {
            get
            {
                return this._from;
            }
        }
        
        /// <summary>
        /// The to property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("to")]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute(typeof(IPlace), "incoming")]
        public virtual IListExpression<IPlace> To
        {
            get
            {
                return this._to;
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new TransitionReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets fired when the Input property changed its value
        /// </summary>
        public event EventHandler InputChanged;
        
        /// <summary>
        /// Raises the InputChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnInputChanged(EventArgs eventArgs)
        {
            EventHandler handler = this.InputChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Forwards change notifications for the From property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void FromCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("From", e);
        }
        
        /// <summary>
        /// Forwards change notifications for the To property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void ToCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("To", e);
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of the current model element
        /// </summary>
        public override NMF.Models.Meta.IClass GetClass()
        {
            return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://github.com/NMFCode/Examples/PetriNet#//Transition/");
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Transition class
        /// </summary>
        public class TransitionReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Transition _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public TransitionReferencedElementsCollection(Transition parent)
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
                    count = (count + this._parent.From.Count);
                    count = (count + this._parent.To.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.From.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.To.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.From.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.To.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                IPlace fromCasted = item.As<IPlace>();
                if ((fromCasted != null))
                {
                    this._parent.From.Add(fromCasted);
                }
                IPlace toCasted = item.As<IPlace>();
                if ((toCasted != null))
                {
                    this._parent.To.Add(toCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.From.Clear();
                this._parent.To.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.From.Contains(item))
                {
                    return true;
                }
                if (this._parent.To.Contains(item))
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
                IEnumerator<IModelElement> fromEnumerator = this._parent.From.GetEnumerator();
                try
                {
                    for (
                    ; fromEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = fromEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    fromEnumerator.Dispose();
                }
                IEnumerator<IModelElement> toEnumerator = this._parent.To.GetEnumerator();
                try
                {
                    for (
                    ; toEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = toEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    toEnumerator.Dispose();
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
                            && this._parent.From.Remove(placeItem)))
                {
                    return true;
                }
                if (((placeItem != null) 
                            && this._parent.To.Remove(placeItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.From).Concat(this._parent.To).GetEnumerator();
            }
        }
    }
}

