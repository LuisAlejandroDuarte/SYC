using System;
using System.Collections.Generic;

namespace MENSAJESDLL
{
    public enum TipoMensaje
    {
        Informacion,
        Advertencia,
        Error,
        CondicionSINO
    }

    public enum Tema
    {
        primary,
        accent,
        warn
    }

    public class Botones
    {
        public string Label { get; set; }
        public Tema Tema { get; set; }
        public bool Visible { get; set; }
    }


    public class Mensaje
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public string Pie { get; set; }
        public string NVentana { get; set; }
        public TipoMensaje Tipo { get; set; }

        public List<Botones> Botones { get; set; }



        public Mensaje()
        {
            Id = 0;
            Titulo = "";
            Cuerpo = "";
            Pie = "";
            NVentana = "";
            Botones = new List<Botones>();
        }


        public Mensaje(long id, string titulo, string cuerpo, string pie = "", TipoMensaje tipo = TipoMensaje.Advertencia, string nVentana = "IdError")
        {
            Id = id;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Pie = pie;
            NVentana = nVentana;
            Tipo = tipo;
            Botones = new List<Botones>();

            switch (tipo)
            {
                case TipoMensaje.Informacion:

                    Botones.Add(new Botones { Label = "Aceptar", Tema = Tema.primary, Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Tema = Tema.primary, Visible = false });
                    break;
                case TipoMensaje.Advertencia:
                    Botones.Add(new Botones { Label = "Aceptar", Tema = Tema.primary, Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Tema = Tema.primary, Visible = false });
                    break;
                case TipoMensaje.Error:
                    Botones.Add(new Botones { Label = "Aceptar", Tema = Tema.warn, Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Tema = Tema.warn, Visible = false });
                    break;
                case TipoMensaje.CondicionSINO:
                    Botones.Add(new Botones { Label = "SI", Tema = Tema.primary, Visible = true });
                    Botones.Add(new Botones { Label = "NO", Tema = Tema.primary, Visible = true });
                    break;
                default:
                    break;
            }
        }
    }
}

