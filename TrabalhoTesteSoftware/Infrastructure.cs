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
    }

    public enum Estado
    {
        Desativado,
        Alerta
    }
}
