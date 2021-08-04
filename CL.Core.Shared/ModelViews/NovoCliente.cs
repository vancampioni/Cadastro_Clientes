﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para a inserção de um novo cliente.
    /// </summary>
    public class NovoCliente
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>Maria das Graças Ferreira</example>
        public string Nome_Cliente { get; set; }

        /// <summary>
        /// Data de nascimento do cliente
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; set; }

        /// <example>F</example>
        public char Sexo { get; set; }

        /// <example>16999995999</example>
        public string Telefone { get; set; }

        /// <summary>
        /// Documentos aceitos: CNH / RG
        /// </summary>
        /// <example>559999997</example>
        public string Documento { get; set; }
    }
}
