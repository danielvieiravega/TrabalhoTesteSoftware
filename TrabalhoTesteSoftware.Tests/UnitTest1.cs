using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrabalhoTesteSoftware.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TemperatureSensorIsTypeOfTemperature()
        {
            var controle = new Controle();

            Assert.AreEqual(TypeSensor.Temperature, controle.TemperatureSensor.TypeSensor);

        }
    }
}
