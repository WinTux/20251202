namespace EjemplosVarios
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Configurar el temporizador para actualizar el reloj cada segundo
            var temporizador = new System.Timers.Timer(1000); // 1000 ms = 1 segundo
            temporizador.Elapsed += new System.Timers.ElapsedEventHandler(RedibujarReloj);
            temporizador.Start();
        }

        public void RedibujarReloj(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var graficosView = this.relojGraphicsView;
            graficosView.Invalidate();
        }
    }
}
