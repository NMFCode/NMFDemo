//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.13
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Models.Expressions;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMFDemo.Metamodels.FSM
{
    
    
    /// <summary>
    /// The public interface for StateMachine
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(StateMachine))]
    [XmlDefaultImplementationTypeAttribute(typeof(StateMachine))]
    [ModelRepresentationClassAttribute("http://github.com/NMFCode/Examples/FiniteStateMachines#//StateMachine")]
    public interface IStateMachine : IModelElement
    {
        
        /// <summary>
        /// The name property
        /// </summary>
        [DisplayNameAttribute("name")]
        [CategoryAttribute("StateMachine")]
        [XmlElementNameAttribute("name")]
        [IdAttribute()]
        [XmlAttributeAttribute(true)]
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// The states property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [BrowsableAttribute(false)]
        [XmlElementNameAttribute("states")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        [ConstantAttribute()]
        IOrderedSetExpression<IState> States
        {
            get;
        }
        
        /// <summary>
        /// The startState property
        /// </summary>
        [DisplayNameAttribute("startState")]
        [CategoryAttribute("StateMachine")]
        [XmlElementNameAttribute("startState")]
        [XmlAttributeAttribute(true)]
        IState StartState
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired before the Name property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanging;
        
        /// <summary>
        /// Gets fired when the Name property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanged;
        
        /// <summary>
        /// Gets fired before the StartState property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> StartStateChanging;
        
        /// <summary>
        /// Gets fired when the StartState property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> StartStateChanged;
    }
}

