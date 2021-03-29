using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Loja.Classes
{
	public partial class Contato : IDisposable
    {

        private bool _isNew;
        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }

        private bool _isModified;
        [Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }
        }

        private int _codigo;
        [DisplayName("Código")]
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value < 0)
                {
                    throw new Loja.Excecoes.ValidacaoException("O cidigo do Contato não pode ser negativo!");
                    //_codigo = 0;
                }
                _codigo = value;
                this._isModified = true;
            }
        }        

        private string _dadoscontato;
        [DisplayName("Dados do Contato")]
        public string DadosContato
        {
            get
            {
                return _dadoscontato;
            }
            set
            {               
                _dadoscontato = value;
                this._isModified = true;
            }
        }

        private string _tipo;
        public string Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
                this._isModified = true;
            }
        }

        private int _cliente;
        
        public int Cliente 
        {
            get { return _cliente; } 
            set { _cliente = value; } 
        }






    }
}
