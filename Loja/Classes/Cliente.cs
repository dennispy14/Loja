﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Loja.Classes
{
	public partial class Cliente
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


        //public int Codigo { get; set; }
        private int _codigo;
		public int Codigo
        {
            get 
			{ 
				return _codigo; 
			}
            set 
			{ 
                if(value < 0 )
                {
                    throw new Loja.Excecoes.ValidacaoException("O cidigo do cliente não pode ser negativo!");
                    //_codigo = 0;
                }
				_codigo = value;
                this._isModified = true;
			}
        }

        //public string Nome { get; set; }
        private string _nome;

        public string Nome
        {
            get 
			{ 
				return _nome; 
			}
            set 
			{
               /*if (value.Length <= 3)
                    throw new Loja.Excecoes.ValidacaoException("O nome de cliente deve ser maior que 4!");*/
                _nome = value;
                this._isModified = true;
            }
        }

        //public int? Tipo { get; set; }
        private int? _tipo;

        public int? Tipo
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

        //public DateTime DataCadastro { get; set; }
        private DateTime _dataCadastro;

        public DateTime DataCadastro
        {
            get 
            {
                return _dataCadastro; 
            }
            set 
            { 
                _dataCadastro = value;
                this._isModified = true;
            }
        }

        //public List<Contato> Contatos { get; set; }
        private List<Contato> _contatos;

        public List<Contato> Contatos
        {
            get 
            { 
                return _contatos; 
            }
            set
            {
                _contatos = value;
                this._isModified = true;
            }
        }





    }
}
