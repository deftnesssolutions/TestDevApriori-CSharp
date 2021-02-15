﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using GO.Providers;
using System.Data.SqlClient;
using System.Data;

namespace Orcamento.Web.Helpers
{
    /*######
     * Programa: Classe para Criptografar senha de Usuairo para acceso seguro
     * Autor: GUSTAVO OVELAR
     * Fecha: 24/01/2021
    #####*/
    public static class CriptoHelper
    {       
        public static string HashMD5(string val)
        {
            var bytes = Encoding.ASCII.GetBytes(val);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(bytes);

            var ret = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                ret += hash[i].ToString("x2");
            }

            return ret;
        }
    }
}