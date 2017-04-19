using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrabalhoTesteSoftware.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //private ControlTestStates ControlState;
        //private SensorTestStates SensorState;
        Controle Controle;

        public UnitTest1()
        {
            //ControlState = ControlTestStates.q0;
            //SensorState = SensorTestStates.q0;
            Sensor temp = new Sensor(TypeSensor.Temperature);
            Sensor pres = new Sensor(TypeSensor.Pressure);
            Controle = new Controle(temp, pres);
        }
        
        [TestMethod]
        public void TestGetv1_getv2_false()
        {
            Assert.AreEqual(false, Controle.getV((Sensor)Controle.PressureSensor) && Controle.getV((Sensor)Controle.TemperatureSensor));
            Assert.AreEqual(true, Controle.enable());
        }

        [TestMethod]
        public void TestEnableTrue()
        {
            Assert.AreEqual(true, Controle.enable());
        }

        [TestMethod]
        public void TestEnableFalse()
        {
            Controle.enable();
            Assert.AreEqual(true, Controle.disable());
        }

        [TestMethod]
        public void alert1true()
        {
            Controle.enable();
            //Assert.AreEqual(true, Controle.PressureSensor.a));
        }


        /*
        public enum ControlTestStates
        {
            q0,
            q3,
            q4,
            q5,
            q6
        }

        public enum SensorTestStates
        {
            q0,
            q1,
            q2
        }

        [TestMethod]
        public void ControleTest()
        {
            

            switch (ControlState)
            {
                case ControlTestStates.q0:
                    Assert.AreEqual(false, controle.getV((Sensor)controle.PressureSensor));
                    Assert.AreEqual(false, controle.getV((Sensor)controle.TemperatureSensor));
                    ControlState = ControlTestStates.q3;

                    break;

                case ControlTestStates.q3:
                    Assert.AreEqual(true, controle.enable());

                    break;
                case ControlTestStates.q4:
                    break;
                case ControlTestStates.q5:
                    break;
                case ControlTestStates.q6:
                    break;
                default:
                    break;
            }
        }

        [TestMethod]
        public void SensorTest()
        {
            switch (SensorState)
            {
                case SensorTestStates.q0:
                    break;
                case SensorTestStates.q1:
                    break;
                case SensorTestStates.q2:
                    break;
                default:
                    break;
            }
        }
        */
    }
}
