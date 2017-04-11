using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DiMuro.Arthur._5i.XMLReadWrite
{
    public class Persona
    {
        private string _cognome;
        public string Cognome {
            set { _cognome = value; }
            get { return _cognome; }
        }

        public string Nome { get; set; }
        public string Telefono { get; set; }
        public string Indirizzo { get; set; }

        public Persona(XElement e)
        {
            Nome = e.Attribute("nome").Value;
            Cognome = e.Attribute("cognome").Value;
            Telefono = e.Attribute("telefono").Value;
            Indirizzo = e.Attribute("indirizzo").Value;
        }

        public Persona(string Nome, string Cognome, string Telefono, string Indirizzo)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Telefono = Telefono;
            this.Indirizzo = Indirizzo;
        }

        public Persona() { }

        public XElement XML
        {
            get
            {
                return new XElement(
                    "Persona",
                        new XAttribute("nome", Nome),
                        new XAttribute("cognome", Cognome),
                        new XAttribute("indirizzo", Indirizzo),
                        new XAttribute("telefono", Telefono)
                );
            }
        }
    }

    public class Persone : List<Persona>
    {
        public string FileName { get; }

        public XElement XML {
            get
            {
                return new XElement(   
                "Rubrica",
                    from item in this
                    select item.XML );
            }
        }

        public Persone(string fileName)
        {
            FileName = fileName;
            XElement Elements = XElement.Load(FileName);
            AddRange(
                from item in Elements.Elements("Persona")
                select new Persona(item)
            );
        }

        void Save()
        {
            XML.Save(FileName);
        }

        public void Aggiungi()
        {
            Add(
                new Persona {
                    Nome = "Arturo",
                    Cognome = "il canguro",
                    Telefono = "3333948626",
                    Indirizzo = "via dalle p. 7" }
            );

            Save();
        }
    }
}