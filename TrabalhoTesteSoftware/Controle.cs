using System;

namespace TrabalhoTesteSoftware
{
    public class Controle : IControle
    {
        #region private variables
        private Sensor _temparatureSensor;
        private Sensor _pressureSensor;
        private EstadoValvula _temperatureValve;
        private EstadoValvula _pressureValve;
        #endregion

        #region public properties
        public ISensor TemperatureSensor { get { return _temparatureSensor; } }
        public ISensor PressureSensor { get { return _pressureSensor; } }
        public EstadoValvula TemperatureValve { get { return _temperatureValve; } }
        public EstadoValvula PressureValve { get { return _pressureValve; } }
        #endregion

        #region constructor
        public Controle( Sensor tSensor, Sensor pSensor )
        {
            _temparatureSensor = tSensor;
            _pressureSensor = pSensor;         
            _temperatureValve = EstadoValvula.Fechado;
            _pressureValve = EstadoValvula.Fechado;
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

        public void alert( Sensor n)
        {
            switch( n.TypeSensor )
            {
                case TypeSensor.Temperature:
                    open( n );
                    break;
                case TypeSensor.Pressure:
                    open( n );
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(n), n, null);
            }
        }

        public void reset( Sensor n )
        {
            switch( n.TypeSensor )
            {
                case TypeSensor.Temperature:
                    close( n );
                    break;
                case TypeSensor.Pressure:
                    close( n );
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof( n ), n, null );
            }
        }

        public void open( Sensor n )
        {
            if( n.TypeSensor == TypeSensor.Temperature )
                _temperatureValve = EstadoValvula.Aberto;
            else if( n.TypeSensor == TypeSensor.Pressure )
                _pressureValve = EstadoValvula.Aberto;
        }

        public void close( Sensor n )
        {
            if( n.TypeSensor == TypeSensor.Temperature )
                _temperatureValve = EstadoValvula.Fechado;
            else if( n.TypeSensor == TypeSensor.Pressure )
                _pressureValve = EstadoValvula.Fechado;
        }

        public bool getV( Sensor n )
        {
            return n.TypeSensor == TypeSensor.Temperature ? TemperatureValve == EstadoValvula.Aberto :
                PressureValve == EstadoValvula.Aberto;
        }
        #endregion
    }
}
