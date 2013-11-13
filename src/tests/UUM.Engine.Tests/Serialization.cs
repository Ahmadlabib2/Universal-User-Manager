using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using NUnit.Framework;

namespace UUM.Engine.Tests
{
    public interface IParams
    {
    
    }

    // Setting the known types on a base class (not interface) solves the issue
    // but is not feasible as the possible derived classes are implemented by
    // plugins which are not known in advance. Is there a way to do this dynamically,
    // by making a request to the plugin manager?
    [KnownType("KnownTypes")]
    public class ParamsBase : SavableModelBase<ParamsBase>, IParams
    {
        // This method returns the array of known types.
        static Type[] KnownTypes()
        {
            return new Type[] { typeof(PluginA.Params), typeof(PluginB.Params) };
        }        
    }

    namespace PluginA
    {
	    public class Params : ParamsBase
	    {
	        #region Property: SettingA
	        public String SettingA
	        {
	            get { return GetValue<String>(SettingAProperty); }
	            set { SetValue(SettingAProperty, value); }
	        }
	
	        public static readonly PropertyData SettingAProperty =
	            RegisterProperty("SettingA", typeof(String));
	        #endregion
	    }
    }
    
    namespace PluginB
    {
	    public class Params : ParamsBase
	    {
	        #region Property: SettingB
	        public String SettingB
	        {
	            get { return GetValue<String>(SettingBProperty); }
	            set { SetValue(SettingBProperty, value); }
	        }
	
	        public static readonly PropertyData SettingBProperty =
	            RegisterProperty("SettingB", typeof(String));
	        #endregion
	    }
    }
	
    public class ContainerInterfaces : SavableModelBase<ContainerInterfaces>
    {
        #region Property: Parameters
        public ObservableCollection<IParams> Parameters
        {
            get { return GetValue<ObservableCollection<IParams>>(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        public static readonly PropertyData ParametersProperty =
            RegisterProperty("Parameters", typeof(ObservableCollection<IParams>),
            new ObservableCollection<IParams>());
        #endregion
    }

    public class ContainerAbstractClasses : SavableModelBase<ContainerAbstractClasses>
    {
        #region Property: Parameters
        public ObservableCollection<ParamsBase> Parameters
        {
            get { return GetValue<ObservableCollection<ParamsBase>>(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        public static readonly PropertyData ParametersProperty =
            RegisterProperty("Parameters", typeof(ObservableCollection<ParamsBase>),
            new ObservableCollection<ParamsBase>());
        #endregion
    }

    [TestFixture]
    public class Serialization
    {
        [Test]
        public void EnumerableOfInterfacesViaKnownTypes_SameNameDifferentNamespaces_SaveLoadRoundTrip()
        {
            var c = new ContainerInterfaces();
            var pA = new PluginA.Params();
            pA.SettingA = "TestA";
            c.Parameters.Add(pA);
            var pB = new PluginB.Params();
            pB.SettingB = "TestB";
            c.Parameters.Add(pB);
            c.Save("test.xml", SerializationMode.Xml);
            var c2 = ContainerInterfaces.Load("test.xml", SerializationMode.Xml);
            Assert.AreEqual(2, c2.Parameters.Count);
        }

        [Test]
        public void EnumerableOfAbstractClassesViaKnownTypes_SameNameDifferentNamespaces_SaveLoadRoundTrip()
        {
            var c = new ContainerAbstractClasses();
            var pA = new PluginA.Params();
            pA.SettingA = "TestA";
            c.Parameters.Add(pA);
            var pB = new PluginB.Params();
            pB.SettingB = "TestB";
            c.Parameters.Add(pB);
            c.Save("test.xml", SerializationMode.Xml);
            var c2 = ContainerAbstractClasses.Load("test.xml", SerializationMode.Xml);
            Assert.AreEqual(2, c2.Parameters.Count);
        }
    }
}