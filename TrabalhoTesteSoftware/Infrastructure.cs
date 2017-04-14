using System.Collections.Generic;
using System.Linq;

namespace TrabalhoTesteSoftware
{
    public enum TypeSensor
    {
        Temperature = 0,
        Pressure
    };

    public static class Constants
    {
        public const int MaxTemperatureValue = 40;
        public const int MaxPressureValure = 1013;
        public const int ReliabilityMaxValue = 1;
        public const int ReliabilityMinValue = 0;
    }

    public enum Estado
    {
        Desativado,
        Alerta,
        Operacao
    }


    public enum EstadoValvula
    {
        Aberto,
        Fechado
    }

    public static class EstadoValvula_Util
    {
        public static Dictionary<string, int> Data
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    {"Aberto",  (int)EstadoValvula.Aberto },
                    {"Fechado", (int)EstadoValvula.Fechado},
                };
            }
        }

        public static string GetName( EstadoValvula data )
        {
            return GetName( (int)data );
        }
        public static string GetName( int value )
        {
            if( EstadoValvula_Util.Data.ContainsValue( value ) )
            {
                return EstadoValvula_Util.Data.Where( d => d.Value == value ).First().Key;
            }
            return string.Empty;
        }

        public static int GetValue( string name )
        {
            if( EstadoValvula_Util.Data.ContainsKey( name ) )
            {
                return EstadoValvula_Util.Data[name];
            }
            return -1;
        }
    }
}
