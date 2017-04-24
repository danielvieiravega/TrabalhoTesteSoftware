using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrabalhoTesteSoftware.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region private variables
        private System _sys;
        private TestContext _testContextInstace;
        #endregion

        #region public properties
        public TestContext TestContext
        {
            get { return _testContextInstace; }
            set { _testContextInstace = value; }
        }
        #endregion

        #region constructor       
        public UnitTest1()
        {
            _sys = new System();
        }
        #endregion

        #region Casos de teste para o controlador
        #region Casos de teste estado Q0
        [TestMethod]
        public void Test_Q0_GetV1_Q0()
        {
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.enable() );
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

        #region Casos de teste estado Q3
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
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) && !_sys.Ctrl.getV( _sys.T_Sensor ) );
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

        #region Casos de teste estado Q4
        [TestMethod]
        public void Test_Q4_GetV1_Q4()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.alert( _sys.P_Sensor );
            _sys.Ctrl.reset( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) && !_sys.Ctrl.getV( _sys.T_Sensor ) );
        }

        [TestMethod]
        public void Test_Q4_Reset1_Q3()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.disable() );
        }

        [TestMethod]
        public void Test_Q4_Alert2_Q6()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) && _sys.Ctrl.getV( _sys.P_Sensor ) );
        }
        #endregion

        #region Casos de teste estado Q5
        [TestMethod]
        public void Test_Q5_GetV2_Q5()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) && !_sys.Ctrl.getV( _sys.P_Sensor ) );

        }

        [TestMethod]
        public void Test_Q5_Reset2_Q3()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.P_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.disable() );
        }

        [TestMethod]
        public void Test_Q5_Alert1_Q6()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.alert( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) && _sys.Ctrl.getV( _sys.P_Sensor ) );
        }
        #endregion

        #region Casos de teste estado Q6
        [TestMethod]
        public void Test_Q6_GetV1_Q6()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) && _sys.Ctrl.getV( _sys.P_Sensor ) );
        }

        [TestMethod]
        public void Test_Q6_GetV2_Q6()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) && _sys.Ctrl.getV( _sys.P_Sensor ) );
        }

        [TestMethod]
        public void Test_Q6_Reset2_Q4()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.alert( _sys.P_Sensor );
            _sys.Ctrl.reset( _sys.T_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) && !_sys.Ctrl.getV( _sys.T_Sensor ) );
        }

        [TestMethod]
        public void Test_Q6_Reset1_Q5()
        {
            Assert.AreEqual( true, _sys.Ctrl.enable() );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.alert( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.P_Sensor ) );
            _sys.Ctrl.reset( _sys.T_Sensor );
            Assert.AreEqual( false, _sys.Ctrl.getV( _sys.T_Sensor ) );
            _sys.Ctrl.alert( _sys.T_Sensor );
            _sys.Ctrl.reset( _sys.P_Sensor );
            Assert.AreEqual( true, _sys.Ctrl.getV( _sys.T_Sensor ) && !_sys.Ctrl.getV( _sys.P_Sensor ) );
        }
        #endregion
        #endregion

        #region Casos de teste Sensor Temperatura
        #region Casos de teste estado Q0
        [TestMethod]
        public void Test_Q0_GetAlert_TS_Q0()
        {
            Assert.AreEqual( false, _sys.T_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
        }

        [TestMethod]
        public void Test_Q0_SetH_TS_Q1()
        {
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( true, _sys.T_Sensor.resetH() );
        }
        #endregion

        #region Casos de teste estado Q1
        [TestMethod]
        public void Test_Q1_ResetH_TS_Q0()
        {
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( true, _sys.T_Sensor.resetH() );
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
        }

        [TestMethod]
        public void Test_Q1_GetAlert_TS_Q1()
        {
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( false, _sys.T_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.T_Sensor.resetH() );
        }

        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q1_SetValueGreaterThanLimit_TS_Q2()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.T_Sensor );
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( true, _sys.T_Sensor.setValue( Constants.MaxTemperatureValue + 1 ) );
            Assert.AreEqual( true, _sys.T_Sensor.getAlert() );
        }
        #endregion

        #region Casos de teste estado Q2
        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q2_GetAlert_TS_Q2()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.T_Sensor );
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( true, _sys.T_Sensor.setValue( Constants.MaxTemperatureValue + 1 ) );
            Assert.AreEqual( true, _sys.T_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.T_Sensor.getAlert() );
        }

        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q2_SetValueLessThanLimit_TS_Q1()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.T_Sensor );
            Assert.AreEqual( true, _sys.T_Sensor.setH() );
            Assert.AreEqual( true, _sys.T_Sensor.setValue( Constants.MaxTemperatureValue + 1 ) );
            Assert.AreEqual( true, _sys.T_Sensor.setValue( Constants.MaxTemperatureValue ) );
            Assert.AreEqual( true, _sys.T_Sensor.resetH() );
        }
        #endregion
        #endregion

        #region Casos de teste Sensor Pressão
        #region Casos de teste estado Q0
        [TestMethod]
        public void Test_Q0_GetAlert_PS_Q0()
        {
            Assert.AreEqual( false, _sys.P_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
        }

        [TestMethod]
        public void Test_Q0_SetH_PS_Q1()
        {
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( true, _sys.P_Sensor.resetH() );
        }
        #endregion

        #region Casos de teste estado Q1
        [TestMethod]
        public void Test_Q1_ResetH_PS_Q0()
        {
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( true, _sys.P_Sensor.resetH() );
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
        }

        [TestMethod]
        public void Test_Q1_GetAlert_PS_Q1()
        {
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( false, _sys.P_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.P_Sensor.resetH() );
        }

        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q1_SetValueGreaterThanLimit_PS_Q2()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.P_Sensor );
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( true, _sys.P_Sensor.setValue( Constants.MaxPressureValure + 1 ) );
            Assert.AreEqual( true, _sys.P_Sensor.getAlert() );
        }
        #endregion

        #region Casos de teste estado Q2
        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q2_GetAlert_PS_Q2()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.P_Sensor );
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( true, _sys.P_Sensor.setValue( Constants.MaxPressureValure + 1 ) );
            Assert.AreEqual( true, _sys.P_Sensor.getAlert() );
            Assert.AreEqual( true, _sys.P_Sensor.getAlert() );
        }

        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.XML",
                   @"..\..\..\TestInput\Confiabilidade.xml", "Row",
                    DataAccessMethod.Sequential )]
        public void Test_Q2_SetValueLessThanLimit_PS_Q1()
        {
            int x = int.Parse( (string)TestContext.DataRow["Data"] );
            Set_Reliability( x, _sys.P_Sensor );
            Assert.AreEqual( true, _sys.P_Sensor.setH() );
            Assert.AreEqual( true, _sys.P_Sensor.setValue( Constants.MaxTemperatureValue + 1 ) );
            Assert.AreEqual( true, _sys.P_Sensor.setValue( Constants.MaxTemperatureValue ) );
            Assert.AreEqual( true, _sys.P_Sensor.resetH() );
        }
        #endregion
        #endregion

        #region private methods
        private void Set_Reliability( int x, Sensor s )
        {
            float conf = x / 10.0f;
            s.setR( conf );
        }
        #endregion
    }
}
