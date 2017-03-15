using System;

namespace TrabalhoTesteSoftware
{
    public class Controle : IControle
    {
        #region private variables
        ISensor _temperatureSensor;
        ISensor _pressureSensor;
        #endregion

        #region public properties
        public ISensor TemperatureSensor
        {
            get
            {
                return _temperatureSensor;
            }
            set
            {
                _temperatureSensor = value;
            }
        }
        public ISensor PressureSensor
        {
            get
            {
                return _pressureSensor;
            }
            set
            {
                _pressureSensor = value;
            }
        }
        #endregion

        #region constructor
        public Controle( ISensor tSensor, ISensor pSensor )
        {
            _temperatureSensor = tSensor;
            _pressureSensor = pSensor;
        }
        #endregion

        #region public Methods
        public void alert( Type_Sensor type_sensor )
        {
            if (type_sensor == Type_Sensor.Temperature)
                open(_temperatureSensor);
            else if (type_sensor == Type_Sensor.Pressure)
                open(_pressureSensor);
        }

        public void close(ISensor n)
        {
            throw new NotImplementedException();
        }

        public bool disable()
        {
            return _temperatureSensor.resetH() && _pressureSensor.resetH();
        }

        public bool enable()
        {
            return _temperatureSensor.setH() && _pressureSensor.setH();
        }

        public bool getV(ISensor n)
        {
            throw new NotImplementedException();
        }

        public void open(ISensor n)
        {
            
        }

        public void reset(Type_Sensor type_sensor)
        {
            if (type_sensor == Type_Sensor.Temperature)
                close(_temperatureSensor);
            else if (type_sensor == Type_Sensor.Pressure)
                close(_pressureSensor);
        }
        #endregion
    }
}
