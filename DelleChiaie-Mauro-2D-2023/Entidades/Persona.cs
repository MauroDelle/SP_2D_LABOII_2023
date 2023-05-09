namespace Entidades
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        protected string nombre;
        protected string correo;
        protected string contrasenia;
        #endregion

        #region CONSTRUCTOR
        protected Persona(string nombre, string correo, string contrasenia)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.contrasenia = contrasenia;
        }
        #endregion

        #region PROPIEDADES
        public string Nombre{get { return this.nombre; }}
        public string Correo{ get { return correo; } set { correo = value; } }
        public string Contrasenia{get { return contrasenia; }set { contrasenia = value; }}
        #endregion

        #region METODOS

        /// <summary>
        /// Determina si el objeto actual es una instancia de la clase Vendedor.
        /// </summary>
        /// <returns>Devuelve verdadero si el objeto es una instancia de Vendedor, falso en caso contrario.</returns>
        public abstract bool EsVendedor();
        #endregion
    }
}