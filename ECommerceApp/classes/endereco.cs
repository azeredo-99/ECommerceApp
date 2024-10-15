using System;

namespace ECommerceApp.classes
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        public Endereco(string rua, string cidade, string codigoPostal, string pais)
        {
            Rua = rua;
            Cidade = cidade;
            CodigoPostal = codigoPostal;
            Pais = pais;
        }

        public override string ToString()
        {
            return $"{Rua}, {Cidade}, {CodigoPostal}, {Pais}";
        }
    }
}
