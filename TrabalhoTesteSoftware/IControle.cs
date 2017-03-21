namespace TrabalhoTesteSoftware
{
    public interface IControle
    {
        bool enable();
        bool disable();
        void alert(TypeSensor n);
        void reset(TypeSensor n);
        void open(ISensor n);
        void close(ISensor n);
        bool getV(ISensor n);
    }
}
