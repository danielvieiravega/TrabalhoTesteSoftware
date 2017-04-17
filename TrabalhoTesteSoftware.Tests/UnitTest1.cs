using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrabalhoTesteSoftware.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ControlTestStates ControlState;
        private SensorTestStates SensorState;

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

        public UnitTest1()
        {
            ControlState = ControlTestStates.q0;
            SensorState = SensorTestStates.q0;
        }

        [TestMethod]
        public void ControleTest()
        {
            Sensor temp = new Sensor(TypeSensor.Temperature);
            Sensor pres = new Sensor(TypeSensor.Pressure);
            Controle controle = new Controle(temp, pres);

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

    }
}
