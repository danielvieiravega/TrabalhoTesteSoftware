using System;

namespace TrabalhoTesteSoftware
{
    public class Sensor : ISensor
    {
        public bool IsEnabled { get; private set; }
        public float Reliability { get; set; }
        public float EnvironmentParameter { get; set; }

        public Sensor()
        {
            IsEnabled = false;

        }

        public bool getAlert()
        {
            throw new NotImplementedException();
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
            return Reliability;
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
            if ((r>0) && (r<=1))
            {
                Reliability = r;
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
        public bool setValue(float v)
        {
            
        }
    }
}
