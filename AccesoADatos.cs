using GestionPedidos;

public class AccesoADatos
{
    public bool ExisteArchivo(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            var info = new FileInfo(rutaArchivo);

            if (info.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void CargarListaCadetes(string rutaArchivo, List<Cadete> cadetes)
    {
       if (ExisteArchivo(rutaArchivo))
       {
            using (var infoCadete = new StreamReader(rutaArchivo))
            {
                while (!infoCadete.EndOfStream)
                {
                    string linea = infoCadete.ReadLine();
                    string[] datosCadete = linea.Split(';');

                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    long telefono = long.Parse(datosCadete[3]);

                    cadetes.Add(new Cadete(id,nombre,direccion,telefono));
                
                }
            }
       }
    }

    public  Cadeteria CrearCadeteria(string rutaDatosCadeteria)
    {
       Cadeteria cadeteria = null;

        if (ExisteArchivo(rutaDatosCadeteria))
        {
            string[] linea = File.ReadAllLines(rutaDatosCadeteria);
            string primeraLinea = linea[0];
            string[] datosCadeteria = primeraLinea.Split(',');
            string nombre = datosCadeteria[0];
            long telefono = long.Parse(datosCadeteria[1]);
            
            cadeteria = new Cadeteria(nombre,telefono);
        }

        return cadeteria;
        
    }

   

}