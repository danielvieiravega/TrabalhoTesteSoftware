using System;
using System.Threading;

namespace TrabalhoTesteSoftware
{
    public class Sensor : ISensor
    {
        public bool IsEnabled { get; private set; }
        public float Confiabilidade { get; private set; }
        public float EnvironmentParameter { get; private set; }
        public TypeSensor TypeSensor { get; private set; }
        public Estado StateSensor { get; set; }

        #region 
        public event EventHandler<Event_Args_Sensor> OnAlert;
        public event EventHandler<Event_Args_Sensor> OnReset;
        #endregion

        private int GenerateRandomParameter()
        {
            var result = 0;

            switch( TypeSensor )
            {
                case TypeSensor.Temperature:
                    result = new Random().Next(Constants.MaxTemperatureValue);
                    break;

                case TypeSensor.Pressure:
                    result = new Random().Next(Constants.MaxPressureValure);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        public Sensor( TypeSensor typeSensor )
        {
            TypeSensor = typeSensor;
            IsEnabled = false;
            EnvironmentParameter = GenerateRandomParameter();

        }

        /// <summary>
        /// Retorna true se o sensor está alerta e false caso contrário.
        /// </summary>
        /// <returns></returns>
        public bool getAlert()
        {
            return StateSensor == Estado.Alerta ? true : false;
        }

        /// <summary>
        /// – retorna true se o sensor está habilitado e false caso contrário
        /// </summary>
        /// <returns></returns>
        public bool getH()
        {
            return IsEnabled;
        }

        /// <summary>
        /// – retorna a confiabilidade do sensor. 
        /// </summary>
        /// <returns></returns>
        public float getR()
        {
            return Confiabilidade;
        }

        /// <summary>
        /// desabilita o sensor. Se o sensor já está desabilitado, não altera
        /// nada e retorna false
        /// </summary>
        /// <returns></returns>
        public bool resetH()
        {
            var result = false;
            if (IsEnabled)
            {
                IsEnabled = false;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// habilita o sensor. Se o sensor já está habilitado, não altera nada e
        /// retorna false, caso contrário retorna true
        /// </summary>
        /// <returns></returns>
        public bool setH()
        {
            var result = false;
            if (!IsEnabled)
            {
                IsEnabled = true;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// define a confiabilidade do sensor. O argumento r é um valor
        /// entre 0 e 1. O método atribui à confiabilidade o valor r
        /// </summary>
        /// <param name="r"></param>
        public void setR(float r)
        {
            if( ( r > 0 ) && ( r <= 1 ) )
            {
                Confiabilidade = r;
            }
        }
        
        /// <summary>
        /// atribui o valor v ao parâmetro controlado pelo sensor (temperatura ou pressão) e retorna true.
        ///     o Se o valor for maior que o limite especificado(40 para temperatura e
        ///       1013 para pressão) e o sensor não está em alerta, o sensor deve passar
        ///       para o estado de alerta e enviar um sinal ao controle(ver abaixo). Se o
        ///       sensor já está em alerta, o método apenas atualiza o valor.
        ///    o Se o valor for menor que o limite e o sensor está em alerta, o sensor deve
        ///       deixar o estado de alerta e enviar um sinal ao controle (ver abaixo).
        ///    o O comportamento deste método é calibrado pela confiabilidade do
        ///      sensor: o método funciona corretamente com probabilidade R, onde R é
        ///      a confiabilidade, definida através do método setR.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool setValue( float v )
        {
            bool result = false;

            float fault_p = (float)( new Random().Next( Constants.ReliabilityMinValue, Constants.ReliabilityMaxValue * 100 ) ) / 100;
            Thread.Sleep( 100 );
            Console.WriteLine( string.Format( "Confiabilidade sensor: {0} | Probabilidade de falha: {1}", Confiabilidade, fault_p ) );

            if( Confiabilidade < fault_p )
                v = EnvironmentParameter = TypeSensor == TypeSensor.Temperature ? Constants.MaxTemperatureValue + 1 : Constants.MaxPressureValure + 1;
            else
            {
                EnvironmentParameter = v; /// seta o valor corretamente, pois a confiabilidade é maior que a probabilidade de falha
                result = true;
            }

            if( v > CheckMaxParameterValue() )
            {
                if (!getAlert())
                {
                    StateSensor = Estado.Alerta;
                    if( OnAlert != null )
                        OnAlert( StateSensor, new Event_Args_Sensor( this )  );
                }
            }
            else if (v < CheckMaxParameterValue())
            {
                if (getAlert())
                {
                    StateSensor = Estado.Desativado;
                    if( OnReset != null )
                        OnReset( StateSensor, new Event_Args_Sensor( this ) );
                }
            }

            return result;
        }

        private int CheckMaxParameterValue()
        {
            return TypeSensor == TypeSensor.Temperature? Constants.MaxTemperatureValue : Constants.MaxPressureValure;
        }
    }
}
