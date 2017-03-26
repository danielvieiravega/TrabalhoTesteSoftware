namespace TrabalhoTesteSoftware
{
    public interface IControle
    {
        bool enable();
        bool disable();
        void alert(Sensor n);
        void reset(Sensor n);
        void open(Sensor n);
        void close(Sensor n);
        bool getV(Sensor n);
    }
}
