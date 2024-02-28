using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
        private int _numero;
        private string _titular;
        private double _saldo;
        private double _depositoInicial;
        const double taxa = 3.50;

        public ContaBancaria(int numero, string titular, double depositoInicial = 0) {
            _numero = numero;
            _titular = titular;
            _depositoInicial = depositoInicial;
            setSaldo(depositoInicial);

        }

        private void setSaldo(double saldo)
        {
            _saldo = saldo;
        }

        public double getSaldo()
        {
            return _saldo;
        }

        public int getConta()
        {
            return _numero;
        }

        public string getTitular()
        {
            return _titular;
        }
        public void setTitular(string titular)
        {
            _titular = titular;
        }

        public void Deposito(double valor)
        {
            valor = valor+getSaldo();

            setSaldo(valor);
        }

        public void Saque(double valor)
        {
            valor =  getSaldo() - (valor + taxa);

            setSaldo(valor);
        }

    };
}
