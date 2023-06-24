namespace Entidades
{
    public abstract class Usuario
    {
        #region ATRIBUTOS
        protected int id;
        protected string nombre;
        protected string correo;
        protected string contrasenia;
        protected int idPersona;
        protected int idCliente;
        #endregion

        #region CONSTRUCTOR
        protected Usuario(string nombre, string correo, string contrasenia)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.contrasenia = contrasenia;
        }
        protected Usuario(int id,string nombre, string correo,string contrasenia,int IdPersona,int IdCliente):this(nombre,correo,contrasenia)
        {
            this.id = id;
            this.idPersona = IdPersona;
            this.idCliente = IdCliente;
        }
        #endregion

        #region PROPIEDADES
        public string Nombre{get { return this.nombre; } set { this.nombre = value; } }
        public string Correo{ get { return correo; } set { correo = value; } }
        public string Contrasenia{get { return contrasenia; }set { contrasenia = value; }}
        public int IdPersona { get { return this.idPersona; }set { this.idPersona = value; } }
        public int IdCliente { get { return this.idCliente; } set { this.idCliente = value; } }
        public int Id { get { return this.id; } set { this.id = value; } }
        #endregion

        #region METODOS

        /// <summary>
        /// Devuelve una representación en formato de cadena del objeto.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            return $"{Nombre}";
        }

        #endregion
    }
}