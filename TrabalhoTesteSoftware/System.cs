using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoTesteSoftware
{
    public class System
    {
        #region variables
        private Sensor _tSensor;
        private Sensor _pSensor;
        private Controle _ctrl;
        #endregion

        #region properties

        #endregion

        #region constructor
        public System()
        {
            _tSensor = new Sensor( TypeSensor.Temperature );
            _pSensor = new Sensor( TypeSensor.Pressure );
            _tSensor.OnAlert += OnAlert;

            _ctrl = new Controle( _tSensor, _pSensor );            
        }
        #endregion

        #region Methods
        public void Run()
        {
            _ctrl.enable();

            _tSensor.setValue( 45 );
            Console.WriteLine( _ctrl.getV( _tSensor ) );
            _tSensor.setValue( 10 );

            Console.ReadKey();
        }

        private void OnAlert( object sender, Event_Args_Sensor e )
        {
            _ctrl.alert( e.Sensor );
            Console.WriteLine( "OnAlert acionado" );
        }

        private void OnReset( object sender, Event_Args_Sensor e )
        {
            _ctrl.reset( e.Sensor );
            Console.WriteLine( "OnReset acionado" );
        } 
        #endregion
    }
}
