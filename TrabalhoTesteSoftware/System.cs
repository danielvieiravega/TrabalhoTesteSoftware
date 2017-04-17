using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrabalhoTesteSoftware
{
    public class System
    {
        #region constants
        const int MAX = 5;
        #endregion

        #region variables
        private Sensor _tSensor;
        private Sensor _pSensor;
        private Controle _ctrl;
        private int[] _tTestVector = new int[] { 10, 20, 50, 25, 5 };
        private int[] _pTestVector = new int[] { 1013, 100, 2048, 1000, 10 };
        private float[] _rTestVector = new float[] { 0.9f, 0.8f, 0.7f, 0.5f, 0.3f };
        #endregion

        #region properties

        #endregion

        #region constructor
        public System()
        {
            _tSensor = new Sensor( TypeSensor.Temperature );
            _pSensor = new Sensor( TypeSensor.Pressure );
            _tSensor.OnAlert += OnAlert;
            _tSensor.OnReset += OnReset;
            _pSensor.OnAlert += OnAlert;
            _pSensor.OnReset += OnReset;

            _ctrl = new Controle( _tSensor, _pSensor );            
        }
        #endregion

        #region Methods
        public void Run()
        {
            _ctrl.enable();

            for( int i = 0; i < MAX; i++ )
            {
                _tSensor.setR( _rTestVector[i] );
                _pSensor.setR( _rTestVector[i] );
                Console.WriteLine( "Confiabilidade sensor temperatura = " + _tSensor.getR() );
                Console.WriteLine( "Confiabilidade sensor pressao = " + _pSensor.getR() );
                Console.WriteLine();

                for( int k = 0; k < MAX; k++ )
                {
                    _tSensor.setValue( _tTestVector[k] );
                    _pSensor.setValue( _pTestVector[k] );
                    Console.WriteLine( string.Format( "Sensor temperatura: Valor de teste = {0} | Valor limite = {1}", _tTestVector[k], Constants.MaxTemperatureValue ) );
                    Console.WriteLine( "Estado valvula: " + EstadoValvula_Util.GetName( _ctrl.TemperatureValve ) );
                    Console.WriteLine( string.Format( "Sensor pressao: Valor de teste = {0} | Valor limite = {1}", _pTestVector[k], Constants.MaxPressureValure ) );
                    Console.WriteLine( "Estado valvula: " + EstadoValvula_Util.GetName( _ctrl.PressureValve ) );

                    Thread.Sleep( 250 );
                }
                Console.WriteLine( "-------------------------------------------------------------------------------------------------------\n\n" );
            }           

            Console.ReadKey();
        }

        private void OnAlert( object sender, Event_Args_Sensor e )
        {
            _ctrl.alert( e.Sensor );
        }

        private void OnReset( object sender, Event_Args_Sensor e )
        {
            _ctrl.reset( e.Sensor );
        } 
        #endregion
    }
}
