// LoginWindow.cs
using System;
using System.Configuration; // �Necesario para leer de App.config!
using System.Windows.Forms;

namespace VentaTerrenosApp
{
    public partial class LoginWindow : Form // Aseg�rate de que esta clase se llame LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Configurar la propiedad PasswordChar para el campo de contrase�a
            // Aseg�rate de que tu TextBox de contrase�a se llame txtContrasena
            txtContrasena.PasswordChar = '*';
        }

        // Este es el m�todo que se ejecuta cuando se hace clic en el bot�n "Log In"
        // Aseg�rate de que tu bot�n se llame btnLogin y que este m�todo est� conectado a su evento Click.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Obtener el usuario y la contrase�a ingresados por el usuario
            // Aseg�rate de que tus TextBox se llamen txtUsuario y txtContrasena
            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresada = txtContrasena.Text;

            // 2. Obtener el usuario y la contrase�a predeterminados del archivo App.config
            string usuarioPredeterminado = ConfigurationManager.AppSettings["DefaultUser"];
            string contrasenaPredeterminada = ConfigurationManager.AppSettings["DefaultPassword"];

            // 3. Validar las credenciales
            if (usuarioIngresado == usuarioPredeterminado && contrasenaIngresada == contrasenaPredeterminada)
            {
                // Credenciales correctas:
                MessageBox.Show("�Inicio de sesi�n exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar la ventana de login
                this.Hide();

                // Crear e iniciar la ventana principal de la aplicaci�n (FormClientes)
                // Aseg�rate de que tengas un formulario llamado FormClientes.cs en tu proyecto
                FormClientes formPrincipal = new FormClientes();
                formPrincipal.Show();

                // Opcional: Cerrar la aplicaci�n si la ventana principal se cierra
                // formPrincipal.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                // Credenciales incorrectas:
                MessageBox.Show("Usuario o contrase�a incorrectos. Por favor, int�ntelo de nuevo.", "Error de Inicio de Sesi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear(); // Limpiar el campo de contrase�a
                txtUsuario.Focus(); // Poner el foco de nuevo en el campo de usuario
            }
        }

        // Opcional: Evento KeyPress para el campo de contrase�a
        // Permite presionar Enter para iniciar sesi�n desde el campo de contrase�a
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e); // Llama al evento click del bot�n de login
                e.Handled = true; // Indica que el evento ha sido manejado
            }
        }
    }
}