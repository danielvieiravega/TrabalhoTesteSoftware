using System;

namespace TrabalhoTesteSoftware
{
    public class Controle : IControle
    {
        #region private variables
        public Sensor TemperatureSensor { get; }
        public Sensor PressureSensor { get; }
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
        public bool enable()
        {
            return TemperatureSensor.setH() && PressureSensor.setH();
        }

        public bool disable()
        {
            return TemperatureSensor.resetH() && PressureSensor.resetH();
        }

        public void alert(TypeSensor n)
        {
            switch (n)
            {
                case TypeSensor.Temperature:
                    open(TemperatureSensor);
                    break;
                case TypeSensor.Pressure:
                    open(PressureSensor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(n), n, null);
            }
        }

        public void reset(TypeSensor typeSensor)
        {
            Estado = Estado.Operacao;
            switch (typeSensor)
            {
                case TypeSensor.Temperature:
                    close(TemperatureSensor);
                    break;
                case TypeSensor.Pressure:
                    close(PressureSensor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeSensor), typeSensor, null);
            }
        }

        public void open(ISensor n)
        {
            var sensor = (Sensor)n;
            sensor.Valvula.Estado = EstadoValvula.Aberto;
        }

        public void close(ISensor n)
        {
            var sensor = (Sensor)n;
            sensor.Valvula.Estado = EstadoValvula.Fechado;
        }

        public bool getV(ISensor n)
        {
            var sensor = (Sensor)n;
            return true && sensor.Valvula.Estado == EstadoValvula.Aberto;
        }
        #endregion
    }
}
