// LoginWindow.cs
using System;
using System.Configuration; // ¡Necesario para leer de App.config!
using System.Windows.Forms;

namespace VentaTerrenosApp
{
    public partial class LoginWindow : Form // Asegúrate de que esta clase se llame LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Configurar la propiedad PasswordChar para el campo de contraseña
            // Asegúrate de que tu TextBox de contraseña se llame txtContrasena
            txtContrasena.PasswordChar = '*';
        }

        // Este es el método que se ejecuta cuando se hace clic en el botón "Log In"
        // Asegúrate de que tu botón se llame btnLogin y que este método esté conectado a su evento Click.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Obtener el usuario y la contraseña ingresados por el usuario
            // Asegúrate de que tus TextBox se llamen txtUsuario y txtContrasena
            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresada = txtContrasena.Text;

            // 2. Obtener el usuario y la contraseña predeterminados del archivo App.config
            string usuarioPredeterminado = ConfigurationManager.AppSettings["DefaultUser"];
            string contrasenaPredeterminada = ConfigurationManager.AppSettings["DefaultPassword"];

            // 3. Validar las credenciales
            if (usuarioIngresado == usuarioPredeterminado && contrasenaIngresada == contrasenaPredeterminada)
            {
                // Credenciales correctas:
                MessageBox.Show("¡Inicio de sesión exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar la ventana de login
                this.Hide();

                // Crear e iniciar la ventana principal de la aplicación (FormClientes)
                // Asegúrate de que tengas un formulario llamado FormClientes.cs en tu proyecto
                FormClientes formPrincipal = new FormClientes();
                formPrincipal.Show();

                // Opcional: Cerrar la aplicación si la ventana principal se cierra
                // formPrincipal.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                // Credenciales incorrectas:
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear(); // Limpiar el campo de contraseña
                txtUsuario.Focus(); // Poner el foco de nuevo en el campo de usuario
            }
        }

        // Opcional: Evento KeyPress para el campo de contraseña
        // Permite presionar Enter para iniciar sesión desde el campo de contraseña
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e); // Llama al evento click del botón de login
                e.Handled = true; // Indica que el evento ha sido manejado
            }
        }
    }
}