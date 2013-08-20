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
    //[KnownType(typeof(ParamsPluginA))]
    //[KnownType(typeof(ParamsPluginB))]
    [KnownType("KnownTypes")]
    public class ParamsBase : SavableModelBase<ParamsBase>, IParams
    {
        // This method returns the array of known types.
        static Type[] KnownTypes()
        {
            return new Type[] { typeof(ParamsPluginA), typeof(ParamsPluginB) };
        }        
    }

    public class ParamsPluginA : ParamsBase
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

    public class ParamsPluginB : ParamsBase
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

    public class Container : SavableModelBase<Container>
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

    [TestFixture]
    public class Serialization
    {
        [Test]
        public void Save()
        {
            var c = new Container();
            var pA = new ParamsPluginA();
            pA.SettingA = "TestA";
            c.Parameters.Add(pA);
            var pB = new ParamsPluginB();
            pB.SettingB = "TestB";
            c.Parameters.Add(pB);
            c.Save("test.xml", SerializationMode.Xml);
            var c2 = Container.Load("test.xml", SerializationMode.Xml);
        }

    }
}