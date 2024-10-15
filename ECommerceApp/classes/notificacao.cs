using System;

namespace ECommerceApp.classes
{
    public class Notificacao
    {
        public static void EnviarEmail(string email, string mensagem)
        {
            Console.WriteLine($"Enviando email para {email}: {mensagem}");
        }
    }
}
