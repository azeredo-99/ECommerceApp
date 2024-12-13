namespace ECommerceApp.classes
{
    public class StatusPedidos
    {
        #region Enum

        public enum StatusPedido
        {
            AguardaPagamento,
            Processando,
            Enviado,
            Entregue
        }

        #endregion

        #region Methods

        public static string ObterDescricao(StatusPedido status)
        {
            switch (status)
            {
                case StatusPedido.AguardaPagamento:
                    return "Aguarda pagamento";
                case StatusPedido.Processando:
                    return "Pedido em processamento";
                case StatusPedido.Enviado:
                    return "Pedido enviado";
                case StatusPedido.Entregue:
                    return "Pedido entregue";
                default:
                    return "Status desconhecido";
            }
        }

        #endregion
    }
}
