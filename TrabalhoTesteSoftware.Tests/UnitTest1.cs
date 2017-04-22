using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrabalhoTesteSoftware.Tests
{
    [TestClass]
    public class UnitTest1
    {
        System _sys;
        
        public UnitTest1()
        {
            _sys = new System();
        }

        #region Casos de testes estado Q0
        [TestMethod]
        public void Test_Q0_GetV1_Q0()
        {
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor) );
            Assert.AreEqual(true, _sys.Ctrl.enable());
        }

        [TestMethod]
        public void Test_Q0_GetV2_Q0()
        {
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.enable() );
        }

        [TestMethod]
        public void Test_Q0_Enable_Q1()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            Assert.AreEqual( true, _sys.Ctrl.disable() );
        }
        #endregion

        #region Casos de testes estado Q3
        [TestMethod]
        public void Test_Q3_Disable_Q0()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            Assert.AreEqual( true, _sys.Ctrl.disable() );
            Assert.AreEqual( true, _sys.Ctrl.enable() );
        }

        [TestMethod]
        public void Test_Q3_Alert1_Q4()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.alert( _sys.P_Sensor );
            _sys.Ctrl.reset( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV(_sys.P_Sensor) && !_sys.Ctrl.getV(_sys.T_Sensor) );
        }

        [TestMethod]
        public void Test_Q3_Alert1_Q5()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) && !_sys.Ctrl.getV( _sys.P_Sensor ) );
        }
        #endregion

        #region Casos de testes estado Q4

        #endregion
    }
}
