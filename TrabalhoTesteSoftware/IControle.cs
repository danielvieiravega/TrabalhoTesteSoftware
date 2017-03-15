namespace TrabalhoTesteSoftware
{
    public interface IControle
    {
        bool enable();
        bool disable();
        void alert(ISensor n);
        void reset(ISensor n);
        void open(ISensor n);
        void close(ISensor n);
        bool getV(ISensor n);
    }
}
