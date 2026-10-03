namespace QuanLyCuaHangOnline
{
    public class AppContext
    {
        public readonly AppSession Session = new AppSession();
        public readonly SqlRepository Repo = new SqlRepository();
        public readonly ProductService Products;
        public readonly CartService Cart;
        public readonly AccountService Account;
        public readonly CheckoutService Checkout;
        public AppContext()
        {
            var catalog = new ProductCatalogAdapter(Repo);
            Products = new ProductService(catalog);
            Cart = new CartService(catalog, Session);
            Account = new AccountService(Repo);
            Checkout = new CheckoutService(Session, catalog, Repo,
                new PaymentGatewayAdapter(), new EmailService(Repo, new EmailGatewayAdapter()));
        }
    }
}
