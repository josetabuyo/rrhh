﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class Sexo
    {
        public int Id;
        public string Descripcion;

        public Sexo()
        {

        }

        public Sexo(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
