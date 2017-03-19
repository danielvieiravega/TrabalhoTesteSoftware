using System;

namespace TrabalhoTesteSoftware
{
    public class Controle : IControle
    {
        #region private variables
        public ISensor TemperatureSensor { get; }
        public ISensor PressureSensor { get; }
        public Estado Estado { get; set; }
        #endregion

        #region constructor
        public Controle()
        {
            Estado = Estado.Desativado;
            TemperatureSensor = new Sensor(TypeSensor.Temperature, this);
            PressureSensor = new Sensor(TypeSensor.Pressure, this);
        }
        #endregion

        #region public Methods
        public void alert(TypeSensor typeSensor)
        {
            switch (typeSensor)
            {
                case TypeSensor.Temperature:
                    open(TemperatureSensor);
                    break;
                case TypeSensor.Pressure:
                    open(PressureSensor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeSensor), typeSensor, null);
            }
        }

        public void close(ISensor n)
        {
            throw new NotImplementedException();
        }

        public bool disable()
        {
            return TemperatureSensor.resetH() && PressureSensor.resetH();
        }

        public bool enable()
        {
            return TemperatureSensor.setH() && PressureSensor.setH();
        }

        public bool getV(ISensor n)
        {
            throw new NotImplementedException();
        }

        public void open(ISensor n)
        {

        }

        public void reset(TypeSensor type_sensor)
        {
            if (type_sensor == TypeSensor.Temperature)
                close(TemperatureSensor);
            else if (type_sensor == TypeSensor.Pressure)
                close(PressureSensor);
        }

        public void alert(ISensor n)
        {
            throw new NotImplementedException();
        }

        public void reset(ISensor n)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
