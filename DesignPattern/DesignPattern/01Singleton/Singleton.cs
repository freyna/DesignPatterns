namespace DesignPattern._01Singleton
{
    public class Singleton
    {
        // Se crea la instancia en tiempo de ejecución
        private readonly static Singleton instance = new Singleton();

        // Obtenemos nuestra instancia.
        public static Singleton Instance
        {
            get 
            { 
                return instance; 
            }
        }

        // Creamos un constructor privado para evitar poder crear otra instancia de la clase
        private Singleton()
        {
               
        }
    }
}
